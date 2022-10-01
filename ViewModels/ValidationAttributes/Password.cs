using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class Password : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        string password = (string)value;

        if (password.Any(char.IsLower) &&
            password.Any(char.IsUpper) &&
            password.Any(char.IsDigit) &&
            password.Length > 7)
        { 
            return true;
        }
        else
            return false;
    }
}
