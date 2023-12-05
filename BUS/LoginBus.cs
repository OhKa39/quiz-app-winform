using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks.Dataflow;
using DAO;

namespace BUS
{
    public class LoginBus
    {
        private static LoginBus instance;
        public static LoginBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginBus();
                }
                return LoginBus.instance;
            }
            set
            {
                LoginBus.instance = value;
            }
        }

        public LoginBus() { }

        public DataTable getUserInformation(string username, string password, int role)
        {
            var encodePassword = new UnicodeEncoding().GetBytes(password);
            var sha = SHA256.Create();            
            byte[] passwordHash = sha.ComputeHash(encodePassword);

            DataTable data = AccountDao
                .Instance
                .getUserInformation(username, passwordHash, role);

            return data;               
        }
    }
}