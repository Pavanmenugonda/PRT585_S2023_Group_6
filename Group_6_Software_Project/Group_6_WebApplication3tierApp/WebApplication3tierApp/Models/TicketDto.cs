using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class TicketDto
    {
        public int TicketID { get; set; } // int
        public int ScreeningID { get; set; } // int
        public int UserID { get; set; } // int
        public string SeatNumber { get; set; } // varchar(50)
        public decimal TicketPrice { get; set; } // decimal(18,2) 
        public DateTime PurchaseDate { get; set; } // datetime

        public bool IsDeleted { get; set; } // bit
    }

    public static class TicketDtoMapExtensions
    {
        public static TicketDto ToTicketDto(this TicketModel src)
        {
            var dst = new TicketDto();
            dst.TicketID = src.TicketID;
            dst.ScreeningID = src.ScreeningID;
            dst.UserID = src.UserID;
            dst.SeatNumber = src.SeatNumber;
            dst.TicketPrice = src.TicketPrice;
            dst.PurchaseDate = src.PurchaseDate;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }

        public static TicketModel ToTicketModel(this TicketDto src)
        {
            var dst = new TicketModel();
            dst.TicketID = src.TicketID;
            dst.ScreeningID = src.ScreeningID;
            dst.UserID = src.UserID;
            dst.SeatNumber = src.SeatNumber;
            dst.TicketPrice = src.TicketPrice;
            dst.PurchaseDate = src.PurchaseDate;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }
    }
}
