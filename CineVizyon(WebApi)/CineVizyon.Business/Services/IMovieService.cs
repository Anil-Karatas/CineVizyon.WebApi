using CineVizyon.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVizyon.Business.Services
{
    public interface IMovieService
    {
        bool AddMovie(AddMovieDto addMovieDto);  // buradan Managere geçiyoruz.

        List<GetMovieDto> GetMovies();
        GetMovieDto GetMovieById(int id);
        int DeleteMovie(int id);
        int UpdateMovie(UpdateMovieDto updateMovieDto);
        int MakeDiscount(int id);


    }
}
