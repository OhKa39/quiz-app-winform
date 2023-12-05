using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private int roleID;
        private string username;
        private string fullname;
        private byte[] password;

        public Account(int _RoleID, string _Username, byte[] _Password, string _Fullname)
        {
            RoleID = _RoleID;
            Username = _Username;
            Password = _Password;
            Fullname = _Fullname;
        }

        public Account(DataRow data)
        {
            RoleID = (int)data["RoleID"];
            Username = data["Username"].ToString();
            Password = data["Password"] as byte[];
            Fullname = data["FullName"].ToString();
        }

        public int RoleID { get => roleID; set => roleID = value; }
        public string Username { get => username; set => username = value; }
        public byte[] Password { get => password; set => password = value; }
        public string Fullname { get => fullname; set => fullname = value; }
    }
}
