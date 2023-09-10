using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IScreeningDal
    {
        // Getters
        ScreeningModel? GetById(int ScreeningId);
        List<ScreeningModel> GetAll();

        // Actions
        int CreateScreening(ScreeningModel Screening);
        void UpdateScreening(ScreeningModel Screening);
        void DeleteScreening(int ScreeningId);
    }
}
