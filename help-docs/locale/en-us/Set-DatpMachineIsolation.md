---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Set-DatpMachineIsolation

## SYNOPSIS
Set a machine to be isolated or to be released from isolation.

## SYNTAX

```
Set-DatpMachineIsolation [-MachineId] <String[]> [-Comment] <String> [-IsolationType] <String>
 [<CommonParameters>]
```

## DESCRIPTION
Set a machine to be isolated with a full or selective isolation or release a machine from isolation.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -IsolationType
The type of isolation to perform on the machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Full Isolation, Selective Isolation, Release Isolation

Required: True
Position: 2
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
