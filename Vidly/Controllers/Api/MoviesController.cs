using AutoMapper;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using System.Linq;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

        //GET /api/movies --> vstavana konvencia
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }
    }
}
