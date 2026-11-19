# Nivaes.DataTestGenerator

Biblioteca .NET para generar datos aleatorios de prueba y demostración: contactos, contraseñas, identificadores fiscales españoles y valores básicos. Incluye un paquete complementario para proporcionar datos generados a teorías de xUnit v3.

> Los valores son datos de prueba. No uses las contraseñas generadas como credenciales reales ni los identificadores generados como documentos válidos o asignados a una persona o entidad.

## Requisitos

- .NET 8.0 o posterior.
- Para las extensiones de pruebas: xUnit v3.

## Instalación

Instala el paquete principal:

```bash
dotnet add package Nivaes.DataTestGenerator
```

Para usar también los atributos de datos de xUnit v3:

```bash
dotnet add package Nivaes.DataTestGenerator.XUnit
```

## Uso

Los ejemplos usan el espacio de nombres `Nivaes.DataTestGenerator`.

### Contactos

```csharp
using Nivaes.DataTestGenerator;

ContactTest contact = ContactGenerator.GenerateContact();
Console.WriteLine(contact.LongName);
Console.WriteLine(contact.Email);
Console.WriteLine(contact.TelephoneNumber);

string name = ContactGenerator.GenerateName();
```

`ContactTest` también contiene `SortName`, `GivenName` y `FamilyName`. Para generar un contacto con un correo más distintivo, usa `ContactGenerator.GenerateExtenderContact()`.

Más información: [generador de contactos](docs/contact-generator.md).

### Cadenas, enteros y números decimales

```csharp
string text = GenericGenerator.GenerateString();
string sizedText = GenericGenerator.GenerateString(20);
string rangedText = GenericGenerator.GenerateString(3, 20); // longitud entre 3 y 19

int anyInt = GenericGenerator.GenerateInt();
int rangedInt = GenericGenerator.GenerateInt(1, 100); // entre 1 y 99
double rangedDouble = GenericGenerator.GenerateDouble(0, 1);
```

Más información: [generador de cadenas](docs/string-generator.md).

### Contraseñas

`PasswordGenerator` se usa mediante su propiedad `Instance`:

```csharp
PasswordGenerator generator = PasswordGenerator.Instance;

string password = generator.GeneratePassword();
string fixedLength = generator.GeneratePassword(16);
string customCharacters = generator.GeneratePassword(12, "ABCDEFGHJKLMNPQRSTUVWXYZ23456789");
```

Si no se indica una longitud, se genera una longitud aleatoria. El conjunto de caracteres predeterminado incluye varios grupos; al proporcionar una cadena como conjunto personalizado, los caracteres se eligen de esa cadena.

### Identificadores fiscales españoles

```csharp
string nif = TaxIdGenerator.GenerateNif();
string nie = TaxIdGenerator.GenerateNie();
string cif = TaxIdGenerator.GenerateCif();
string nifNie = TaxIdGenerator.GenerateNifNie();
string taxId = TaxIdGenerator.GenerateTaxId();
```

Estos métodos sirven para generar valores de prueba con formato y dígitos de control calculados; no garantizan que el identificador corresponda a una persona o entidad real.

## Datos aleatorios para xUnit v3

Con el paquete `Nivaes.DataTestGenerator.XUnit`, puedes añadir casos generados a métodos `[Theory]`. El espacio de nombres de los atributos es `Nivaes.DataTestGenerator.Xunit`:

```csharp
using Nivaes.DataTestGenerator;
using Nivaes.DataTestGenerator.Xunit;
using Xunit;

public class ContactTests
{
    [Theory]
    [GenerateContactInlineData(3)]
    public void Contact_has_email(ContactTest contact)
    {
        Assert.False(string.IsNullOrWhiteSpace(contact.Email));
    }

    [Theory]
    [GeneratePasswordInlineData(3, Length = 16)]
    public void Password_is_generated(string password)
    {
        Assert.Equal(16, password.Length);
    }

    [Theory]
    [GenerateStringInlineData(3, MinSize = 3, MaxSize = 20)]
    public void String_has_requested_length_range(string value)
    {
        Assert.InRange(value.Length, 3, 19);
    }
}
```

Los atributos disponibles son `GenerateContactInlineData`, `GeneratePasswordInlineData`, `GenerateStringInlineData`, `GenerateIntInlineData` y `GenerateDoubleInlineData`. Todos proporcionan datos generados para una teoría. Los atributos de contacto, contraseña, cadena y entero permiten indicar el número de casos; los de contraseña y cadena también permiten configurar la longitud, y el de cadena permite establecer un rango de longitudes. `GenerateDoubleInlineData` acepta `(minValue, maxValue)` o `(dataNumber, minValue, maxValue)`.

## Packages

| NuGet Package | Latest Versions |
| --- | --- |
| [Nivaes.DataTestGenerator](https://www.nuget.org/packages/Nivaes.DataTestGenerator) <br /> Randomly generate | [![latest stable version](https://img.shields.io/nuget/v/Nivaes.DataTestGenerator.svg)](https://www.nuget.org/packages/Nivaes.DataTestGenerator) |
| [Nivaes.DataTestGenerator.XUnit](https://www.nuget.org/packages/Nivaes.DataTestGenerator.XUnit) <br /> Integration with xunit | [![latest prerelease version](https://img.shields.io/nuget/vpre/Nivaes.DataTestGenerator.XUnit.svg)](https://www.nuget.org/packages/Nivaes.DataTestGenerator.XUnit) | 

## Integration

![CI](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/CI/badge.svg) [![codecov](https://codecov.io/gh/Nivaes/Nivaes.DataTestGenerator/graph/badge.svg?token=KF01604P3R)](https://codecov.io/gh/Nivaes/Nivaes.DataTestGenerator) ![Build Release](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/Build%20Release/badge.svg)
![Publis Release](https://github.com/Nivaes/Nivaes.DataTestGenerator/workflows/publis%20release/badge.svg)
