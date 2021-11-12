# DataTestGenerator

Randomly generate names of contacts, password, taxid, ... Useful for testing and demonstration.

## Content

### Contact generator

Generate contact information randomly.

``` C#
var contact = ContactGenerator.Instance.GenerateContact();

var sortName = contact.SortName;
var longName = contact.LongName;
var personalName = contact.PersonalName;
var familyName  = contact.FamilyName;
var email = contact.Email;
var telephoneNumber = contact.TelephoneNumber;
```

It allows to generate only one value of the contact.

``` C#
var name = ContactGenerator.Instance.GenerateName();
```

``` C#
var name = ContactGenerator.Instance.GenerateName();
```

[More documentation](./docs/contact-generator.md)

#### String generation

Generates a string of characters.

``` C#
var textString = GenericGenerator.Instance.GenerateString();
```

Generates a string of characters of a certain length.

``` C#
var textString = GenericGenerator.Instance.GenerateString(3, 20);
```

[More documentation](./docs/string-generator.md)

#### Password generation

Random password generation.

``` C#
var password = PasswordGenerator.Instance.GeneratePassword();
```

Generation of passwords randomly, of a certain length.

``` C#
var password = PasswordGenerator.Instance.GeneratePassword(leng);
```

Generation of passwords randomly, with a character set determizing

``` C#
var password = PasswordGenerator.Instance.GeneratePassword("BCDFGHJKLMNPQRSTUWXYZ");
```

## XUnit tool

Has extensions for xunit.

### Contact generator

Generación de contactos de forma aleatorio para una prueba unitaria.

``` C#
[Theory]
[GenerateContactInlineData(DataNumber = 3)]
public void ContactGeneratorExtenderContactTest(ContactTest contact)
{
    ...
}
```

### Password generator

Randomly generating password for a unit test.

``` C#
[Theory]
[InlineData("ddefff")]
[MemberData(nameof(PasswordsMatrixData))]
[GeneratePasswordInlineData(DataNumber = 3)]
public void PasswordGenerator03(string password)
{
    ...
}
```

### Packages

| NuGet Package | Latest Versions |
| --- | --- |
| [Nivaes.DataTestGenerator](https://www.nuget.org/packages/Nivaes.DataTestGenerator) <br /> Randomly generate | [![latest stable version](https://img.shields.io/nuget/v/Nivaes.DataTestGenerator.svg)](https://www.nuget.org/packages/Nivaes.DataTestGenerator) |
| [Nivaes.DataTestGenerator.XUnit](https://www.nuget.org/packages/Nivaes.DataTestGenerator.XUnit) <br /> Integration with xunit | [![latest prerelease version](https://img.shields.io/nuget/vpre/Nivaes.DataTestGenerator.XUnit.svg)](https://www.nuget.org/packages/Nivaes.DataTestGenerator.XUnit) | 

## Integration

![CI](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/CI/badge.svg)

![Build Release](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/Build%20Release/badge.svg)

![Publish Release](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/Publish%20Release/badge.svg)
