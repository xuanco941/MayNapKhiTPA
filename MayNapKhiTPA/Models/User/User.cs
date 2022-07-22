
namespace MayNapKhiTPA.Models
{
    public class User
    {
        public int ID_User { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ID_Shift { get; set; }
        public int ID_Group { get; set; }

        public User()
        {
        }

        public User(int iD_User, string fullName, string username, string password, string phoneNumber, string email, int iD_Shift, int iD_Group)
        {
            ID_User = iD_User;
            FullName = fullName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            ID_Shift = iD_Shift;
            ID_Group = iD_Group;
        }

        public User(string fullName, string username, string password, string phoneNumber, string email, int iD_Shift, int iD_Group)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            ID_Shift = iD_Shift;
            ID_Group = iD_Group;
        }
    }

}
