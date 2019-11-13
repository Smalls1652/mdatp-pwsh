$ConfigSplat = @{
    "Path" = "./mdatp-pwsh/mdatp-pwsh.psd1";
    "RootModule" = "mdatp_pwsh.dll";
    "Guid" = [guid]"afc0e191-ffe7-4261-ba9e-d59652423d8c";
    "Description" = "MDATP PowerShell Module";
    "Author" = "Tim Small";
    "CompanyName" = "Smalls.Online";
    "Copyright" = 2019;
    "ModuleVersion" = "1911.00.01";
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
        "Get-DatpUserMachines"
        );
    "RequiredAssemblies" = @(
        "Microsoft.Identity.Client.dll",
        "Newtonsoft.Json.dll"
        )
}

dotnet clean

dotnet publish /property:PublishWithAspNetCoreTargetManifest=false

if (Test-Path -Path "./mdatp-pwsh/") {
    Remove-Item -Path "./mdatp-pwsh" -Recurse -Force
}

$null = New-Item -Type Directory -Path "./mdatp-pwsh"

Copy-Item -Path "./bin/Debug/netstandard2.0/publish/mdatp_pwsh.dll" -Destination "./mdatp-pwsh/"
Copy-Item -Path "./bin/Debug/netstandard2.0/publish/Microsoft.Identity.Client.dll" -Destination "./mdatp-pwsh/"
Copy-Item -Path "./bin/Debug/netstandard2.0/publish/Newtonsoft.Json.dll" -Destination "./mdatp-pwsh/"

New-ModuleManifest @ConfigSplat