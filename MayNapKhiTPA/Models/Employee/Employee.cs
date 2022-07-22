
namespace MayNapKhiTPA.Models
{
    public class Employee
    {
        public int ID_Employee { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ID_Shift { get; set; }
        public int ID_Permission { get; set; }

        public Employee()
        {
        }

        public Employee(int iD_Employee, string fullName, string username, string password, string phoneNumber, string email, int iD_Shift, int iD_Permission)
        {
            ID_Employee = iD_Employee;
            FullName = fullName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            ID_Shift = iD_Shift;
            ID_Permission = iD_Permission;
        }

        public Employee(string fullName, string username, string password, string phoneNumber, string email, int iD_Shift, int iD_Permission)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            ID_Shift = iD_Shift;
            ID_Permission = iD_Permission;
        }
    }

}
