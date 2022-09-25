

public class MovieNameValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {

        if (value is MovieCreateModel model)
        {
            if (Regex.IsMatch(model.Title, @"^[ a-zA-Z0-9]+$")) return true;

            ErrorMessage = $"Movie Name Must Not Contain Other Simbols";

            return false;
        }

        ErrorMessage = $"Please Enter a Valid Movie Name";

        return false;
    }
}