using LOGIC.Services.Models;
using LOGIC.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IStudent_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudents();
        Task<Generic_ResultSet<Student_ResultSet>> GetStudentById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Student_ResultSet>> AddStudent(string name);
        Task<Generic_ResultSet<Student_ResultSet>> UpdateStudent(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteStudent(Int64 id);

    }
}

