---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpMachineAlerts

## SYNOPSIS
Get alerts triggered by a machine.

## SYNTAX

```
Get-DatpMachineAlerts [-MachineId] <String[]> [<CommonParameters>]
```

## DESCRIPTION
Get alerts triggered by a machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpMachineAlerts -MachineId "comp-01.contoso.edu"
```

Get alerts triggered on a specific machine.

## PARAMETERS

### -MachineId
The ID or the FQDN of the machine.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String[]
## OUTPUTS

### MdatpPwsh.Models.Alert
### MdatpPwsh.Models.Alert[]
## NOTES

## RELATED LINKS
