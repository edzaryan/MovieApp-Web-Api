

[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly AppDbContext _ctx;

    public CountryController(AppDbContext ctx) => this._ctx = ctx;


    [HttpGet("")]
    public async Task<IActionResult> GetCountriesAsync([FromQuery] string v)
    {
        var countryList = await _ctx.Countries.Where(g => g.Name.Contains(v)).ToListAsync();

        return countryList == null ? NotFound() : Ok(countryList);
    }


    [HttpGet("{id}/edit")]
    public async Task<IActionResult> GetCountryAsync([FromRoute] int countryId)
    {
        var country = await _ctx.Countries.FirstOrDefaultAsync(g => g.Id == countryId);

        return country == null ? NotFound() : Ok(country);
    }


    [HttpPost("")]
    public async Task<IActionResult> CreateCountryAsync([FromBody] CountryCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Country new_country = new()
        {
            Name = model.Name.Trim().RegulateSpaces().ToLower().Capitalize(),
        };

        await _ctx.Countries.AddAsync(new_country);
        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> EditCountryAsync([FromRoute] int countryId, CountryCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(model);

        var genre = await _ctx.Countries.FirstOrDefaultAsync(g => g.Id == countryId);

        if (genre == null) return NotFound();

        genre.Name = model.Name;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountryAsync([FromRoute] int countryId)
    {
        var country = await _ctx.Countries.FirstOrDefaultAsync(g => g.Id == countryId);

        if (country == null) return BadRequest();

        _ctx.Countries.Remove(country);

        await _ctx.SaveChangesAsync();

        return Ok();
    }

}