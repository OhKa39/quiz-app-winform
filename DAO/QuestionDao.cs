using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuestionDao
    {
        private static QuestionDao instance;
        public static QuestionDao Instance { 
            get {
                if (instance == null)
                {
                    instance = new QuestionDao();
                }
                return QuestionDao.instance;
            }
            set {
                QuestionDao.instance = value;
            }
        }

        public QuestionDao() { }

        public async Task<DataTable> loadQuestionByFilter
        (
            string username, int page, int offset, string questionDetail,
            string difficultName, string subjectName, DateTime from,
            DateTime To, int? isTest, int? isOK, string questionID 
        )
        {
            string query = "findAllQuestion @username , @pagenumber , " +
                "@rowsofpage , @questionDetail , @difficultName , @subjectName , @from"
                + " , @To , @isTest , @isOK , @questionID";
            object IfTest = (object) isTest ?? DBNull.Value;
            object IfOK = (object) isOK ?? DBNull.Value;
            DataTable data = await DataProvider
                .Instance
                .ExcuteQuery(
                    query, new object[] 
                    {
                        username, page, offset, questionDetail, difficultName,
                        subjectName, from, To, IfTest, IfOK, questionID
                    }
                );
            return data;
        }

        public async Task<int> deleteQuestionByQuestionID
        (
            string questionID
        )
        {
            string query = "deleteQuestionById @questionID";
            int rowCount = await DataProvider
                .Instance
                .ExcuteNonQuery(
                    query,
                    new object[] { questionID });
            return rowCount;
        }

        public async Task<int> updateQuestionByQuestionID
        (
            int questionID,
            string questionDetail,
            string subjectName,
            string difficultName,
            int isTest
        )
        {
            string query = "updateQuestionByQuestionID @questionID , @questionDetail " +
                ", @subjectName , @difficultName , @isTest";
            int rowCount = await DataProvider
                .Instance
                .ExcuteNonQuery(
                    query,
                    new object[] { questionID, questionDetail, subjectName, difficultName, isTest});
            return rowCount;
        }

        public async Task<DataTable> loadAllQuestionInQuestionSet(int? questionSetID)
        {
            string query = "loadAllQuestionInQuestionSet @questionSetID";
            object questionID = (object)questionSetID ?? DBNull.Value;
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { questionID }
                );
            return data;
        }

        public async Task<DataTable> loadAllQuestionFromTestLog(int testLogID)
        {
            string query = "findAllQuestionIDInTestLog @testLogID";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { testLogID }
                );
            return data;
        }

        public async Task<DataTable> loadRandomQuestionbySubject(
            string subjectName, int questionCount
        )
        {
            string query = "loadRandomQuestionbySubject @subjectName , @questionCount";
            DataTable data = await DataProvider.Instance.ExcuteQuery(
                    query,
                    new object[] { subjectName, questionCount }
                );
            return data;
        }

        public async Task<int?> countAllQuestionInTestLog(
            int testLogID
        )
        {
            string query = "countAllQuestionInTestLog @testLogID";
            int? data = await DataProvider.Instance.ExcuteScalar(
                    query,
                    new object[] { testLogID }
                );
            return data;
        }

        public async Task<int> updateQuestionIsOKByID(
            string questionID, int state
        )
        {
            string query = "validateQuestionById @questionID , @State";
            int data = await DataProvider.Instance.ExcuteNonQuery(
                    query,
                    new object[] { questionID, state }
                );
            return data;
        }
    }
}
