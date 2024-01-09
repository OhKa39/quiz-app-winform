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
        private string connString = @"Server=tcp:ohka.database.windows.net,1433;Initial Catalog=quizapp;Persist Security Info=False;User ID=ohka1234;Password=12303123AbC@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
        public async Task<DataTable> ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
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

                    SqlDataAdapter da = new SqlDataAdapter(command);

                    await Task.Run(() => da.Fill(data));
                }
                return data;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> ExcuteNonQuery(string query, object[] parameter = null, IProgress<int> progress = null)
        {
            int data = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {

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

                        command.Connection.Open();
                        await Task.Run(() => data = (int)command.ExecuteNonQuery());
                    }
                    
                }
                return data;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int?> ExcuteScalar(string query, object[] parameter = null)
        {
            int? data = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
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
                    await Task.Run(() => data = (int?)command.ExecuteScalar());
                }
                return data;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
