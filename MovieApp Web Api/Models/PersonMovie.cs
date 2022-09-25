

public class PersonMovie : PersonMovieCreateModel
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }


    [Column(Order = 1)]
    public int MovieId { get; set; }


    [Column(Order = 2)]
    public int PersonId { get; set; }


    public Movie Movie { get; set; }


    public Person Person { get; set; }

}