

public class PersonPatchModel
{
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Person {0} Length Must Be Between {2} to {1}")]
    public string? FirstName { get; set; }


    [StringLength(20, MinimumLength = 2, ErrorMessage = "Person {0} Length Must Be Between {2} to {1}")]
    public string? LastName { get; set; }


    [Column(Order = 3)]
    [PersonBirthdayValidation]
    public string? Birthday { get; set; }


    [Column("Biography", Order = 4)]
    [StringLength(1500, MinimumLength = 500, ErrorMessage = "Person {0} Length Must Be Between {2} to {1}")]
    public string? Bio { get; set; }


    [Column(Order = 5)]
    [Range(120, 250, ErrorMessage = "Person {0} Must Be Between {1} to {2} cm")]
    public int? Height { get; set; }
}