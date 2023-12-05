using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;

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
            string[] stringQuery = query.Split(' ');
            int j = 0;
            using (SqlCommand command = new SqlCommand(conn))
            {               
                foreach(var i in stringQuery)
                {
                    if(i.Contains('@'))
                    {
                        command.Parameters.AddWithValue(i, parameter[j]);
                        ++j;
                    }    
                }

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable data = new DataTable();

                da.Fill(data);
                return data;
            }
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            string[] stringQuery = query.Split(' ');
            int j = 0;
            int count = 0;

            using (SqlCommand command = new SqlCommand(conn))
            {              
                foreach (var i in stringQuery)
                {
                    if (i.Contains('@'))
                    {
                        command.Parameters.AddWithValue(i, parameter[j]);
                        ++j;
                    }
                }

                count = command.ExecuteNonQuery();               
            }

            return count;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            string[] stringQuery = query.Split(' ');
            int j = 0;
            using (SqlCommand command = new SqlCommand(conn))
            {           
                foreach (var i in stringQuery)
                {
                    if (i.Contains('@'))
                    {
                        command.Parameters.AddWithValue(i, parameter[j]);
                        ++j;
                    }
                }
                object count = command.ExecuteScalar().ToString();
                return count;
            }
        }

        
    }
}
