---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpFileStats

## SYNOPSIS
Get the stats of a file.

## SYNTAX

```
Get-DatpFileStats [-FileIdentifier] <String> [<CommonParameters>]
```

## DESCRIPTION
Get stats on a file with how much it has been seen in your organization and worldwide.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpFileStats -FileIdentifier "eec6ebcbd8f725cfbd38240197f6b8e03d9d6139"
```

Get stats about a file with a SHA1 hash of 'eec6ebcbd8f725cfbd38240197f6b8e03d9d6139'.

## PARAMETERS

### -FileIdentifier
The SHA1 hash of the file.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### MdatpPwsh.Models.FileStats

## NOTES

SHA256 hashes are not supported in the 'FileIdentifier' parameter.

## RELATED LINKS
