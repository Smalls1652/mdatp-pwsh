---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpFile

## SYNOPSIS
Get a file seen by Defender for Endpoint.

## SYNTAX

```
Get-DatpFile [-FileIdentifier] <String[]> [<CommonParameters>]
```

## DESCRIPTION
Get information about a file that has been by Defender for Endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpFile -FileIdentifier "36A4CC191027E30EC32618FF454F33B87F5C46A765C6AC3F151165AD7508DCD2"
```

Get information about a file with a SHA256 hash of '36A4CC191027E30EC32618FF454F33B87F5C46A765C6AC3F151165AD7508DCD2'.

## PARAMETERS

### -FileIdentifier
The SHA1 or SHA256 hash of the file.

```yaml
Type: String[]
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

### MdatpPwsh.Models.FileProperties
## NOTES

## RELATED LINKS
