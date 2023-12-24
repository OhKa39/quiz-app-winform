using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountRequest
    {
        private int accountID;
        private string roleName = "--Role--";
        private string username;
        private string fullname;
        private string password;
        private string passwordConfirm;
        private string imagePath;
        private DateTime dateofbirth = DateTime.Today;
        private string grade = "--Class--";
        private string email;
        private string isMale = "--Gender--";

        public int AccountID { get => accountID; set => accountID = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string Username { get => username; set => username = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Password { get => password; set => password = value; }
        public string PasswordConfirm { get => passwordConfirm; set => passwordConfirm = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public string Grade { get => grade; set => grade = value; }
        public string Email { get => email; set => email = value; }
        public string IsMale { get => isMale; set => isMale = value; }
    }
}
