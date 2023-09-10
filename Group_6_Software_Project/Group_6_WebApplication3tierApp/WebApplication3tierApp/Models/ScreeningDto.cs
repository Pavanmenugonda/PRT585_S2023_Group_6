using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class ScreeningDto
    {
        public int ScreeningId { get; set; } // int
        public int MovieID { get; set; } // int
        public DateTime Showtime { get; set; } // datetime
        public decimal Price { get; set; } // decimal(18,2) 
        public int AvailableSeats { get; set; } // int
        public bool IsDeleted { get; set; } // bit
    }

    public static class ScreeningDtoMapExtensions
    {
        public static ScreeningDto ToScreeningDto(this ScreeningModel src)
        {
            var dst = new ScreeningDto();
            dst.ScreeningId = src.ScreeningId;
            dst.MovieID = src.MovieID;
            dst.Showtime = src.Showtime;
            dst.Price = src.Price;
            dst.AvailableSeats = src.AvailableSeats;
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }

        public static ScreeningModel ToScreeningModel(this ScreeningDto src)
        {
            var dst = new ScreeningModel();
            dst.ScreeningId = src.ScreeningId;
            dst.MovieID = src.MovieID;
            dst.Showtime = src.Showtime;
            dst.Price = src.Price;
            dst.AvailableSeats = src.AvailableSeats;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }
    }
}
