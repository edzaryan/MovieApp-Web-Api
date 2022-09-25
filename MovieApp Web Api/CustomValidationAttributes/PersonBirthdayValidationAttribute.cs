
public class PersonBirthdayValidationAttribute : ValidationAttribute
{
    private DateTime YearFrom { get; set; } = DateTime.Now.AddYears(-110);
    private DateTime YearTo { get; set; } = DateTime.Now.AddYears(-7);


    public override bool IsValid(object? value)
    {
        bool result = DateTime.TryParse((string?)value, out DateTime date);

        if (result)
        {
            if (date >= YearFrom && date <= YearTo) return true;

            ErrorMessage = $"Person Birth Day Must Be In Between {YearFrom.ToShortDateString()} And {YearTo.ToShortDateString()}";

            return false;
        }
                
        ErrorMessage = $"Please Enter a Valid Birth Date";

        return false;
    }
}

