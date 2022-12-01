using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class Password : ValidationAttribute
{
    public string ValueEmptyErrorMessage = "Password is required";
    public string CharLowerErrorMessage = "Passwords must have at least one lowercase";
    public string CharUpperErrorMessage = "Passwords must have at least one uppercase";
    public string CharIsDigitErrorMessage = "Passwords must have at least one number";
    public string TooShortErrorMessage = "Passwords must be at least 8 characters";

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult(ValueEmptyErrorMessage);

        string password = (string)value;

        StringBuilder sb = new ();

        if (!password.Any(char.IsLower))
        {
            sb = AddToMessage(sb, CharLowerErrorMessage);
        }
        if (!password.Any(char.IsUpper))
        {
            sb = AddToMessage(sb, CharUpperErrorMessage);
        }
        if (!password.Any(char.IsDigit))
        {
            sb = AddToMessage(sb, CharIsDigitErrorMessage);
        }
        if (password.Length < 8)
        {
            sb = AddToMessage(sb, TooShortErrorMessage);
        }

        Console.WriteLine(sb.ToString());

        if (sb.Length != 0)
            return new ValidationResult(sb.ToString());
        else
            return ValidationResult.Success;
    }

    private static StringBuilder AddToMessage(StringBuilder builder, string message)
    {
        if (builder.Length == 0)
        {
            builder.Append(message);
            return builder;
        }

        builder.AppendLine();
        builder.Append(message);

        return builder;
    }
}
