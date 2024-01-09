using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace DAO
{
    public class AccountDao
    {
        private static AccountDao instance;
        public static AccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDao();
                }
                return AccountDao.instance;
            }
            set
            {
                AccountDao.instance = value;
            }
        }

        public AccountDao() { }

        public async Task<DataTable> getUserInformation(string username, byte[] password)
        {
            string query = (
                "getUserInformation @userName , @password"
            );

            DataTable data = await DataProvider
            .Instance
                .ExcuteQuery(query, new object[] { username, password});
            return data;
        }

        public async Task <int> createUser
        (
            string username, 
            string fullName, 
            byte[] password, 
            string role, 
            int isMale, 
            byte[] image,
            DateTime DOB,
            string grade,
            string email
        )
        {
            string query = (
                "createAccount @username , @email , @fullname , @password , @DOB , @roleName " +
                ", @className , @isMale , @image"
            );
            try
            {
                int rowAffected = await DataProvider
                    .Instance
                    .ExcuteNonQuery(
                        query,
                        new object[] 
                        {
                            username, email, fullName, password, 
                            DOB, role, grade, isMale, image
                        }
                    );
                return rowAffected;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        public async Task<int?> getUserName(string username)
        {
            int? rowAffected = 0;
            string query = "Select COUNT([Username]) from [Account] where [Username] = @Username";
            rowAffected = await DataProvider.Instance.ExcuteScalar(query, new object[] { username });
            return rowAffected;
        }

        public async Task<int?> getEmail(string email)
        {
            int? rowAffected = 0;
            string query = "Select COUNT([Email]) from [Account] where [Email] = @Email";
            rowAffected = await DataProvider.Instance.ExcuteScalar(query, new object[] { email });
            return rowAffected;
        }

        public async Task<int> updateUserPassword(string email, byte[]password)
        {
            string query = "updateUserPassword @email , @password";
            int rowAffect = await DataProvider
                .Instance.ExcuteNonQuery(query, new object[] { email, password });
            return rowAffect;
        }
    }
}