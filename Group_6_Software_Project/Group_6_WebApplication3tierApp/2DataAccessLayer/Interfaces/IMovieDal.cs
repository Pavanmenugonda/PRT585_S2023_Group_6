using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IMovieDal
    {
        // Getters
        MovieModel? GetById(int MovieId);
        List<MovieModel> GetAll();

        // Actions
        int CreateMovie(MovieModel Movie);
        void UpdateMovie(MovieModel Movie);
        void DeleteMovie(int MovieId);
    }
}
