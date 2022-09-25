

[MovieNameValidation]
[MovieYearValidation]
public class MovieCreateModel : MoviePatchModel
{
    [Column(Order = 1)]
    [Required(ErrorMessage = "Please Enter Movie {0}")]
    public new string? Title { get; set; }


    [Column(Order = 2)]
    [Required(ErrorMessage = "Please Enter Movie {0}")]
    public new int? Year { get; set; }


    [Column(Order = 3)]
    [Required(ErrorMessage = "Please Enter Movie {0}")]
    public new string? Description { get; set; }
}