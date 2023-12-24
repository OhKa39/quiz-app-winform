using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountResponse
    {
        private int accountID;
        private string roleName;
        private string username;
        private string fullname;
        private byte[] image;
        private DateTime dateofbirth;
        private bool isBanned;
        private bool isMale;
        private string email;
        private string grade;

        public int AccountID { get => accountID; set => accountID = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string Username { get => username; set => username = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public byte[] Image { get => image; set => image = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public bool IsBanned { get => isBanned; set => isBanned = value; }
        public bool IsMale { get => isMale; set => isMale = value; }
        public string Email { get => email; set => email = value; }
        public string Grade { get => grade; set => grade = value; }

        public AccountResponse
        (
            string _RoleName, string _Username, string _Fullname, int _AccountID,
            byte[] _image, DateTime _dateofbirth, bool _isBanned, bool _isMale,
            string _email, string _grade
        )
        {
            RoleName = _RoleName;
            Username = _Username;
            Fullname = _Fullname;
            AccountID = _AccountID;
            Image = _image;
            Dateofbirth = _dateofbirth;
            IsBanned = _isBanned;
            IsMale = _isMale;
            Email = _email;
            Grade = _grade;
        }

        public AccountResponse(DataRow data)
        {
            RoleName = data["RoleName"].ToString();
            Username = data["Username"].ToString();
            Fullname = data["FullName"].ToString();
            AccountID = (int)data["AccountID"];
            Image = data["Image"] as byte[];
            Dateofbirth = (DateTime) data["DOB"];
            IsBanned = (bool)data["IsBanned"];
            IsMale = (bool)data["IsMale"];
            Email = data["Email"].ToString();
            Grade = data["ClassName"].ToString();
        }
    }
}
