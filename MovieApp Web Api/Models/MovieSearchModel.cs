
public class MovieSearchModel
{
    public string v { get; set; } = "";

    public string Duration { get; set; } = "0-250";

    public string Year { get; set; } = "1950-2022";

    public string Rating { get; set; } = "1-10";

    public string Popularity { get; set; } = "1-10";

    public string Countries { get; set; } = "usa";

    public string Genres { get; set; } = "drama,action";

    public int Page { get; set; } = 1;


    public (double from, double until) GetBounds(string str)
    {
        var bounds = str.Split('-').Select(double.Parse).ToArray();

        return (bounds[0], bounds[1]);
    }


    public List<string> GetList(string str)
    {
        return str.Split(',').ToList();
    }
}