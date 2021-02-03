---
external help file: MdatpPwsh.dll-Help.xml
Module Name: mdatp-pwsh
online version:
schema: 2.0.0
---

# Get-DatpUserMachines

## SYNOPSIS
Get machines a user has logged into.

## SYNTAX

```
Get-DatpUserMachines [-UserName] <String[]> [<CommonParameters>]
```

## DESCRIPTION
Get machines a user has logged into.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-DatpUserMachines -UserName "contoso\jwinger01"
```

Get all of the machines a specific user has logged into.

## PARAMETERS

### -UserName
The username to search for.

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

### MdatpPwsh.Models.Machine[]

## NOTES

## RELATED LINKS
