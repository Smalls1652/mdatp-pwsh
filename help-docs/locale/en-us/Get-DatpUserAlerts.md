---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpUserAlerts

## SYNOPSIS
Get alerts triggered by a user.

## SYNTAX

```
Get-DatpUserAlerts [-UserName] <String[]> [<CommonParameters>]
```

## DESCRIPTION
Get alerts triggered by a user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpUserAlerts -UserName "contoso\jwinger01"
```

Get all alerts that were triggered by a specific user.

## PARAMETERS

### -UserName
The username to search for.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### MdatpPwsh.Models.Alert
### MdatpPwsh.Models.Alert[]
## NOTES

## RELATED LINKS
