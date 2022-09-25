
public class GenreMovie
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }


    [Column(Order = 1)]
    public int GenreId { get; set; }


    public Genre Genre { get; set; }


    [Column(Order = 2)]
    public int MovieId { get; set; }


    public Movie Movie { get; set; }
}