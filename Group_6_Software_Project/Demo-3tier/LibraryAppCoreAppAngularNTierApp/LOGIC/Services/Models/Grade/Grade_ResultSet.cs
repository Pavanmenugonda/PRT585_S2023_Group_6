using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Grade
{
    public class Grade_ResultSet
    {
        public Int64 id { get; set; } //(PK)
        public String name { get; set; }
        public Int32 grade_number { get; set; }
        public Int32 capacity { get; set; }
    }
}
