

public class AllowedExtensionsValidationAttribute: ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedExtensionsValidationAttribute(string[] extensions) => _extensions = extensions;


    public override bool IsValid(object? value)
    {
        if (value is IFormFile model)
        {
            var extension = Path.GetExtension(model.FileName);

            if (!_extensions.Contains(extension.ToLower()))
            {
                ErrorMessage = "That extension is not allowed";

                return false;
            }

            return true;
        }

        ErrorMessage = $"Enter valid file";

        return false;
    }
}

