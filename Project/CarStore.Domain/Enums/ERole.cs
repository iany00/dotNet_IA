using System.ComponentModel;

namespace CarStore.Domain.Enums
{
    public enum ERole
    {
        [Description("Employee")]
        Employee = 1,

        [Description("Customer")]
        Customer = 2
    }
}