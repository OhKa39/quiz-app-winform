using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class CreateAccountBus
    {
        private static CreateAccountBus instance;
        public static CreateAccountBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateAccountBus();
                }
                return CreateAccountBus.instance;
            }
            set
            {
                CreateAccountBus.instance = value;
            }
        }

        public bool CreateAccount(string username, string password, string fullname, int role)
        {
            var encodePassword = new UnicodeEncoding().GetBytes(password);
            var sha = SHA256.Create();
            byte[] passwordHash = sha.ComputeHash(encodePassword);

            int rowAffected = AccountDao
                .Instance
                .createUser(username, fullname, passwordHash, role);

            return rowAffected == 1;
        }
    }
}
