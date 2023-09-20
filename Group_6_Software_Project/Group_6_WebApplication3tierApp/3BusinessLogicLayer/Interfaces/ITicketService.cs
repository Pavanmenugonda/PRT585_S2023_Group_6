using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        Task<TicketModel?> GetById(int TicketId);
        Task<List<TicketModel>> GetAll();

        Task<int> CreateTicket(TicketModel Ticket);
        Task UpdateTicket(TicketModel Ticket);
        Task DeleteTicket(int TicketId);
    }
}
