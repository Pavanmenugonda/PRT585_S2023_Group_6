using LOGIC.Services.Models;
using LOGIC.Services.Models.ApplicationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IApplicationStatus_Service
    {
        Task<Generic_ResultSet<ApplicationStatus_ResultSet>> AddApplicationStatus(string name);
        Task<Generic_ResultSet<List<ApplicationStatus_ResultSet>>> GetAllApplicationStatuses();
        Task<Generic_ResultSet<ApplicationStatus_ResultSet>> UpdateApplicationStatus(Int64 status_id, string name);
    }
}
