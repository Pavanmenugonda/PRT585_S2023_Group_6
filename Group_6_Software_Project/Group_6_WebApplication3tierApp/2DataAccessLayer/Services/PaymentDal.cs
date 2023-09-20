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
    public class PaymentDal : IPaymentDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public PaymentDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<PaymentModel> GetAll()
        {
            var result = _db.Payments.Where(x => x.IsDeleted == false).ToList();

            var returnObject = new List<PaymentModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToPaymentModel());
            }

            return returnObject;
        }

        public PaymentModel? GetById(int PaymentID)
        {
            var result = _db.Payments.SingleOrDefault(x => x.PaymentID == PaymentID && x.IsDeleted == false);
            return result?.ToPaymentModel();
        }


        public int CreatePayment(PaymentModel Payment)
        {
            var newPayment = Payment.ToPayment();
            _db.Payments.Add(newPayment);
            _db.SaveChanges();
            return newPayment.PaymentID;
        }


        public void UpdatePayment(PaymentModel Payment)
        {
            var existingPayment = _db.Payments
                .SingleOrDefault(x => x.PaymentID == Payment.PaymentID);

            if (existingPayment == null)
            {
                throw new ApplicationException($"Payment {Payment.PaymentID} does not exist.");
            }
            Payment.ToPayment(existingPayment);

            _db.Update(existingPayment);
            _db.SaveChanges();
        }

        public void DeletePayment(int PaymentID)
        {

            var existingPayment = _db.Payments
                .SingleOrDefault(x => x.PaymentID == PaymentID && x.IsDeleted == false);

            if (existingPayment == null)
            {
                throw new ApplicationException($"Payment {PaymentID} does not exist.");
            }

            existingPayment.IsDeleted = true;
            _db.Update(existingPayment);
            _db.SaveChanges();
        }

    }

}
