using LOGIC.Services.Models;
using LOGIC.Services.Models.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IGrade_Service
    {
        Task<Generic_ResultSet<Grade_ResultSet>> AddSingleGrade(string name, int grade_number, int capacity);
        Task<Generic_ResultSet<List<Grade_ResultSet>>> GetAllGrades();
        Task<Generic_ResultSet<Grade_ResultSet>> UpdateGrade(Int64 id, string name, int grade_number, int capacity);
    }
}
