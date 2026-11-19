# Nivaes.DataTestGenerator.XUnit

Extensiones de datos para generar argumentos aleatorios en teorías de xUnit v3. Este paquete depende de `Nivaes.DataTestGenerator` y lo instala automáticamente como dependencia.

> Los valores son datos sintéticos para pruebas. No uses las contraseñas generadas como credenciales reales.

## Requisitos

- .NET 8.0 o posterior.
- xUnit v3.

## Instalación

Instala el paquete de extensiones en el proyecto de pruebas:

```bash
dotnet add package Nivaes.DataTestGenerator.XUnit
```

## Uso

Los atributos están en el espacio de nombres `Nivaes.DataTestGenerator.Xunit`. Úsalos con `[Theory]` de xUnit v3:

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

    [Theory]
    [GenerateDoubleInlineData(3, 0, 1)]
    public void Double_is_in_requested_range(double value)
    {
        Assert.InRange(value, 0, 1);
    }

    [Theory]
    [GenerateIntInlineData(3)]
    public void Integer_is_generated(int value)
    {
        Assert.InRange(value, 0, int.MaxValue);
    }
}
```

Los atributos disponibles son `GenerateContactInlineData`, `GeneratePasswordInlineData`, `GenerateStringInlineData`, `GenerateIntInlineData` y `GenerateDoubleInlineData`. Todos proporcionan datos generados para una teoría. Los atributos de contacto, contraseña, cadena y entero permiten indicar el número de casos; los de contraseña y cadena también permiten configurar la longitud, y el de cadena permite establecer un rango de longitudes. `GenerateDoubleInlineData` acepta `(minValue, maxValue)` o `(dataNumber, minValue, maxValue)`.

