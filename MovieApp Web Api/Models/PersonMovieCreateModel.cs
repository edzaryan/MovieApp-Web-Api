

[PersonMovieValidation]
public class PersonMovieCreateModel
{
    [Column(Order = 3)]
    public bool? IsActor { get; set; } = null;


    [Column(Order = 4)]
    public bool? IsDirector { get; set; } = null;
}

