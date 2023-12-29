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

        public async Task<DataTable> loadQuestionByUser
        (
            string username, int page, int offset, string questionDetail,
            string difficultName, string subjectName, DateTime from,
            DateTime To, int? isTest, int? isOK 
        )
        {
            string query = "findAllQuestionByUsername @username , @pagenumber , " +
                "@rowsofpage , @questionDetail , @difficultName , @subjectName , @from"
                + " , @To , @isTest , @isOK";
            object IfTest = (object) isTest ?? DBNull.Value;
            object IfOK = (object) isOK ?? DBNull.Value;
            DataTable data = await DataProvider
                .Instance
                .ExcuteQuery(
                    query, new object[] 
                    {
                        username, page, offset, questionDetail, difficultName,
                        subjectName, from, To, IfTest, IfOK
                    }
                );
            return data;
        }

        public async Task<int?> createQuestionByUserID
        (
            string questionDetail,
            string subjectName,
            string difficultName,
            int isTest,
            int userID
        )
        {
            string query = "createQuestion @questionDetail , @subjectName , @difficultName , " +
                "@isTest , @userID";
            int? questionID = await DataProvider
                .Instance
                .ExcuteScalar(
                    query,
                    new object[] {
                        questionDetail, subjectName, difficultName, isTest,
                        userID
                    }
                );
            return questionID;
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
    }
}
