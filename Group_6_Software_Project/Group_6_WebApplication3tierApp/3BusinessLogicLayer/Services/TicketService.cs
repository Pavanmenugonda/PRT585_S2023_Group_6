

using _1CommonInfrastructure.Enum;
using _1CommonInfrastructure.Interfaces;
using _1CommonInfrastructure.Models;
using _1CommonInfrastructure.Validations;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class TicketService :   BaseService, ITicketService
    {
        private readonly ITicketDal _ticketDal;
       
        public TicketService(ITicketDal movieDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //ITicketDal movieDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
        {
            _ticketDal = movieDal;           
        }

        public async Task<TicketModel?> GetById(int TicketId)
        {           
            return _ticketDal.GetById(TicketId);
        }

        public async Task<List<TicketModel>> GetAll()
        {            
            return _ticketDal.GetAll();
        }

        public async Task<int> CreateTicket(TicketModel Ticket)
        {

            try
            {
                var newTicketId = _ticketDal.CreateTicket(Ticket);
                return newTicketId;

            }
            catch (Exception e)
            {
                LogError("Error-CreateTicket", $"Error trying to create Ticket", Ticket, e);
            }           
           return 0;
        }

        public async Task UpdateTicket(TicketModel Ticket)
        {
            //write validations here 
            _ticketDal.UpdateTicket(Ticket);
        }

        public async Task DeleteTicket(int TicketId)
        {            
            try
            {
                _ticketDal.DeleteTicket(TicketId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Ticket Id:{TicketId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
