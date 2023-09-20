using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IUserDal
    {
        // Getters
        UserModel? GetById(int UserId);
        List<UserModel> GetAll();

        // Actions
        int CreateUser(UserModel User);
        void UpdateUser(UserModel User);
        void DeleteUser(int UserId);
    }
}
