using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<DataTable> loadQuestionByUser(string username, int page, int offset)
        {
            string query = "findAllQuestionByUsername @username , @pagenumber , @rowsofpage";
            DataTable data = await DataProvider
                .Instance
                .ExcuteQuery(query, new object[] { username, page, offset});
            return data;
        }

        //public int addQuestion
        //(string question, string answer1,
        // string answer2, string answer3,
        // string answer4, int selectSubject,
        // int trueAnswer, int questionType,
        // int accountID
        //)
        //{
        //string query = (
        //    "createQuestion @Description , @Answer1 , @Answer2"
        //    + " , @Answer3 , @Answer4 , @TrueAnswer , @SubjectID"
        //    + " , @AccountID , @QuestionType"
        //);
        //int count = 0;
        //try
        //{
        //    count = DataProvider
        //        .Instance
        //        .ExcuteNonQuery(
        //            query,
        //            new object[]
        //            {
        //                question,
        //                answer1,
        //                answer2,
        //                answer3,
        //                answer4,
        //                trueAnswer,
        //                selectSubject,
        //                accountID,
        //                questionType
        //            }
        //        );
        //}
        //catch(Exception e)
        //{
        //    return 0;
        //}

        //return count;
        //}

        // public int updateQuestion
        //(string question, string answer1,
        // string answer2, string answer3,
        // string answer4, int selectSubject,
        // int trueAnswer, int questionType,
        // int questionID
        //)
        // {
        //     string query = (
        //         "updateQuestion @Description , @Answer1 , @Answer2"
        //         + " , @Answer3 , @Answer4 , @TrueAnswer , @SubjectID"
        //         + " , @QuestionID , @QuestionType"
        //     );
        //     int count = 0;
        //     try
        //     {
        //         count = DataProvider
        //             .Instance
        //             .ExcuteNonQuery(
        //                 query,
        //                 new object[]
        //                 {
        //                     question,
        //                     answer1,
        //                     answer2,
        //                     answer3,
        //                     answer4,
        //                     trueAnswer,
        //                     selectSubject,
        //                     questionID,
        //                     questionType
        //                 }
        //     //        );
        //     }
        //     catch (Exception e)
        //     {
        //         return 0;
        //     }

        //     return count;
        // }

        //public DataTable loadQuestionsTest(
        //    int rowNumber, int IsOK, int subjectID, int questionType
        //)
        //{
        //    string query = (
        //        "getQuestionsTest @rownumber , @IsOK" +
        //        " , @subjectID , @questionType"
        //    );
        //    DataTable data = DataProvider
        //        .Instance
        //        .ExcuteQuery(
        //            query, 
        //            new object[] { rowNumber, IsOK, subjectID, questionType }
        //        );

        //    return data;
        //}
    }
}
