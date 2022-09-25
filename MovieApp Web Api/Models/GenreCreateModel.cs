

[GenreNameValidation]
public class GenreCreateModel
{
    [Column(Order = 1)]
    [Required(ErrorMessage = "Please Enter Genre {0}")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Genre {0} Length Must Be Between {2} to {1}")]
    [GenreNameValidationAttribute]
    public string? Name { get; set; }
}