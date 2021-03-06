---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Start-DatpInvestigationPkgCollection

## SYNOPSIS
Start the investigation package collection process on a machine.

## SYNTAX

```
Start-DatpInvestigationPkgCollection [-MachineId] <String[]> [-Comment] <String> [<CommonParameters>]
```

## DESCRIPTION
Start the investigation package collection process on a machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> Start-DatpInvestigationPkgCollection -MachineId "comp-01.contoso.com" -Comment "Collecting investigation package."
```

Start a package collection on a machine.

## PARAMETERS

### -Comment
A message explaining why the action must be done.

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

### MdatpPwsh.Models.ActivityResponse
## NOTES

## RELATED LINKS
