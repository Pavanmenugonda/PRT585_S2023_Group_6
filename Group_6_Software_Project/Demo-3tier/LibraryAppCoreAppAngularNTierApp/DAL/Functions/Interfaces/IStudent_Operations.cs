using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IStudent_Operations
    {
        Task<Student> Create(Student objectToAdd);
        Task<Student> Read(Int64 entityId);
        Task<List<Student>> ReadAll();
        Task<Student> Update(Student objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
