---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpFileMachines

## SYNOPSIS
Get machines that have seen a file.

## SYNTAX

```
Get-DatpFileMachines [-FileIdentifier] <String> [<CommonParameters>]
```

## DESCRIPTION
Get machines that have been registered to have seen a file's SHA1 hash.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpFileMachines -FileIdentifier "eec6ebcbd8f725cfbd38240197f6b8e03d9d6139"
```

Get machines that have seen the file with the SHA1 file hash of "eec6ebcbd8f725cfbd38240197f6b8e03d9d6139".

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

### MdatpPwsh.Models.Machine[]

## NOTES

SHA256 hashes are not supported in the 'FileIdentifier' parameter.

## RELATED LINKS
