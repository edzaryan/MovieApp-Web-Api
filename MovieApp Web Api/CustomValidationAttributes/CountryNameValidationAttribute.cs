
public class CountryNameValidationAttribute : ValidationAttribute
{

    public override bool IsValid(object? value)
    {

        if (value is CountryCreateModel model)
        {
            if (Regex.IsMatch(model.Name, @"^[ a-zA-Z]+$")) return true;

            ErrorMessage = $"Country Name Must Contain Only Letters";

            return false;
        }

        ErrorMessage = $"Please Enter a Valid Country Name";

        return false;
    }
}
