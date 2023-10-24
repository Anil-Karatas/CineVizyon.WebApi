using CineVizyon.Business.Dtos;
using CineVizyon.Business.Services;
using CineVizyon.Data.Entities;
using CineVizyon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVizyon.Business.Managers
{
    public class MovieManager : IMovieService
    {
        private readonly IRepository<MovieEntity> _movieRepository;

        public MovieManager(IRepository<MovieEntity> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // Program.cs'e gidip Repository Kullanacagımızı bildirelim.
        public bool AddMovie(AddMovieDto addMovieDto)
        {
            var entity = new MovieEntity()
            {
                Name = addMovieDto.Name,
                Type = addMovieDto.Type,
                Director = addMovieDto.Director,
                UnitPrice = addMovieDto.UnitPrice
            };
            try
            {
                _movieRepository.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
            // Buradan MoviesController'e gidiyoruz.

        }

        public int DeleteMovie(int id)
        {
            var entity = _movieRepository.GetById(id);
            if (entity is null)
                return 0;
            try
            {
                _movieRepository.Delete(entity);
                return 1;
            }
            catch (Exception)
            {

                return -1;

            }
        }

        public GetMovieDto GetMovieById(int id)
        {
            var movieEntites = _movieRepository.GetById(id);

            if (movieEntites is null)
                return null;
            var movieDtos = new GetMovieDto()
            {
                Name = movieEntites.Name,
                Type = movieEntites.Type,
                Director = movieEntites.Director,
                UnitPrice = movieEntites.UnitPrice
            };
            return movieDtos;
        }

        public List<GetMovieDto> GetMovies()
        {
            var movieEntites = _movieRepository.GetAll();
            var movieDtos = movieEntites.Select(x => new GetMovieDto()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Director = x.Director,
                UnitPrice = x.UnitPrice
            }).ToList();
            return movieDtos;

        }

        public int MakeDiscount(int id)
        {
            var entity = _movieRepository.GetById(id);
            if (entity is null)
                return 0;
            if (entity.IsDiscounted)
            {
                entity.UnitPrice = entity.UnitPrice * 2;
            }
            else
            {
                entity.UnitPrice = entity.UnitPrice / 2;
            }
            entity.IsDiscounted = !entity.IsDiscounted;

            try
            {
                _movieRepository.Update(entity);
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            var entity = _movieRepository.GetById(updateMovieDto.Id);
            if (entity is null)
                return 0;
            entity.Name = updateMovieDto.Name;
            entity.Type = updateMovieDto.Type;
            entity.Director = updateMovieDto.Director;
            entity.UnitPrice = updateMovieDto.UnitPrice;

            try
            {
                _movieRepository.Update(entity);
                return 1;

            }
            catch (Exception)
            {

                return -1;
            }
        }
    }
}
