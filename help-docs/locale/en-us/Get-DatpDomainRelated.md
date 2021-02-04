---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpDomainRelated

## SYNOPSIS
Get machines or alerts that have interacted with a web domain.

## SYNTAX

```
Get-DatpDomainRelated [-DomainName] <String> [[-Type] <String>] [<CommonParameters>]
```

## DESCRIPTION
Get machines or alerts that have interacted with a web domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpDomainRelated -DomainName "www.reddit.com" -Type Machines
```

Get all machines that have made contact with 'www.reddit.com'.

## PARAMETERS

### -DomainName
The web domain name to search for.

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

### -Type
The type of objects to return.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Alerts, Machines

Required: False
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

### MdatpPwsh.Models.Machine[]

## NOTES

## RELATED LINKS
