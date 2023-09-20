using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> GetById(int UserId);
        Task<List<UserModel>> GetAll();
        Task<int> CreateUser(UserModel User);
        Task UpdateUser(UserModel User);
        Task DeleteUser(int User);
    }
}
