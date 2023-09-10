

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
    public class ScreeningService :   BaseService, IScreeningService
    {
        private readonly IScreeningDal _movieDal;
       
        public ScreeningService(IScreeningDal movieDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //IScreeningDal movieDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
        {
            _movieDal = movieDal;           
        }

        public async Task<ScreeningModel?> GetById(int ScreeningId)
        {           
            return _movieDal.GetById(ScreeningId);
        }

        public async Task<List<ScreeningModel>> GetAll()
        {            
            return _movieDal.GetAll();
        }

        public async Task<int> CreateScreening(ScreeningModel Screening)
        {

            try
            {
                var newScreeningId = _movieDal.CreateScreening(Screening);
                return newScreeningId;

            }
            catch (Exception e)
            {
                LogError("Error-CreateScreening", $"Error trying to create Screening", Screening, e);
            }           
           return 0;
        }

        public async Task UpdateScreening(ScreeningModel Screening)
        {
            //write validations here 
            _movieDal.UpdateScreening(Screening);
        }

        public async Task DeleteScreening(int ScreeningId)
        {            
            try
            {
                _movieDal.DeleteScreening(ScreeningId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Screening Id:{ScreeningId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
