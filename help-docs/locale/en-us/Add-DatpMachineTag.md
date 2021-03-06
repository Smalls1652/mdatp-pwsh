---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Add-DatpMachineTag

## SYNOPSIS
Add a tag to a machine.

## SYNTAX

```
Add-DatpMachineTag [-MachineId] <String[]> [-TagName] <String> [<CommonParameters>]
```

## DESCRIPTION
Add a tag to a machine in Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> Add-DatpMachineTag -MachineId "comp-01.contoso.com" -TagName "TestTag-01"
```

Add a tag to the machine 'comp-01.contoso.com' with the name 'TestTag-01'.

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
The name of the tag to add.

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

### MdatpPwsh.Models.Machine
## NOTES

## RELATED LINKS
