namespace MovieApp_Web_Api.CustomValidationAttributes
{
    public class PersonNamesValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value is PersonCreateModel model)
            {
                if (Regex.IsMatch(model.FirstName, @"^[ a-zA-Z]+$") && Regex.IsMatch(model.LastName, @"^[ a-zA-Z]+$")) return true;

                ErrorMessage = $"Person Names Must Contain Only Letters";

                return false;
            }

            ErrorMessage = $"Please Enter a Valid Person Names";

            return false;
        }
    }
}
