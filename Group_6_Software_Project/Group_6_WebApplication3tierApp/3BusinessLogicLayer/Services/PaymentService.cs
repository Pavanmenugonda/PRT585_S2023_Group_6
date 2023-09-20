

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
    public class PaymentService :   BaseService, IPaymentService
    {
        private readonly IPaymentDal _movieDal;
       
        public PaymentService(IPaymentDal movieDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //IPaymentDal movieDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
        {
            _movieDal = movieDal;           
        }

        public async Task<PaymentModel?> GetById(int PaymentId)
        {           
            return _movieDal.GetById(PaymentId);
        }

        public async Task<List<PaymentModel>> GetAll()
        {            
            return _movieDal.GetAll();
        }

        public async Task<int> CreatePayment(PaymentModel Payment)
        {

            try
            {
                var newPaymentId = _movieDal.CreatePayment(Payment);
                return newPaymentId;

            }
            catch (Exception e)
            {
                LogError("Error-CreatePayment", $"Error trying to create Payment", Payment, e);
            }           
           return 0;
        }

        public async Task UpdatePayment(PaymentModel Payment)
        {
            //write validations here 
            _movieDal.UpdatePayment(Payment);
        }

        public async Task DeletePayment(int PaymentId)
        {            
            try
            {
                _movieDal.DeletePayment(PaymentId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Payment Id:{PaymentId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
