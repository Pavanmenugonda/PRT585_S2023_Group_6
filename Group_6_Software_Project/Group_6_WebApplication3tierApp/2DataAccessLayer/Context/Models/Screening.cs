using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; } // int
        public int MovieID { get; set; } // int
        public DateTime Showtime { get; set; } // datetime
        public decimal Price { get; set; } // decimal(18,2) 
        public int AvailableSeats { get; set; } // int
        public bool IsDeleted { get; set; } // bit
    }

}