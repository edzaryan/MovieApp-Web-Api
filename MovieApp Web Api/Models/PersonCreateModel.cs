

[PersonNamesValidationAttribute]
public class PersonCreateModel : PersonPatchModel
{
    [Column(Order = 1)]
    [Required(ErrorMessage = "Please Enter Person {0}")]
    public new string? FirstName { get; set; }


    [Column(Order = 2)]
    [Required(ErrorMessage = "Please Enter Person {0}")]
    public new string? LastName { get; set; }
}