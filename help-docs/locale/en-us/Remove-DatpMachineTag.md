---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Remove-DatpMachineTag

## SYNOPSIS
Remove a tag from a machine.

## SYNTAX

```
Remove-DatpMachineTag [-MachineId] <String[]> [-TagName] <String> [<CommonParameters>]
```

## DESCRIPTION
Remove a tag from a machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -TagName
The name of the tag to remove.

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

### System.String[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
