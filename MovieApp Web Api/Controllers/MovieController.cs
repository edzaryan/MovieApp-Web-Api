

[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _ctx;
    private readonly IFileFunctions _fileFunctions;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MovieController(AppDbContext ctx, IFileFunctions fileFunctions, IWebHostEnvironment webHostEnvironment)
    {
        _ctx = ctx;
        _fileFunctions = fileFunctions;
        _webHostEnvironment = webHostEnvironment;
    }


    [HttpGet("")]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] MovieSearchModel model)
    {
        (double yearFrom, double yearTo) = model.GetBounds(model.Year);
        (double ratFrom, double ratTo) = model.GetBounds(model.Rating);
        (double durFrom, double durTo) = model.GetBounds(model.Duration);
        List<string> countryList = model.GetList(model.Countries);
        List<string> genreList = model.GetList(model.Genres);

        var movies = await _ctx.Movies
                .OrderBy(m => m.Year)
                .Skip((model.Page - 1) * 30)
                .Take(30)
                .Where(m =>
                    m.Title.Contains(model.v) &&
                    (m.Year >= yearFrom && m.Year <= yearTo) &&
                    (m.Duration >= durFrom && m.Duration <= durTo) &&
                    m.CountryMovies.All(cm => countryList.Contains(cm.Country.Name)) &&
                    m.GenreMovies.All(gm => genreList.Contains(gm.Genre.Name))
                )
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    m.ImageName,
                    m.Year
                })
                .ToListAsync();

        return movies == null ? NotFound() : Ok(movies);
    }


    [HttpGet("{movieId}/edit")]
    public async Task<IActionResult> GetMovieAsync([FromRoute] int movieId)
    {
        var movie = await _ctx.Movies
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    m.Year,
                    m.Description,
                    m.Duration,
                    m.ImageName,
                    m.VideoName,
                    Countries = m.CountryMovies
                                    .OrderBy(cm => cm.Country.Name)
                                    .Select(cm => new
                                    {
                                        cm.Country.Id,
                                        cm.Country.Name,
                                    }),
                    Genres = m.GenreMovies
                                    .OrderBy(gm => gm.Genre.Name)
                                    .Select(gm => new
                                    {
                                        gm.Genre.Id,
                                        gm.Genre.Name
                                    }),
                    Director = m.PersonMovies
                                    .Where(pm => pm.IsDirector != null)
                                    .OrderBy(pm => (pm.Person.FirstName + pm.Person.LastName))
                                    .Select(pm => new
                                    {
                                        pm.Person.Id,
                                        pm.Person.FirstName,
                                        pm.Person.LastName,
                                        pm.Person.ImageName
                                    }),
                    Actors = m.PersonMovies
                                    .Where(pm => pm.IsActor != null)
                                    .OrderBy(pm => (pm.Person.FirstName + pm.Person.LastName))
                                    .Select(pm => new
                                    {
                                        pm.Person.Id,
                                        pm.Person.FirstName,
                                        pm.Person.LastName,
                                        pm.Person.ImageName
                                    })
                }).FirstOrDefaultAsync(m => m.Id == movieId);

        return movie == null ? NotFound() : Ok(movie);
    }


    [HttpPost("")]
    public async Task<IActionResult> CreateMovieAsync([FromBody] MovieCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(model);

        Movie new_movie = new()
        {
            Title = model.Title.RegulateSpaces().Trim().Capitalize(),
            Year = model.Year,
            Description = model.Description,
        };

        await _ctx.Movies.AddAsync(new_movie);
        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPatch("{movieId}/edit")]
    public async Task<IActionResult> EditMoviePatchAsync([FromRoute] int movieId, [FromBody] JsonPatchDocument<MoviePatchModel> patchModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null) return NotFound();

        patchModel.ApplyTo(movie, ModelState);

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{movieId}/image/edit")]
    public async Task<IActionResult> EditMovieImageAsync([FromRoute] int movieId, [FromForm] MovieImageEditModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null || movie.ImageName != null) return BadRequest();

        string uniqueImageName = _fileFunctions.UpdateFile(file: model.UploadedImageFile, imageName: movie.ImageName, folderName: "image");

        movie.ImageName = uniqueImageName;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{movieId}/image")]
    public async Task<IActionResult> DeleteMovieImageAsync([FromRoute] int movieId)
    {
        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null || movie.ImageName == null) return BadRequest();

        _fileFunctions.DeleteFile(fileName: movie.ImageName, folderName: "image");

        movie.ImageName = null;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{movieId}/video/edit")]
    [RequestFormLimits(MultipartBodyLengthLimit = 4294967296)]
    [RequestSizeLimit(4294967296)]
    public async Task<IActionResult> UploadMovieVideoAsync([FromRoute] int movieId, [FromForm] MovieVideoUploadModel videoFile)
    {
        if (!ModelState.IsValid) return BadRequest();

        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null || movie.VideoName != null) return BadRequest();

        string uniqueFileName = _fileFunctions.UploadVideoFile(videoFile.UploadedVideoFile, "video");

        int videoFileDurationInMinutes = _fileFunctions.GetVideoFileDurationInMinutes(uniqueFileName, "video");

        movie.VideoName = uniqueFileName;
        movie.Duration = videoFileDurationInMinutes;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{movieId}/video")]
    public async Task<IActionResult> DeleteMovieVideoAsync([FromRoute] int movieId)
    {
        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null || movie.VideoName == null) return BadRequest();

        _fileFunctions.DeleteFile(fileName: movie.VideoName, folderName: "video");

        movie.VideoName = null;

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete("{movieId}")]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] int movieId)
    {
        var movie = await _ctx.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null) return BadRequest();

        _fileFunctions.DeleteFile(fileName: movie.ImageName, folderName: "image");
        _fileFunctions.DeleteFile(fileName: movie.VideoName, folderName: "video");

        _ctx.Movies.Remove(movie);

        await _ctx.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("{movieId}/genre/{genreId}/edit")]
    public async Task<IActionResult> EditMovieGenreAsync([FromRoute] int movieId, [FromRoute] int genreId, [FromBody] bool val)
    {
        var genreMovie = await _ctx.GenreMovies.FirstOrDefaultAsync(gm => gm.GenreId == genreId && gm.MovieId == movieId);

        if (genreMovie == null) return BadRequest();

        if (val) 
            await _ctx.GenreMovies.AddAsync(new() { MovieId = movieId, GenreId = genreId });
        else 
            _ctx.GenreMovies.Remove(genreMovie);

        await _ctx.SaveChangesAsync();
        return Ok();
    }


    [HttpPut("{movieId}/country/{countryId}/edit")]
    public async Task<IActionResult> EditMovieCountryAsync([FromRoute] int movieId, [FromRoute] int countryId, [FromBody] bool val)
    {
        var countryMovie = await _ctx.CountryMovies.FirstOrDefaultAsync(gm => gm.CountryId == countryId && gm.MovieId == movieId);

        if (countryMovie == null) return BadRequest();

        if (val)
            await _ctx.CountryMovies.AddAsync(new() { MovieId = movieId, CountryId = countryId });
        else
            _ctx.CountryMovies.Remove(countryMovie);

        await _ctx.SaveChangesAsync();
        return Ok();
    }


    [HttpPatch("{movieId}/actor/{personId}/edit")]
    public async Task<IActionResult> EditMoviePersonAsync([FromRoute] int movieId, [FromRoute] int personId, [FromBody] PersonMovieCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var personMovie = await _ctx.PersonMovies.FirstOrDefaultAsync(pm => pm.MovieId == movieId && pm.PersonId == personId);

        if (personMovie == null)
        {
            personMovie = new PersonMovie { PersonId = personId, MovieId = movieId };

            await _ctx.AddAsync(personMovie);
        }

        if (model.IsActor != null) 
            personMovie.IsActor = model.IsActor;
        else 
            personMovie.IsDirector = model.IsDirector;

        if (personMovie.IsActor == false && personMovie.IsDirector == false) _ctx.Remove(personMovie);

        await _ctx.SaveChangesAsync();

        return Ok();
    }

}
