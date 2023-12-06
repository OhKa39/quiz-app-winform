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

        public DataTable getUserInformation(string username, byte[] password, int role)
        {
            string query = (
                "getUserInformation @UserName , @Password , @Role"
            );

            DataTable data = DataProvider
            .Instance
                .ExcuteQuery(query, new object[]{ username, password, role});
            return data;
        }

        public int createUser(string username, string fullName, byte[] password, int role)
        {
            int rowAffected = 0;
            string query = (
                "createAccount @RoleID , @FullName , @Username , @Password"
            );
            try
            {
                rowAffected = DataProvider
                    .Instance
                    .ExcuteNonQuery(
                        query,
                        new object[] { role, fullName, username, password }
                    );
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }

            return rowAffected;
        }
    }
}