---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpMachineAction

## SYNOPSIS
Get the status of an action performed on a machine.

## SYNTAX

### SingleActivity
```
Get-DatpMachineAction [[-ActivityId] <String>] [<CommonParameters>]
```

### AllActivities
```
Get-DatpMachineAction [-AllActivities] [<CommonParameters>]
```

## DESCRIPTION
Get the status and details about an action that was performed on a machine through Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpMachineAction -ActivityId "460e2875-7f91-4c32-8add-4a7b78f13254"
```

Get details of a specific action performed on a machine.

### Example 2
```powershell
PS C:\> Get-DatpMachineAction -AllActivities
```

Get all machine actions performed.

## PARAMETERS

### -ActivityId
The Activity ID for the action.

```yaml
Type: String
Parameter Sets: SingleActivity
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AllActivities
Get all activities created.

```yaml
Type: SwitchParameter
Parameter Sets: AllActivities
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### MdatpPwsh.Models.ActivityResponse

### MdatpPwsh.Models.ActivityResponse[]

## NOTES

## RELATED LINKS
