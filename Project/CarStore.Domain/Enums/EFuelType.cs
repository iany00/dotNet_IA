using System.ComponentModel;

namespace CarStore.Domain.Enums
{
    public enum EFuelType
    {
        [Description("Diesel")]
        Diesel = 1,
        [Description("Gazoline")]
        Gazoline = 2,
        [Description("Electricity")]
        Electricity = 3,
        [Description("Hybrid")]
        Hybrid = 4
    }
}
