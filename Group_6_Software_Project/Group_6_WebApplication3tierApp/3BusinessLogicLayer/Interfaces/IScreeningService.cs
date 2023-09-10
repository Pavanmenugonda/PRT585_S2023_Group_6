using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IScreeningService
    {
        Task<ScreeningModel?> GetById(int ScreeningId);
        Task<List<ScreeningModel>> GetAll();

        Task<int> CreateScreening(ScreeningModel Screening);
        Task UpdateScreening(ScreeningModel Screening);
        Task DeleteScreening(int Screening);
    }
}
