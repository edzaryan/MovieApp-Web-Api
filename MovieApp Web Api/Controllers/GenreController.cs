

[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly AppDbContext _ctx;

    public GenreController(AppDbContext ctx) => this._ctx = ctx;


    [HttpGet("")]
    public async Task<IActionResult> GetGenresAsync([FromQuery] string v)
    {
        var genreList = await _ctx.Genres.Where(g => g.Name.Contains(v)).Select(g => new
        {
            g.Id,
            g.Name,
        }).ToListAsync();

        return genreList == null ? NotFound() : Ok(genreList);
    }


    [HttpGet("{id}/edit")]
    public async Task<IActionResult> GetGenreAsync([FromRoute] int genreId)
    {
        var genre = await _ctx.Genres.Where(g => g.Id == genreId).ToListAsync();

        throw new Exception("Edgar Exception");

        return genre == null ? NotFound() : Ok(genre);
    }


    [HttpPost("")]
    public async Task<IActionResult> CreateGenreAsync([FromBody] GenreCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Genre new_genre = new()
        {
            Name = model.Name.RegulateSpaces().Trim().ToLower().Capitalize(),
        };

        await _ctx.Genres.AddAsync(new_genre);
        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> EditGenreAsync([FromRoute] int genreId, GenreCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var genre = await _ctx.Genres.FirstOrDefaultAsync(g => g.Id == genreId);

        if (genre == null) return NotFound();

        genre.Name = model.Name;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenreAsync([FromRoute] int genreId)
    {
        var genre = await _ctx.Genres.FirstOrDefaultAsync(g => g.Id == genreId);

        if (genre == null) return BadRequest();

        _ctx.Genres.Remove(genre);

        await _ctx.SaveChangesAsync();

        return Ok();
    }

}
