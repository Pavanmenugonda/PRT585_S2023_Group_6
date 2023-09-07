using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class MovieMapExtensions
    {
        public static MovieModel ToMovieModel(this Movie src)
        {
            var dst = new MovieModel();

            dst.MovieId = src.MovieId;
            dst.MovieName = src.MovieName;
            dst.Genre = src.Genre;
            dst.ReleaseDate = src.ReleaseDate;
            dst.Description = src.Description;
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }

        public static Movie ToMovie(this MovieModel src, Movie dst = null)
        {
            if (dst == null)
            {
                dst = new Movie();
            }

            dst.MovieId = src.MovieId;
            dst.MovieName = src.MovieName;
            dst.Genre = src.Genre;
            dst.ReleaseDate = src.ReleaseDate;
            dst.Description = src.Description;
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }
    }
}
