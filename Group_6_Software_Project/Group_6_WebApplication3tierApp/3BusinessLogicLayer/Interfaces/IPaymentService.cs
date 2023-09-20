using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentModel?> GetById(int PaymentId);
        Task<List<PaymentModel>> GetAll();

        Task<int> CreatePayment(PaymentModel Payment);
        Task UpdatePayment(PaymentModel Payment);
        Task DeletePayment(int PaymentId);
    }
}
