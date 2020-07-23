using System.ComponentModel;

namespace CarStore.Domain.Enums
{
    public enum ECurrency
    {
        [Description ("Romanian Leu")]
        RON = 1,
        [Description("Euro")]
        EURO = 2,
        [Description("United States Dollars")]
        Dollars = 3
    }
}
