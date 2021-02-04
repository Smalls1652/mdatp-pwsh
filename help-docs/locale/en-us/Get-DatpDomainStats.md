---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpDomainStats

## SYNOPSIS
Get the stats of a domain in Defender for Endpoint.

## SYNTAX

```
Get-DatpDomainStats [-DomainName] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the stats of a domain in Defender for Endpoint with how often it has been seen in your organization and worldwide.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpDomainStats -DomainName "www.reddit.com"
```

Get the stats of how prevalent 'www.reddit.com' is.

## PARAMETERS

### -DomainName
The domain name to get stats for.

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

### MdatpPwsh.Models.DomainStats
## NOTES

## RELATED LINKS
