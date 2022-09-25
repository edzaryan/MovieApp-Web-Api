

public class GenreNameValidationAttribute : ValidationAttribute
{

    public override bool IsValid(object? value)
    {

        if (value is GenreCreateModel model)
        {
            if (Regex.IsMatch(model.Name, @"^[ a-zA-Z]+$")) return true;

            ErrorMessage = $"Genre Name Must Contain Only Letters";

            return false;
        }

        ErrorMessage = $"Please Enter a Valid Genre Name";

        return false;
    }
}