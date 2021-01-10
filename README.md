# EnumExamples
Design Patterns For Enums

### Reduce Multiple Branching
[AngleConversionCalculator](https://github.com/amuratgencay/EnumExamples/tree/master/EnumExamples.AngleConversionCalculator)
```
AngleTypeEnumeration.ConvertAngle(30, Degree, Radian);
AngleTypeEnumeration.ConvertAngle(0.5, Radian, Gradian);
```
### Compound Enums
[LocalizedMessage](https://github.com/amuratgencay/EnumExamples/tree/master/EnumExamples.LocalizedMessage)
```
Greeting.ToLocalizedMessage(Tr);
Farewell.ToLocalizedMessage(Fr);
```
### Hierarchical Enums
[CarFactory](https://github.com/amuratgencay/EnumExamples/tree/master/EnumExamples.CarFactory)
```
Brands.Opel.Corsa.Create();
Brands.Opel.Create(Astra);
```
### Multiple behaviours in flag enumerations
[Validation](https://github.com/amuratgencay/EnumExamples/tree/master/EnumExamples.Validation)
```
EMail.Validate("amuratgencay@gmail.com");
PhoneNumber.Validate("555");
```
