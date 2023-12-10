using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SubjectDao
    {
        private static SubjectDao instance;
        public static SubjectDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubjectDao();
                }
                return SubjectDao.instance;
            }
            set
            {
                SubjectDao.instance = value;
            }
        }

        public SubjectDao() { }

        public DataTable loadSubject()
        {
            string query = "SELECT * FROM [SUBJECT]";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
