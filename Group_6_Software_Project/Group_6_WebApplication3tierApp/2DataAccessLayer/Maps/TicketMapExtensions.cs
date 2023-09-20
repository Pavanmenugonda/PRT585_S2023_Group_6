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
    public static class TicketMapExtensions
    {
        public static TicketModel ToTicketModel(this Ticket src)
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

        public static Ticket ToTicket(this TicketModel src, Ticket dst = null)
        {
            if (dst == null)
            {
                dst = new Ticket();
            }

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
