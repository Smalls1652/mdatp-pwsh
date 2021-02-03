---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpMachine

## SYNOPSIS
Get a machine from Defender for Endpoint.

## SYNTAX

### SingleMachine
```
Get-DatpMachine [[-MachineId] <String[]>] [<CommonParameters>]
```

### AllMachines
```
Get-DatpMachine [-AllMachines] [<CommonParameters>]
```

## DESCRIPTION
Get a machine or all machines that have been onboarded to Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AllMachines
Get all machines.

```yaml
Type: SwitchParameter
Parameter Sets: AllMachines
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineId
The ID or the FQDN of the machine.

```yaml
Type: String[]
Parameter Sets: SingleMachine
Aliases:

Required: False
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

### System.Object
## NOTES

## RELATED LINKS
