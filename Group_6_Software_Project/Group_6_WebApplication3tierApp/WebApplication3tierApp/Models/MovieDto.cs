using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class MovieDto
    {
        public int MovieId { get; set; } // int
        public string MovieName { get; set; } // nvarchar(400)
        public string? Genre { get; set; } // nvarchar(30)
        public DateTime? ReleaseDate { get; set; }
        public string? Description { set; get; } // nvarvarchar(400)
        public bool IsDeleted { get; set; } // bit
    }

    public static class MovieDtoMapExtensions
    {
        public static MovieDto ToMovieDto(this MovieModel src)
        {
            var dst = new MovieDto();
            dst.MovieId = src.MovieId;
            dst.MovieName = src.MovieName;
            dst.Genre = src.Genre;
            dst.ReleaseDate = src.ReleaseDate;
            dst.Description = src.Description;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }

        public static MovieModel ToMovieModel(this MovieDto src)
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
    }
}
