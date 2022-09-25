
public class MoviePatchModel
{
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Movie {0} Length Must Be Between {2} to {1}")]
    public string? Title { get; set; }


    [MovieYearValidationAttribute]
    public int? Year { get; set; }


    [StringLength(1500, MinimumLength = 250, ErrorMessage = "Person {0} Length Must Be Between {2} to {1}")]
    public string? Description { get; set; }
}