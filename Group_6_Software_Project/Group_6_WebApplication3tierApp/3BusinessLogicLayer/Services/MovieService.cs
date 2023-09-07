

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
    public class MovieService :   BaseService, IMovieService
    {
        private readonly IMovieDal _movieDal;
       
        public MovieService(IMovieDal movieDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //IMovieDal movieDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
        {
            _movieDal = movieDal;           
        }

        public async Task<MovieModel?> GetById(int MovieId)
        {           
            return _movieDal.GetById(MovieId);
        }

        public async Task<List<MovieModel>> GetAll()
        {            
            return _movieDal.GetAll();
        }

        public async Task<int> CreateMovie(MovieModel Movie)
        {

            try
            {
                var newMovieId = _movieDal.CreateMovie(Movie);
                return newMovieId;

            }
            catch (Exception e)
            {
                LogError("Error-CreateMovie", $"Error trying to create Movie", Movie, e);
            }           
           return 0;
        }

        public async Task UpdateMovie(MovieModel Movie)
        {
            //write validations here 
            _movieDal.UpdateMovie(Movie);
        }

        public async Task DeleteMovie(int MovieId)
        {            
            try
            {
                _movieDal.DeleteMovie(MovieId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Movie Id:{MovieId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
