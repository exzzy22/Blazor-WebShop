using System.ComponentModel.DataAnnotations;

namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ProductImages : ValidationAttribute
{
    string errorMessage = "";
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        IEnumerable<PictureForCreationVM> list = value as IEnumerable<PictureForCreationVM>;

        if (list is null || list.Count() < 1 || !list.Any(i => i.MainImage))
        {
            if (list is null || list.Count() < 1)
                errorMessage = "Image is required";

            else if(!list.Any(i => i.MainImage))
                errorMessage = "Set one image as main image";

            return new ValidationResult(errorMessage, new List<string> { validationContext.MemberName ?? "" });
        }

        return ValidationResult.Success;
    }
}
