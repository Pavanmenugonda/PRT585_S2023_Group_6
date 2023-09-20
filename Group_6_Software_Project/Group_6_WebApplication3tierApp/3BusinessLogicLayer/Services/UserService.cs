

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
    public class UserService :   BaseService, IUserService
    {
        private readonly IUserDal _UserDal;
       
        public UserService(IUserDal UserDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //IUserDal UserDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
        {
            _UserDal = UserDal;           
        }

        public async Task<UserModel?> GetById(int UserId)
        {           
            return _UserDal.GetById(UserId);
        }

        public async Task<List<UserModel>> GetAll()
        {            
            return _UserDal.GetAll();
        }

        public async Task<int> CreateUser(UserModel User)
        {

            try
            {
                var newUserId = _UserDal.CreateUser(User);
                return newUserId;

            }
            catch (Exception e)
            {
                LogError("Error-CreateUser", $"Error trying to create User", User, e);
            }           
           return 0;
        }

        public async Task UpdateUser(UserModel User)
        {
            //write validations here 
            _UserDal.UpdateUser(User);
        }

        public async Task DeleteUser(int UserId)
        {            
            try
            {
                _UserDal.DeleteUser(UserId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete User Id:{UserId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
