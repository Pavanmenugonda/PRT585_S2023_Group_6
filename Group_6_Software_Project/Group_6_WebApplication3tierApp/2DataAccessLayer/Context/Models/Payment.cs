using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Payment
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
}
