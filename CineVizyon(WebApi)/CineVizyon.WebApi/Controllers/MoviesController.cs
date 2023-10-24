using CineVizyon.Business.Dtos;
using CineVizyon.Business.Services;
using CineVizyon.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CineVizyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        // Controller Service   --------- Service Manager'i kullanacak.
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieRequest request)
        {
            // Dto'ya ihtiyacımız var gidip AddMovieDto açıyoruz.

            var addMovieDto = new AddMovieDto()
            {
                Name = request.Name,
                Type = request.Type,
                Director = request.Director,
                UnitPrice = request.UnitPrice
            };
            var result = _movieService.AddMovie(addMovieDto);

            if (result)
                return Ok();
            else
                return StatusCode(500);


        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            var getMovieDtos = _movieService.GetMovies();
            var responce = getMovieDtos.Select(x => new GetMovieResponce
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Director = x.Director,
                UnitPrice = x.UnitPrice

            }).ToList();
            return Ok(responce);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var getMovieDtos = _movieService.GetMovieById(id);
            if (getMovieDtos is null)
                return NotFound();
            var responce = new GetMovieResponce()
            {
                Id = getMovieDtos.Id,
                Name = getMovieDtos.Name,
                Type = getMovieDtos.Type,
                Director = getMovieDtos.Director,
                UnitPrice = getMovieDtos.UnitPrice
            };
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _movieService.DeleteMovie(id);
            if (result == 0)
                return BadRequest();
            else if (result == 1)
                return Ok();
            else
                return StatusCode(500);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieRequest request)
        {
            var updateMovieDto = new UpdateMovieDto()
            {
                Id = id,
                Name = request.Name,
                Type = request.Type,
                Director = request.Director,
                UnitPrice = request.UnitPrice,
            };
            var result = _movieService.UpdateMovie(updateMovieDto);
            if (result == 0)
                return NotFound();
            else if (result == 1)
                return Ok();
            else
                return StatusCode(500);

        }
        [HttpPatch("{id}")]
        public IActionResult MakeDiscount(int id)
        {
            var result = _movieService.MakeDiscount(id);
            if (result == 0) return NotFound();
            else if (result == 1) return Ok();
            else
                return StatusCode(500);
        }
    }
}
