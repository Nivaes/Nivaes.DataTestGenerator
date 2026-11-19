# Nivaes.DataTestGenerator

Biblioteca .NET para generar datos aleatorios de prueba y demostración: contactos, contraseñas, identificadores fiscales españoles y valores básicos.

> Los valores son datos de prueba. No uses las contraseñas generadas como credenciales reales ni los identificadores generados como documentos válidos o asignados a una persona o entidad.

## Requisitos

- .NET 8.0 o posterior.

## Instalación

Instala el paquete principal:

```bash
dotnet add package Nivaes.DataTestGenerator
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

### Cadenas, enteros y números decimales

```csharp
string text = GenericGenerator.GenerateString();
string sizedText = GenericGenerator.GenerateString(20);
string rangedText = GenericGenerator.GenerateString(3, 20); // longitud entre 3 y 19

int anyInt = GenericGenerator.GenerateInt();
int rangedInt = GenericGenerator.GenerateInt(1, 100); // entre 1 y 99
double rangedDouble = GenericGenerator.GenerateDouble(0, 1);
```

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

