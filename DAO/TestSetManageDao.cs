using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TestSetManageDao
    {
        private static TestSetManageDao instance;

        public static TestSetManageDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestSetManageDao();
                }
                return TestSetManageDao.instance;
            }
            set
            {
                TestSetManageDao.instance = value;
            }
        }

        public TestSetManageDao() { }

        public async Task<int> createTestSet(
            int accountID,
            int time,
            int totalQuestion,
            string testSetManageName,
            string questionSetID,
            string classID
        )
        {
            string query = "createTestSet @accountID , @time , @totalQuestion , " +
                "@testSetManageName , @questionSetID , @classID";
            int count = await DataProvider.Instance.ExcuteNonQuery(query,
                new object[] 
                { 
                    accountID, time, totalQuestion, testSetManageName, 
                    questionSetID, classID 
                }
            );
            return count;
        }

        public async Task<DataTable> loadTestSetofUser(int accountID)
        {
            string query = "loadTestSetofUser @accountID";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                query,
                new object[] { accountID }
            );

            return data;
        }

        public async Task<DataTable> getAllTestSet
        (
            int? accountID, string searchBox,
            int rowOfPage, int pageNumber
        )
        {
            string query = "loadAllTestSet @accountID , @searchBox , @rowsofpage , " +
                "@pagenumber";
            object AccountIDC = (object)accountID ?? DBNull.Value; 
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                query,
                new object[] { AccountIDC, searchBox, rowOfPage, pageNumber }
            );

            return data;
        }

        public async Task<int> deleteTestSetByID
        (
            string TestSetID 
        )
        {
            string query = "deleteTestSetById @TestSetID";
            int data = await DataProvider.Instance.ExcuteNonQuery(
                query,
                new object[] { TestSetID }
            );

            return data;
        }
    }
}
