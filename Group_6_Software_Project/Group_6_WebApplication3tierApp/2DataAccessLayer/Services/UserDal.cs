using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class UserDal : IUserDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public UserDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<UserModel> GetAll()
        {
            var result = _db.Users.Where(x => x.IsDeleted == false).ToList();

            var returnObject = new List<UserModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToUserModel());
            }

            return returnObject;
        }

        public UserModel? GetById(int UserID)
        {
            var result = _db.Users.SingleOrDefault(x => x.UserID == UserID && x.IsDeleted == false);
            return result?.ToUserModel();
        }


        public int CreateUser(UserModel User)
        {
            var newUser = User.ToUser();
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return newUser.UserID;
        }


        public void UpdateUser(UserModel User)
        {
            var existingUser = _db.Users
                .SingleOrDefault(x => x.UserID == User.UserID);

            if (existingUser == null)
            {
                throw new ApplicationException($"User {User.UserID} does not exist.");
            }
            User.ToUser(existingUser);

            _db.Update(existingUser);
            _db.SaveChanges();
        }

        public void DeleteUser(int UserID)
        {

            var existingUser = _db.Users
                .SingleOrDefault(x => x.UserID == UserID && x.IsDeleted == false);

            if (existingUser == null)
            {
                throw new ApplicationException($"User {UserID} does not exist.");
            }

            existingUser.IsDeleted = true;
            _db.Update(existingUser);
            _db.SaveChanges();
        }

    }

}
