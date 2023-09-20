using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class UserDto
    {
        public int UserID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String Password { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsDeleted { get; set; } // bit
    }

    public static class UserDtoMapExtensions
    {
        public static UserDto ToUserDto(this UserModel src)
        {
            var dst = new UserDto();
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

        public static UserModel ToUserModel(this UserDto src)
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
    }
}
