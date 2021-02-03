---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpAlert

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ListAlerts
```
Get-DatpAlert [[-AlertStatus] <AlertStatus>] [<CommonParameters>]
```

### GetAlert
```
Get-DatpAlert [[-AlertId] <String>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AlertId
{{ Fill AlertId Description }}

```yaml
Type: String
Parameter Sets: GetAlert
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertStatus
{{ Fill AlertStatus Description }}

```yaml
Type: AlertStatus
Parameter Sets: ListAlerts
Aliases:
Accepted values: InProgress, New, Resolved, Unknown

Required: False
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

### System.Object
## NOTES

## RELATED LINKS
