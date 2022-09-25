

[Index(nameof(Title), nameof(Year), IsUnique = true)]
[MovieNameValidationAttribute]
public class Movie : MovieCreateModel
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }


    [Column("VideoDuration", Order = 4)]
    [Range(20, 240)]
    public double? Duration { get; set; }


    [Column("ImageUniqueName", Order = 5)]
    [StringLength(15, MinimumLength = 14)]
    public string? ImageName { get; set; }


    [Column("VideoUniqueName", Order = 6)]
    [StringLength(15, MinimumLength = 14)]
    public string? VideoName { get; set; }


    public List<PersonMovie>? PersonMovies { get; set; } = new();

    public List<GenreMovie>? GenreMovies { get; set; } = new();

    public List<CountryMovie>? CountryMovies { get; set; } = new();
}