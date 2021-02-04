---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Update-DatpAlert

## SYNOPSIS
Update an alert.

## SYNTAX

```
Update-DatpAlert [-AlertId] <String> [-Status] <AlertStatus> [-AssignedTo] <String>
 [-Classification] <AlertClassification> [-Determination] <AlertDetermination> [-Comment] <String>
 [<CommonParameters>]
```

## DESCRIPTION
Update an alert with details in Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> $alert = Get-DatpAlert -AlertId "da123456789123456_1234567890"

PS C:\> $alert | Update-DatpAlert -Status Resolved -AssignedTo "bperry@contoso.com" -Classification FalsePositive -Determination Other -Comment "Blaming A Bridge Collapse On A School Is Like Me Blaming Owls For How Much I Suck At Analogies."
```

Get an alert and pipe it into 'Update-DatpAlert' to set the status to resolved, assign it to 'bperry@contoso.com', classify it as a false positive, set the determination to other, and add a comment to the alert.

## PARAMETERS

### -AlertId
The ID of the alert.

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
The UserPrincipalName (UPN) of the security personnel assigned to the alert.

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
The classification of the alert.

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
A message describing why the alert was updated.

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
The determination reason for why an alert was updated.

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
The status of the alert.

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
