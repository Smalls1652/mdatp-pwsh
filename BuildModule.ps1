[CmdletBinding()]
param(

)

$ScriptLocation = $PSScriptRoot

$csProjectDir = [System.IO.Path]::Combine($ScriptLocation, "src\")
$csProjectPublishDir = [System.IO.Path]::Combine($csProjectDir, "bin\", "Debug\", "netstandard2.1\", "publish\")

$helpDocsDir = [System.IO.Path]::Combine($ScriptLocation, "help-docs\")
$enusHelpDocs = [System.IO.Path]::Combine($helpDocsDir, "locale\", "en-us\")
$compiledHelpDir = [System.IO.Path]::Combine($helpDocsDir, "compiled\")
$compiledHelpFile = [System.IO.Path]::Combine($compiledHelpDir, "MdatpPwsh.dll-Help.xml")

Import-Module -Name "platyPS"
New-ExternalHelp -Path $enusHelpDocs -OutputPath $compiledHelpDir -Force

$buildDir = [System.IO.Path]::Combine($ScriptLocation, "build\")
$buildModuleDir = [System.IO.Path]::Combine($buildDir, "mdatp-pwsh\")

$sourceLicensePath = [System.IO.Path]::Combine($ScriptLocation, "license.txt")
$destinationLicensePath = [System.IO.Path]::Combine($buildModuleDir, "License.txt")

$filesToCopy = [System.Collections.Generic.List[string[]]]@(
            ([System.IO.Path]::Combine($ScriptLocation, "module-manifest\", "mdatp-pwsh.psd1")),
            ([System.IO.Path]::Combine($csProjectPublishDir, "MdatpPwsh.dll")),
            ([System.IO.Path]::Combine($csProjectPublishDir, "Microsoft.Identity.Client.dll")),
            ([System.IO.Path]::Combine($csProjectPublishDir, "System.Text.Json.dll")),
            $compiledHelpFile
)

Push-Location -Path $csProjectDir

try {
    dotnet clean
    dotnet publish /property:PublishWithAspNetCoreTargetManifest=false
    #Start-Process -FilePath "dotnet" -ArgumentList @("clean") -Wait -NoNewWindow -ErrorAction Stop
    #Start-Process -FilePath "dotnet" -ArgumentList @("publish", "/property:PublishWithAspNetCoreTargetManifest=false") -Wait -NoNewWindow -ErrorAction Stop
}
finally {
    Pop-Location
}


if (Test-Path -Path $buildDir) {
    Remove-Item -Path $buildDir -Recurse -Force
}

$null = New-Item -Type Directory -Path $buildDir
$null = New-Item -Type Directory -Path $buildModuleDir

foreach ($item in $filesToCopy) {
    Copy-Item -Path $item -Destination $buildModuleDir
}

Copy-Item -Path $sourceLicensePath -Destination $destinationLicensePath