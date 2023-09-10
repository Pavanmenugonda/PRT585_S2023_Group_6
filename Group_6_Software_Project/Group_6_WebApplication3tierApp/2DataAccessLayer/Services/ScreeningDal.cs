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
    public class ScreeningDal : IScreeningDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public ScreeningDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<ScreeningModel> GetAll()
        {
            var result = _db.Screenings.Where(x => x.IsDeleted == false).ToList();

            var returnObject = new List<ScreeningModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToScreeningModel());
            }

            return returnObject;
        }

        public ScreeningModel? GetById(int ScreeningId)
        {
            var result = _db.Screenings.SingleOrDefault(x => x.ScreeningId == ScreeningId && x.IsDeleted == false);
            return result?.ToScreeningModel();
        }


        public int CreateScreening(ScreeningModel Screening)
        {
            var newScreening = Screening.ToScreening();
            _db.Screenings.Add(newScreening);
            _db.SaveChanges();
            return newScreening.ScreeningId;
        }


        public void UpdateScreening(ScreeningModel Screening)
        {
            var existingScreening = _db.Screenings
                .SingleOrDefault(x => x.ScreeningId == Screening.ScreeningId);

            if (existingScreening == null)
            {
                throw new ApplicationException($"Screening {Screening.ScreeningId} does not exist.");
            }
            Screening.ToScreening(existingScreening);

            _db.Update(existingScreening);
            _db.SaveChanges();
        }

        public void DeleteScreening(int ScreeningId)
        {

            var existingScreening = _db.Screenings
                .SingleOrDefault(x => x.ScreeningId == ScreeningId && x.IsDeleted == false);

            if (existingScreening == null)
            {
                throw new ApplicationException($"Screening {ScreeningId} does not exist.");
            }

            existingScreening.IsDeleted = true;
            _db.Update(existingScreening);
            _db.SaveChanges();
        }

    }

}
