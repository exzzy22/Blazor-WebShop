using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property , AllowMultiple = false, Inherited = true)]
public class CollectionCount<T> : ValidationAttribute
{
    int count;
    public CollectionCount(string errorMessage, int itemsCount) : base(errorMessage)
    {
        count = itemsCount;
    }
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var list = value as IEnumerable<T>;

        if (list is null || list.Count() < 1)
            return new ValidationResult(ErrorMessage, new List<string> { validationContext.MemberName ?? "" });

        return ValidationResult.Success;
    }
}
