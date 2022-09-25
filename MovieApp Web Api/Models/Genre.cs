

[Index(nameof(Name), IsUnique=true)]
public class Genre : GenreCreateModel
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }

    public List<GenreMovie>? GenreMovies { get; set; } = new();
}