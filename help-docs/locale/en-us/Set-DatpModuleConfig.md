---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Set-DatpModuleConfig

## SYNOPSIS
Set the configuration for the module to use for authentication.

## SYNTAX

```
Set-DatpModuleConfig [-PublicClientAppId] <String> [-TenantId] <String> [<CommonParameters>]
```

## DESCRIPTION
Set the configuration for the module to use for authentication. This will require information related to your Azure AD tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-DatpModuleConfig -PublicClientAppID "02f0f9c2-73a5-4952-895b-86e518c14dbf" -TenantId "e51020fe-9fbc-4a4b-9e8d-16dac9fcd6b4"
```

Set the module config to use the specified app and tenant ID for Azure AD.

## PARAMETERS

### -PublicClientAppId
The ClientID for the registered Azure AD app in your tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The ID for your Azure AD tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### MdatpPwsh.Models.Core.DatpModuleConfig
## NOTES

## RELATED LINKS
