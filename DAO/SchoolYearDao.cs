using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SchoolYearDao
    {
        private static SchoolYearDao instance;

        public static SchoolYearDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SchoolYearDao();
                }
                return SchoolYearDao.instance;
            }
            set
            {
                SchoolYearDao.instance = value;
            }
        }

        public SchoolYearDao() { }

        public async Task<int?> getCurrentSchoolYearID()
        {
            string query = "Select MAX([SchoolYearID]) from [SchoolYear]";
            int? data = await DataProvider.Instance.ExcuteScalar(query);
            return data;
        }

        public async Task<DataTable> getCurrentSchoolYear()
        {
            string query = "getLastSchoolYear";
            DataTable data = await DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
