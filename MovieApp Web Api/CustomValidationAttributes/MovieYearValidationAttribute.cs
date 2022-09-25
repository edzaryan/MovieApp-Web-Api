

public class MovieYearValidationAttribute : ValidationAttribute
{
    private int YearFrom { get; set; } = 1940;
    private int YearTo { get; set; } = DateTime.Now.Year;


    public override bool IsValid(object? value)
    {
        bool result = int.TryParse((string?)value, out int movieYear);

        if (result)
        {
            if (movieYear >= YearFrom && movieYear <= YearTo) return true;

            ErrorMessage = $"Movie Year Must Be In Between {YearFrom} And {YearTo}";

            return false;
        }

        ErrorMessage = $"Please Enter a Valid Movie Year";

        return false;
    }
}