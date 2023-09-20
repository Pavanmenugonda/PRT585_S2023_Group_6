using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Ticket
    {
        public int TicketID { get; set; } // int
        public int ScreeningID { get; set; } // int
        public int UserID { get; set; } // int
        public string SeatNumber { get; set; } // varchar(50)
        public decimal TicketPrice { get; set; } // decimal(18,2) 
        public DateTime PurchaseDate { get; set; } // datetime
        public bool IsDeleted { get; set; } // bit

    }
}
