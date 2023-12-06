using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;

namespace DAO
{
    public class DataProvider
    {
        private string connString = "Server=tcp:quizgame.database.windows.net,1433;Initial Catalog=QuizGame;Persist Security Info=False;User ID=ohka39;Password=12303123AbC@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
            DataTable data = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            using (SqlCommand command = new SqlCommand(query, conn))
            {        
                if(parameter != null)
                {
                    string[] stringQuery = query.Split(' ');
                    int j = 0;
                    foreach (var i in stringQuery)
                    {
                        if (i.Contains('@'))
                        {
                            command.Parameters.AddWithValue(i, parameter[j]);
                            ++j;
                        }
                    }
                }
                
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(data);
            }
            return data;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    if (parameter != null)
                    {
                        string[] stringQuery = query.Split(' ');
                        int j = 0;
                        foreach (var i in stringQuery)
                        {
                            if (i.Contains('@'))
                            {
                                command.Parameters.AddWithValue(i, parameter[j]);
                                ++j;
                            }
                        }
                    }

                    command.Connection.Open();
                    count = command.ExecuteNonQuery();
                    return count;
                }
                catch(SqlException e)
                {
                    throw new Exception("Something is wrong", e);
                }                              
            }
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data;
            SqlConnection conn = new SqlConnection(connString);
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                if (parameter != null)
                {
                    string[] stringQuery = query.Split(' ');
                    int j = 0;
                    foreach (var i in stringQuery)
                    {
                        if (i.Contains('@'))
                        {
                            command.Parameters.AddWithValue(i, parameter[j]);
                            ++j;
                        }
                    }
                }
                data = command.ExecuteScalar();
            }

            return data;
        }
    }
}
