using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models
{
    //WILL BE USED AS EVERY RESULT OBJECT FROM OUR SERVICE METHODS
    public class Generic_ResultSet<T>:StandardResultObject
    {
        public T result_set { get; set; }
    }
}
