using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
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
        public async Task<int?> getCurrentSchoolYearID()
        {
            int? data = await SchoolYearDao.Instance.getCurrentSchoolYearID();
            return data;
        }

        public async Task<DataTable> loadClass(int? id)
        {
            DataTable data = await ClassDao.Instance.loadClassBySchoolYearID(id);
            return data;
        }

        public async Task<bool> CreateAccount
        (
            string username,
            string fullName,
            string password,
            string role,
            string isMale,
            string imagePath,
            DateTime DOB,
            string grade,
            string email
        )
        {
            var encodePassword = new UnicodeEncoding().GetBytes(password);
            var sha = SHA256.Create();
            byte[] passwordHash = sha.ComputeHash(encodePassword);

            byte[] imageBytes = File.ReadAllBytes(imagePath);

            int maleBool = isMale == "Male" ? 1 : 0;

            int rowAffected = await AccountDao
                .Instance
                .createUser
                (
                    username, fullName, passwordHash, role, maleBool, imageBytes,
                    DOB, grade, email
                );

            return rowAffected > 1;
        }

        public async Task<DataTable> getUserInformation(string username, string password)
        {
            var encodePassword = new UnicodeEncoding().GetBytes(password);
            var sha = SHA256.Create();
            byte[] passwordHash = sha.ComputeHash(encodePassword);

            DataTable data = await AccountDao
                .Instance
                .getUserInformation(username, passwordHash);

            return data;
        }

        public async Task<int?> getUsername(string username)
        {
            int? rowAffect = await AccountDao.Instance.getUserName(username);
            return rowAffect;
        }

        public async Task<int?> getEmail(string email)
        {
            int? rowAffect = await AccountDao.Instance.getEmail(email);
            return rowAffect;
        }
    }
}