---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpFileAlerts

## SYNOPSIS
Get alerts related to a file identifier.

## SYNTAX

```
Get-DatpFileAlerts [-FileIdentifier] <String> [<CommonParameters>]
```

## DESCRIPTION
Get alerts seen in your organization related to a file's SHA1 hash.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpFileAlerts -FileIdentifier "eec6ebcbd8f725cfbd38240197f6b8e03d9d6139"
```

Getting alerts triggered by the SHA1 file hash of "eec6ebcbd8f725cfbd38240197f6b8e03d9d6139".

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

### MdatpPwsh.Models.Alert[]
## NOTES

SHA256 hashes are not supported in the 'FileIdentifier' parameter.

## RELATED LINKS
