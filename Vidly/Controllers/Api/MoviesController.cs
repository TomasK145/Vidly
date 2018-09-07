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
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            moviesQuery = moviesQuery.Where(m => m.NumberAvailable > 0);

            var movieDtos = moviesQuery.ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }
    }
}
