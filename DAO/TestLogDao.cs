using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TestLogDao
    {
        private static TestLogDao instance;
        public static TestLogDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestLogDao();
                }
                return TestLogDao.instance;
            }
            set
            {
                TestLogDao.instance = value;
            }
        }

        public TestLogDao() { }

        public async Task<int?> createTestLog(
            int accountID,
            bool isTest,
            string accountChoices,
            string questionID,
            int timeTaken,
            int? testSetManage
        )
        {
            string query = "createTestLog @accountID , @isTest , @accountChoices , " +
                "@questionID , @timeTaken , @TestSetManageID";

            object testSetManageID = (object)testSetManage ?? DBNull.Value;
            int? rowAffect = await DataProvider.Instance.ExcuteScalar(
                query,
                new object[] 
                {
                    accountID, isTest, accountChoices, questionID, 
                    timeTaken, testSetManageID 
                }
            );

            return rowAffect;
        }

        public async Task<DataTable> findTestLogByTestSetID(int testSetID, int accountID)
        {
            string query = "findTestLogByTestSetManageID @testSetManageID , @accountID";
            DataTable scalar = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { testSetID, accountID }
                );
            return scalar;
        }

        public async Task<int?> countTrueAnswerByTestLog(int testLogID)
        {
            string query = "countTrueAnswerInTestLog @testLogID";
            int? scalar = await DataProvider.Instance.ExcuteScalar(
                    query,
                    new object[] {testLogID}
                );
            return scalar;
        }

        public async Task<DataTable> loadAllUserTestLog(
            int classID,
            int testSetManageID,
            string searchBox,
            int rowsofpage,
            int pagenumber
        )
        {
            string query = "loadAllUserTestLog @classID , @testSetManageID , " +
                "@searchBox , @rowsofpage , @pagenumber";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { classID, testSetManageID, searchBox, rowsofpage, pagenumber }
                );
            return data;
        }

        public async Task<DataTable> loadAllPracticeTestLog(
            int accountID,
            int rowsofpage,
            int pagenumber
        )
        {
            string query = "loadAllPracticeTestLog @accountID , " +
                "@rowsofpage , @pagenumber";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { accountID, rowsofpage, pagenumber }
                );
            return data;
        }

        public async Task<DataTable> getPercenTestLogDone(
            int accountID
        )
        {
            string query = "getPercentTestLogHasDone @accountID";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { accountID}
                );
            return data;
        }

    }
}
