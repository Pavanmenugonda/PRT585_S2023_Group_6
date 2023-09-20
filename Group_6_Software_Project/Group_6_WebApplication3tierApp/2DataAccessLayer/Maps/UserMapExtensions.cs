using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class UserMapExtensions
    {
        public static UserModel ToUserModel(this User src)
        {
            var dst = new UserModel();

            dst.UserID = src.UserID;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Mobile = src.Mobile;
            dst.Password = src.Password;
            dst.MemberSince = src.MemberSince;
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }

        public static User ToUser(this UserModel src, User dst = null)
        {
            if (dst == null)
            {
                dst = new User();
            }

            dst.UserID = src.UserID;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Mobile = src.Mobile;
            dst.Password = src.Password;
            dst.MemberSince = src.MemberSince;
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }
    }
}
