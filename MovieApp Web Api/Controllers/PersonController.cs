

[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly AppDbContext _ctx;
    private readonly IFileFunctions fileFunctions;

    public PersonController(AppDbContext ctx, IFileFunctions fileFunctions)
    {
        this._ctx = ctx;
        this.fileFunctions = fileFunctions;
    }


    [HttpGet("")]
    public async Task<IActionResult> GetPeopleAsync([FromQuery] string v = "A", [FromQuery] int page = 1)
    {
        var personList = await _ctx.People
                            .Where(p => v.Length > 1 ? (p.FirstName + p.LastName).Contains(v) : p.FirstName.StartsWith(v))
                            .Skip((page - 1) * 30)
                            .Take(30)
                            .ToListAsync();

        return personList == null ? NotFound() : Ok(personList);
    }


    [HttpGet("{personId}/edit")]
    public async Task<IActionResult> GetPersonAsync([FromRoute] int personId)
    {
        var person = await _ctx.People
                        .Where(p => p.Id == personId)
                        .Select(p => new
                        {
                            p.FirstName,
                            p.LastName,
                            p.Birthday,
                            p.ImageName,
                            p.Bio,
                            p.Height,
                            Movies = p.PersonMovies
                                        .Where(pm => pm.IsActor != null)
                                        .Select(pm => new
                                        {
                                            pm.Movie.Id,
                                            pm.Movie.ImageName,
                                            pm.Movie.Title,
                                            pm.Movie.Year
                                        })
                        }).FirstOrDefaultAsync();

        return person == null ? NotFound() : Ok(person);
    }


    [HttpPost("")]
    public async Task<IActionResult> CreatePersonAsync([FromBody] PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Person new_person = new()
        {
            FirstName = model.FirstName.Trim().RegulateSpaces().ToLower().Capitalize(),
            LastName = model.LastName.Trim().RegulateSpaces().ToLower().Capitalize(),
            Bio = model.Bio,
            Birthday = model.Birthday,
            Height = model.Height,
        };

        await _ctx.People.AddAsync(new_person);
        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPatch("{personId}/edit")]
    public async Task<IActionResult> EditPersonPatchAsync([FromRoute] int personId, [FromBody] JsonPatchDocument<PersonPatchModel> patchModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var person = await _ctx.People.FirstOrDefaultAsync(p => p.Id == personId);

        if (person == null) return NotFound();

        patchModel.ApplyTo(person, ModelState);

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{personId}/image/edit")]
    public async Task<IActionResult> EditPersonImageAsync([FromRoute] int personId, [FromForm] MovieImageEditModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == personId);

        if (movie == null) return NotFound();

        string uniqueImageName = fileFunctions.UpdateFile(model.UploadedImageFile, movie.ImageName, "image");

        movie.ImageName = uniqueImageName;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{personId}/image")]
    public async Task<IActionResult> DeletePersonImageAsync([FromRoute] int personId)
    {
        var person = await _ctx.People.FirstOrDefaultAsync(m => m.Id == personId);

        if (person == null) return NotFound();

        fileFunctions.DeleteFile(person.ImageName, "image");

        person.ImageName = null;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{personId}")]
    public async Task<IActionResult> DeletePersonAsync([FromRoute] int personId)
    {
        var person = await _ctx.People.FirstOrDefaultAsync(p => p.Id == personId);

        if (person == null) return NotFound();

        _ctx.People.Remove(person);

        await _ctx.SaveChangesAsync();

        return Ok();
    }

}
