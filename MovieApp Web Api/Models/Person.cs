

[Index(nameof(FirstName), nameof(LastName), IsUnique=true)]
public class Person : PersonCreateModel
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }


    [Column(Order = 6)]
    [StringLength(15, MinimumLength = 14)]
    public string? ImageName { get; set; }


    public List<PersonMovie>? PersonMovies { get; set; } = new();
}