

[Index(nameof(Name), IsUnique=true)]
public class Country : CountryCreateModel
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }

    public List<CountryMovie>? CountryMovies { get; set; } = new();
}