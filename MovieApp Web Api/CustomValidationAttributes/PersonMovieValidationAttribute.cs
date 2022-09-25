

public class PersonMovieValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is PersonMovieCreateModel model)
        {
            if ((model.IsActor == null && model.IsDirector == null) || (model.IsActor != null && model.IsDirector != null))
                return false;
        }

        return true;
    }
}