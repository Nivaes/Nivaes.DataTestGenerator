# Contact generator

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
