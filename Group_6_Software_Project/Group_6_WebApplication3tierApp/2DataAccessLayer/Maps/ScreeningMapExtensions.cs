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
    public static class ScreeningMapExtensions
    {
        public static ScreeningModel ToScreeningModel(this Screening src)
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

        public static Screening ToScreening(this ScreeningModel src, Screening dst = null)
        {
            if (dst == null)
            {
                dst = new Screening();
            }

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
