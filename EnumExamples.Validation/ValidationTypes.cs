using System;

namespace EnumExamples.Validation
{
   
    [Flags]
    public enum ValidationTypes
    {
        StringEmpty = 1,
        EMail = StringEmpty | 2,
        PhoneNumber = StringEmpty | 4,
        Numeric = StringEmpty | 8
    }
}