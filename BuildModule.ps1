$ConfigSplat = @{
    "Path" = "./build-out/mdatp-pwsh/mdatp-pwsh.psd1";
    "RootModule" = "mdatp_pwsh.dll";
    "Guid" = [guid]"afc0e191-ffe7-4261-ba9e-d59652423d8c";
    "Description" = "MDATP PowerShell Module";
    "Author" = "Tim Small";
    "CompanyName" = "Smalls.Online";
    "Copyright" = 2019;
    "ModuleVersion" = "1911.01.00";
    "Prerelease" = "alpha4";
    "ProjectUri" = "https://github.com/smalls1652/mdatp-pwsh";
    "LicenseUri" = "https://raw.githubusercontent.com/Smalls1652/mdatp-pwsh/master/license.txt";
    "CmdletsToExport" = @(
        "Set-DatpModuleConfig",
        "Connect-DatpGraph",
        "Get-DatpMachine",
        "Get-DatpMachineAlerts",
        "Get-DatpMachineUsers",
        "Set-DatpMachineIsolation",
        "Add-DatpMachineTag",
        "Remove-DatpMachineTag",
        "Start-DatpMachineScan",
        "Get-DatpMachineAction",
        "Start-DatpInvestigationPkgCollection",
        "Get-DatpDomainStats",
        "Get-DatpDomainRelated",
        "Get-DatpUserMachines",
        "Get-DatpUserAlerts"
        );
    "RequiredAssemblies" = @(
        "Microsoft.Identity.Client.dll",
        "Newtonsoft.Json.dll"
        )
}

Push-Location -Path "./src/"

Start-Process -FilePath "dotnet" -ArgumentList @("clean") -Wait
Start-Sleep -Seconds 5
Start-Process -FilePath "dotnet" -ArgumentList @("publish", "/property:PublishWithAspNetCoreTargetManifest=false") -Wait

Pop-Location

if (Test-Path -Path "./build-out") {
    Remove-Item -Path "./build-out" -Recurse -Force
}

$null = New-Item -Type Directory -Path "./build"
$null = New-Item -Type Directory -Path "./build/mdatp-pwsh"

Copy-Item -Path "./src/bin/Debug/netstandard2.0/publish/mdatp_pwsh.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./src/bin/Debug/netstandard2.0/publish/Microsoft.Identity.Client.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./src/bin/Debug/netstandard2.0/publish/Newtonsoft.Json.dll" -Destination "./build/mdatp-pwsh/"
Copy-Item -Path "./license.txt" -Destination "./build/mdatp-pwsh/License.txt"

New-ModuleManifest @ConfigSplat