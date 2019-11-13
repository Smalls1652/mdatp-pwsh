# Microsoft Defender ATP PowerShell Module

**This module is still a work in progress. Documentation is not fully created and unknown errors may occur while using.**

This module is for interacting with the Defender ATP Graph API using delegated permissions. The primary goal of this project was to create a cross-platform module that works on Windows, macOS, and Linux. To keep it simple for cross-platform use, the authentication mechanism is using the *device code flow* in the **Microsoft Authentication Library**.

## Install

### PowerShell Gallery

**At this time, the module is not on PowerShell Gallery yet.**

### Building from source

#### Prerequisites

- .NET Core 3.0 SDK

#### Build

1. Launch a PowerShell prompt.
2. Set the current directory to the project directory.
3. Run `./BuildModule.ps1` in the directory.
4. The module is then built in the `mdatp-pwsh` folder. Copy that folder to your PowerShell modules folder.

## Setup

### Azure AD App Registration

1. Log into your Azure AD portal and navigate to **App Registrations**.
2. Click on **New registration**.
3. On the **Register an application page**...
   1. Name the app whatever you want to name it.
   2. Leave the **Supported account types** as *Accounts in this organizational directory only (Your Tenant Name only - Single tenant)*.
   3. Set **Platform configuration (Optional)** to *Client Application (Web, iOS, Android, Desktop+Devices)*.
   4. Click **Register** when finished.
4. When redirected to the app's page, navigate to the **Authentication** page for the app.
   1. Click **Add a platform**.
   2. Choose **Mobile and desktop applications**.
   3. And add the suggested redirect URI `https://login.microsoftonline.com/common/oauth2/nativeclient`.
   4. Click **Configure**.
   5. Under **Advanced settings** change the option for ***Treat application as a public client*** to *Yes*.
   6. Click **Save** at the top of the page.
5. On the left side, click on **API permissions**.
   1. Click on **Add a permission** and then click on the **APIs my organization uses** tab.
   2. Search for `WindowsDefenderAtp` and choose the first option.
   3. Click on **Delegated permissions** and then choose the following:
      - AdvancedQuery.Read
      - Alert.Read
      - Alert.ReadWrite
      - File.Read.All
      - Ip.Read.All
      - Machine.Isolate
      - Machine.Read
      - Machine.ReadWrite
      - Machine.RestrictExecution
      - Machine.Scan
      - Machine.ScanAndQuarantine
      - Score.Read
      - SecurityConfiguration.Read
      - SecurityRecommendation.Read
      - Software.Read
      - Ti.ReadWrite
      - Url.Read.All
      - User.Read.All
      - Vulnerability.Read
    1. Click the **Add permissions** button.
    2. Scroll to the bottom of the screen and click on the **Grant admin consent for *Your Tenant Name*** button. Click on **Yes** when prompted.
 1. Click on the **Overview** link on the left side of the screen of the app page and note the following for later:
    1. Application (client) ID
    2. Directory (tenant) ID

### Configure the Defender ATP PowerShell module

After importing the `mdatp-pwsh` module, run the following command:

```powershell
Set-DatpModuleConfig -PublicClientAppId "95155854-bb54-4533-a3e0-14af326e997f" -TenantId "5b6a210c-711e-476a-a99c-2460df178748"
```

- `-PublicClientAppId` is associated with the app registration's *Application (client) ID*.
- `-TenantId` is associated with your Azure AD's *Directory (tenant) ID*.

*\* Module config is saved to the user profile directory under `.mdatp-pwsh`.*

## Using the Module

To connect to Microsoft Graph, run the cmdlet:
```powershell
Connect-DatpGraph
```

This will prompt the **Device Code Flow** with a code you must enter on the [Microsoft Device Logon](https://microsoft.com/devicelogin) page through a web browser. After authenticating, it will return the authentication token back to the prompt.

*\* The authentication token is saved to the current session, so there's no need to save the return to a variable.*

### Cmdlets Available

- `Connect-DatpGraph`
- `Set-DatpModuleConfig`
- `Get-DatpMachine`
- `Get-DatpMachineAlerts`
- `Get-DatpMachineUsers`
- `Set-DatpMachineIsolation`
- `Add-DatpMachineTag`
- `Remove-DatpMachineTag`
- `Start-DatpMachineScan`
- `Get-DatpUserMachines`

## Todo

- API Functions
  - List of official functions are [here](https://docs.microsoft.com/en-us/windows/security/threat-protection/microsoft-defender-atp/exposed-apis-list).
  - Advanced Hunting
    - [ ] Run advanced hunting queries
  - Machine
    - [x] Get/List machines
    - [x] Get machine log on users
    - [x] Get machine related alerts
    - [x] Add/Remove machine tags
    - [ ] Find machines by IP
  - Machine Actions
    - [ ] Get/List machine actions
    - [ ] Collect investigation package
    - [ ] Get investigation package
    - [x] Isolate/Uninsolate machine
    - [ ] Restrict/Remove app execution
    - [x] Run antivirus scan
    - [ ] Offboard machine
    - [ ] Stop and quarantine file
  - Indicators
    - [ ] Submit indicator
    - [ ] List indicators
    - [ ] Delete indicator
  - Domain
    - [ ] Get domain related alerts
    - [ ] Get domain related machines
    - [ ] Get domain statistics
  - File
    - [ ] Get file information
    - [ ] Get file related alerts
    - [ ] Get file related machines
    - [ ] Get file statistics
  - IP
    - [ ] Get IP related alerts
    - [ ] Get IP statistics
  - User
    - [ ] Get user related alerts
    - [x] Get user related machines
- Code
  - [ ] Error Handling
    - [x] Basic Error Handling
    - [ ] Detailed Error Handling
  - [ ] Documentation
    - [x] Installation
    - [x] Build
    - [x] Setup/Use
    - [ ] Code comments
  - [ ] Reorganize project directory structure
- PowerShell Specific
  - [ ] Cmdlet help documents

## Project Dependencies

- **MSAL for .NET**
  - GitHub - [Link](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet)
  - Nuget - [Link](https://www.nuget.org/packages/Microsoft.Identity.Client)
- **Newtonsoft.Json**
  - GitHub - [Link](https://github.com/JamesNK/Newtonsoft.Json)
  - Nuget - [Link](https://www.nuget.org/packages/Newtonsoft.Json/)
  - Website - [Link](https://www.newtonsoft.com/json)