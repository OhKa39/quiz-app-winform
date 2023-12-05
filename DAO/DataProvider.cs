using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        private string conn = "Server=tcp:quizgame.database.windows.net,1433;Initial Catalog=QuizGame;Persist Security Info=False;User ID=ohka39;Password=12303123AbC@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static DataProvider instance;

        public static DataProvider Instance { 
            get {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            set {
                 DataProvider.instance = value;
            }
        }

        public DataProvider() { }
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            using(SqlCommand )
        }
    }
}
