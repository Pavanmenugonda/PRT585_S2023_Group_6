using LOGIC.Services.Models;
using LOGIC.Services.Models.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IApplicant_Service
    {
        Task<Generic_ResultSet<Applicant_ResultSet>> AddSingleApplicant(string name, string surname, DateTime birthday, string email, string phone_number);
        Task<Generic_ResultSet<Applicant_ResultSet>> GetApplicantById(Int64 applicant_id);
        Task<Generic_ResultSet<Applicant_ResultSet>> UpdateApplicant(Int64 applicant_id, string name, string surname, DateTime birthday, string email, string phone_number);
    }
}
