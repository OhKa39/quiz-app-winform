using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClassDao
    {
        private static ClassDao instance;

        public static ClassDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClassDao();
                }
                return ClassDao.instance;
            }
            set
            {
                ClassDao.instance = value;
            }
        }

        public ClassDao() { }

        public async Task<DataTable> loadClassBySchoolYearID(int? id)
        {
            string query = (
                "SELECT [ClassName], [ClassID] FROM [Class] WHERE " +
                "[CLASS].[SCHOOLYEARID] = @id"
            );
            DataTable data = await DataProvider
                .Instance.ExcuteQuery(query, new object[] { id });
            return data;
        }

        public async Task<DataTable> loadClassInTestSetManageClass(int testSetManageID)
        {
            string query = (
                "getClassInTestSetManageClass @testSetManageID"
            );
            DataTable data = await DataProvider
                .Instance.ExcuteQuery(query, new object[] { testSetManageID });
            return data;
        }
    }
}
