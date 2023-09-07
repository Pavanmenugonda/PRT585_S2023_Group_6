using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IMovieService
    {
        Task<MovieModel?> GetById(int MovieId);
        Task<List<MovieModel>> GetAll();

        Task<int> CreateMovie(MovieModel Movie);
        Task UpdateMovie(MovieModel Movie);
        Task DeleteMovie(int Movie);
    }
}
