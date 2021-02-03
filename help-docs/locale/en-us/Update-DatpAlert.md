---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Update-DatpAlert

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
Update-DatpAlert [-AlertId] <String> [-Status] <AlertStatus> [-AssignedTo] <String>
 [-Classification] <AlertClassification> [-Determination] <AlertDetermination> [-Comment] <String>
 [<CommonParameters>]
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
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedTo
{{ Fill AssignedTo Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Classification
{{ Fill Classification Description }}

```yaml
Type: AlertClassification
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, FalsePositive, TruePositive

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
{{ Fill Comment Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Determination
{{ Fill Determination Description }}

```yaml
Type: AlertDetermination
Parameter Sets: (All)
Aliases:
Accepted values: NotAvailable, Apt, Malware, SecurityPersonnel, SecurityTesting, UnwantedSoftware, Other

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
{{ Fill Status Description }}

```yaml
Type: AlertStatus
Parameter Sets: (All)
Aliases:
Accepted values: InProgress, New, Resolved, Unknown

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

### System.Object
## NOTES

## RELATED LINKS
