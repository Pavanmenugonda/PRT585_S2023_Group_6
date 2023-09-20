using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class PaymentMapExtensions
    {
        public static PaymentModel ToPaymentModel(this Payment src)
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

        public static Payment ToPayment(this PaymentModel src, Payment dst = null)
        {
            if (dst == null)
            {
                dst = new Payment();
            }

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
