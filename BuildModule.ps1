[CmdletBinding()]
param(

)

Push-Location -Path "./src/"

try {
    dotnet clean
    dotnet publish /property:PublishWithAspNetCoreTargetManifest=false
    #Start-Process -FilePath "dotnet" -ArgumentList @("clean") -Wait -NoNewWindow -ErrorAction Stop
    #Start-Process -FilePath "dotnet" -ArgumentList @("publish", "/property:PublishWithAspNetCoreTargetManifest=false") -Wait -NoNewWindow -ErrorAction Stop
}
finally {
    Pop-Location
}

if (Test-Path -Path "./build") {
    Remove-Item -Path "./build" -Recurse -Force
}

$null = New-Item -Type Directory -Path "./build"
$null = New-Item -Type Directory -Path "./build/mdatp-pwsh"

Copy-Item -Path "./src/bin/Debug/netstandard2.1/publish/MdatpPwsh.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./src/bin/Debug/netstandard2.1/publish/Microsoft.Identity.Client.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./src/bin/Debug/netstandard2.1/publish/Newtonsoft.Json.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./license.txt" -Destination "./build/mdatp-pwsh/License.txt"

Copy-Item -Path "./module-manifest/mdatp-pwsh.psd1" -Destination "./build/mdatp-pwsh/"