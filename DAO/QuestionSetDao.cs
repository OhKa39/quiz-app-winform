using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Identity.Client;

namespace DAO
{
    public class QuestionSetDao
    {
        private static QuestionSetDao instance;
        public static QuestionSetDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionSetDao();
                }
                return QuestionSetDao.instance;
            }
            set
            {
                QuestionSetDao.instance = value;
            }
        }

        public QuestionSetDao() { }

        public async Task<int> createQuestionSet(
                string questionSetName ,
                int Time,
                int AccountID,
                string questionID,
                int isTest
        )
        {
            string query = "createQuestionSet @questionSetName , " +
                "@Time , @AccountID , @isTest , @questionID";
            int rowaffect = await DataProvider
                .Instance
                .ExcuteNonQuery(
                    query,
                    new object[] { questionSetName, Time, AccountID, isTest, questionID }
                );
            return rowaffect;
        }

        public async Task<DataTable> findAllQuestionSet(
                int? AccountID ,
                int pagenumber ,
                int rowsofpage ,
                int? isTest ,
                int? time,
                int? totalQuestion,
                DateTime from,
                DateTime to ,
                int? isOK ,
                string questionSetName,
                string questionSetID
        )
        {
            string query = "findAllQuestionSet @AccountID , " +
                "@pagenumber , @rowsofpage , @isTest , @time , @totalQuestion , @from , " +
                "@to , @isOK , @questionSetName , @questionSetID";
            object Time = (object)time ?? DBNull.Value;
            object IfTest = (object)isTest ?? DBNull.Value;
            object IfOK = (object)isOK ?? DBNull.Value;
            object AccountIDCheckNull = (object)AccountID ?? DBNull.Value;
            object totalQues = (object)totalQuestion ?? DBNull.Value;
            DataTable data = await DataProvider
                .Instance
                .ExcuteQuery(
                    query,
                    new object[] {
                        AccountIDCheckNull, pagenumber, rowsofpage, IfTest, Time,
                        totalQues, from, to, IfOK, questionSetName, questionSetID
                    }
                );
            return data;
        }

        public async Task<int?> countQuestionInQuestionSet(int questionSetID)
        {
            string query = "countQuestionInQuestionSet @questionSetID";
            int? count = await DataProvider
                .Instance
                .ExcuteScalar(query, new object[] { questionSetID });
            return count;
        }

        public async Task<DataTable> findQuestionIDinQuestionSet(int questionSetID)
        {
            string query = "findQuestionIDinQuestionSet @questionSetID";
            DataTable count = await DataProvider
                .Instance
                .ExcuteQuery(query, new object[] { questionSetID });
            return count;
        }

        public async Task<int> updateQuestionSet(
            int questionSetID, string questionSetName,
            int time, int isTest, string questionID
        )
        {
            string query = "updateQuestionSet @questionSetID , @questionSetName " +
                ", @Time , @isTest , @questionID";
            int rowAffect = await DataProvider.Instance.ExcuteNonQuery(
                query,
                new object[] { questionSetID, questionSetName, time, isTest, questionID}
            );
            return rowAffect;
        }

        public async Task<int?> randomQuestionSet(int testSetManageID)
        {
            string query = "getRandomQuestionSet @testSetManageID";
            int? value = await DataProvider.Instance.ExcuteScalar(
                query,
                new object[] { testSetManageID }
           );
            return value;
        }

        public async Task<int> deleteQuestionSetbyID(string testSetManageID)
        {
            string query = "deleteQuestionSetById @testSetManageID";
            int value = await DataProvider.Instance.ExcuteNonQuery(
                query,
                new object[] { testSetManageID }
           );
            return value;
        }

        public async Task<int> validateQuestionSetbyID(string testSetManageID, int isOK)
        {
            string query = "validateQuestionSetById @testSetManageID , @isOK";
            int value = await DataProvider.Instance.ExcuteNonQuery(
                query,
                new object[] { testSetManageID, isOK }
           );
            return value;
        }

        public async Task<DataTable> findAllQuestionSetIDinTestSet(int testSetManageID)
        {
            string query = "findAllQuestionSetIDinTestSet @testSetManageID";
            DataTable value = await DataProvider.Instance.ExcuteQuery(
                query,
                new object[] { testSetManageID}
            );
            return value;
        }
    }
}
