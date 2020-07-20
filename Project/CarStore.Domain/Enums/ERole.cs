using System.ComponentModel;

namespace CarStore.Domain.Enums
{
    public enum ERole
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Employee")]
        Employee = 2,
        [Description("Customer")]
        Customer = 2
    }
}