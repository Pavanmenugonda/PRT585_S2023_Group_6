using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface ITicketDal
    {
        // Getters
        TicketModel? GetById(int TicketId);
        List<TicketModel> GetAll();

        // Actions
        int CreateTicket(TicketModel Ticket);
        void UpdateTicket(TicketModel Ticket);
        void DeleteTicket(int TicketId);
    }
}
