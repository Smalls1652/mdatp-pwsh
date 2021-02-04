---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Start-DatpMachineScan

## SYNOPSIS
Start a scan on a machine.

## SYNTAX

```
Start-DatpMachineScan [-MachineId] <String[]> [[-ScanType] <String>] [-Comment] <String> [<CommonParameters>]
```

## DESCRIPTION
Start a quick or full scan on a machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> Start-DatpMachineScan -MachineId "comp-01.constoso.com" -ScanType Quick -Comment "Running quick scan on machine"
```

Start a quick scan on a machine.

### Example 2
```powershell
PS C:\> $scanAction = Start-DatpMachineScan -MachineId "comp-01.constoso.com" -ScanType Full -Comment "Running a full scan on machine"

PS C:\> $scanAction | Get-DatpMachineAction
```

Start a full scan on a machine and save the action object to a variable. Then use that action object as a pipeline input to 'Get-DatpMachineAction' to monitor the progress of the scan.

## PARAMETERS

### -Comment
A message explaining why the action must be done.

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

### -ScanType
The type of scan to perform.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Quick, Full

Required: False
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

### MdatpPwsh.Models.ActivityResponse

## NOTES

## RELATED LINKS
