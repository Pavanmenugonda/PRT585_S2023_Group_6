using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class TicketDal : ITicketDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public TicketDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<TicketModel> GetAll()
        {
            var result = _db.Tickets.Where(x => x.IsDeleted == false).ToList();

            var returnObject = new List<TicketModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToTicketModel());
            }

            return returnObject;
        }

        public TicketModel? GetById(int TicketID)
        {
            var result = _db.Tickets.SingleOrDefault(x => x.TicketID == TicketID && x.IsDeleted == false);
            return result?.ToTicketModel();
        }


        public int CreateTicket(TicketModel Ticket)
        {
            var newTicket = Ticket.ToTicket();
            _db.Tickets.Add(newTicket);
            _db.SaveChanges();
            return newTicket.TicketID;
        }


        public void UpdateTicket(TicketModel Ticket)
        {
            var existingTicket = _db.Tickets
                .SingleOrDefault(x => x.TicketID == Ticket.TicketID);

            if (existingTicket == null)
            {
                throw new ApplicationException($"Ticket {Ticket.TicketID} does not exist.");
            }
            Ticket.ToTicket(existingTicket);

            _db.Update(existingTicket);
            _db.SaveChanges();
        }

        public void DeleteTicket(int TicketID)
        {

            var existingTicket = _db.Tickets
                .SingleOrDefault(x => x.TicketID == TicketID && x.IsDeleted == false);

            if (existingTicket == null)
            {
                throw new ApplicationException($"Ticket {TicketID} does not exist.");
            }

            existingTicket.IsDeleted = true;
            _db.Update(existingTicket);
            _db.SaveChanges();
        }

    }

}
