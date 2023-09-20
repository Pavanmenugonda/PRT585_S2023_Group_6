using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public String UserEmail { get; set; }
        public String CardHolderName { get; set; }
        public String CardNumber { get; set; }
        public String ExpirationDate { get; set; }
        public String Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsDeleted { get; set; } // bit
    }

    public static class PaymentDtoMapExtensions
    {
        public static PaymentDto ToPaymentDto(this PaymentModel src)
        {
            var dst = new PaymentDto();
            dst.PaymentID = src.PaymentID;
            dst.UserEmail = src.UserEmail;
            dst.CardHolderName = src.CardHolderName;
            dst.CardNumber = src.CardNumber;
            dst.ExpirationDate = src.ExpirationDate;
            dst.Amount = src.Amount;
            dst.PaymentDate = src.PaymentDate;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }

        public static PaymentModel ToPaymentModel(this PaymentDto src)
        {
            var dst = new PaymentModel();
            dst.PaymentID = src.PaymentID;
            dst.UserEmail = src.UserEmail;
            dst.CardHolderName = src.CardHolderName;
            dst.CardNumber = src.CardNumber;
            dst.ExpirationDate = src.ExpirationDate;
            dst.Amount = src.Amount;
            dst.PaymentDate = src.PaymentDate;
            dst.IsDeleted = src.IsDeleted;
            return dst;
        }
    }
}
