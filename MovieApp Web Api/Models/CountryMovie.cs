
public class CountryMovie
{
    [Column(Order = 0)]
    [Key]
    public int Id { get; set; }


    [Column(Order = 1)]
    public int CountryId { get; set; }


    public Country Country { get; set; }


    [Column(Order = 2)]
    public int MovieId { get; set; }


    public Movie Movie { get; set; }
}