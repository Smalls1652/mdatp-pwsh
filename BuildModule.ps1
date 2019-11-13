$ConfigSplat = @{
    "Path" = "./bin/Debug/netstandard2.0/publish/mdatp-pwsh.psd1";
    "RootModule" = "mdatp_pwsh.dll";
    "Guid" = [guid]"afc0e191-ffe7-4261-ba9e-d59652423d8c";
    "Description" = "MDATP PowerShell Module";
    "Author" = "Tim Small";
    "CompanyName" = "Smalls.Online";
    "Copyright" = 2019;
    "ModuleVersion" = "1911.00.01";
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
    "RequiredAssemblies" = @("Microsoft.Identity.Client.dll")
}

dotnet clean

dotnet publish /property:PublishWithAspNetCoreTargetManifest=false

New-ModuleManifest @ConfigSplat