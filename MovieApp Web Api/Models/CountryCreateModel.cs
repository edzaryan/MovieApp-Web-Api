

[CountryNameValidation]
public class CountryCreateModel
{
    [Column(Order = 1)]
    [Required(ErrorMessage = "Please Enter Country {0}")]
    [StringLength(56, MinimumLength = 2, ErrorMessage = "Country {0} Length Must Be Between {2} to {1}")]
    public string? Name { get; set; }
}