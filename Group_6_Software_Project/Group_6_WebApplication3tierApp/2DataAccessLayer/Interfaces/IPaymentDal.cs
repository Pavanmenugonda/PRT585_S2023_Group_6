using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IPaymentDal
    {
        // Getters
        PaymentModel? GetById(int PaymentId);
        List<PaymentModel> GetAll();

        // Actions
        int CreatePayment(PaymentModel Payment);
        void UpdatePayment(PaymentModel Payment);
        void DeletePayment(int PaymentId);
    }
}
