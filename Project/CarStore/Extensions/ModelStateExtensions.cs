using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarStore.API.Extensions
{
    public static class ModelStateExtensions
    {
        // note: The `this` keyword in front of the parameter declaration tells the C# compiler to treat it as an extension method
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
