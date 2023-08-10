using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApiDotNet6.Data;
using MovieApiDotNet6.Data.Dtos;
using MovieApiDotNet6.Models;

namespace MovieApiDotNet6.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;
    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody]CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), 
            new {id = movie.Id},
            movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0,
        [FromQuery] int take = 25)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies
            .FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, 
        [FromBody]UpdateMovieDto updatedMovieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        _mapper.Map(updatedMovieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMovie(int id,
        JsonPatchDocument<UpdateMovieDto> patchDocument)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if ( movie == null) return NotFound();

        var movieToBeUpdated = _mapper.Map<UpdateMovieDto>(movie);

        patchDocument.ApplyTo(movieToBeUpdated, ModelState);

        if (!TryValidateModel(movieToBeUpdated))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToBeUpdated, movie);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }

}
