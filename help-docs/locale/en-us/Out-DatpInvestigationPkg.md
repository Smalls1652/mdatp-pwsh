---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Out-DatpInvestigationPkg

## SYNOPSIS
Save an investigation package.

## SYNTAX

```
Out-DatpInvestigationPkg [-ActivityId] <String> [-FolderPath] <DirectoryInfo> [<CommonParameters>]
```

## DESCRIPTION
Save an investigation package that has been collected through Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> $pkgCollection = Start-DatpInvestigationPkgCollection -MachineId "comp-01.contoso.com" -Comment "Collecting investigation package."

PS C:\> Out-DatpInvestigationPkg -ActivityId $pkgCollection.ActivityId -FolderPath ".\"
```

Start a package collection on a machine and then save it to your local machine.

## PARAMETERS

### -ActivityId
The Activity ID for the "Collect investigation package" action.

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

### -FolderPath
The folder path to save the package to.

```yaml
Type: DirectoryInfo
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

### None
## OUTPUTS

### System.IO.FileInfo
## NOTES

## RELATED LINKS
