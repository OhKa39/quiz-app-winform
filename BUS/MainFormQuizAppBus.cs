using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class MainFormQuizAppBus
    {
        private static MainFormQuizAppBus instance;
        public static MainFormQuizAppBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainFormQuizAppBus();
                }
                return MainFormQuizAppBus.instance;
            }
            set
            {
                MainFormQuizAppBus.instance = value;
            }
        }

        public MainFormQuizAppBus() { }
        public async Task<DataTable> loadBook()
        {
            DataTable data = await BookDao.Instance.loadBook();
            return data;
        }
        public async Task<DataTable> loadSubjectByBookName(string bookname)
        {
            DataTable data = await SubjectDao.Instance.loadSubjectByBookName(bookname);
            return data;
        }


        public async Task<DataTable> loadQuestionByUser
        (
            string username, int page, int offset, string questionDetail,
            string difficultName, string subjectName, DateTime from,
            DateTime To, int? isTest, int? isOK
        )
        {

            DataTable data = await QuestionDao
                .Instance
                .loadQuestionByUser
                (
                    username, page, offset, questionDetail, difficultName,
                    subjectName, from, To, isTest, isOK
                );
            return data;
        }

        public async Task<int?> createQuestionByUserID
        (
           string questionDetail,
           string subjectName,
           string difficultName,
           string isTest,
           int userID
        )
        {
            int IsTest = (isTest == "Thi") ? 1 : 0;
            int? questionID = await QuestionDao
            .Instance
            .createQuestionByUserID(
                    questionDetail, subjectName, difficultName, IsTest, userID
             );
            return questionID;
        }

        public async Task<int?> createAnswerByQuestionID
        (
            int? questionID,
            string answerDetail,
            string isTrue
        )
        {
            int? count = await AnswerDao
                .Instance
                .createAnswerByQuestionID(questionID, answerDetail, isTrue);
            return count;
        }

        public async Task<int> deleteQuestionByQuestionID
        (
            string questionID
        )
        {
            int rowCount = await QuestionDao.Instance.deleteQuestionByQuestionID(questionID);
            return rowCount;
        }

        public async Task<DataTable> loadAnswerByQuestionID(int questionID)
        {
            DataTable dt = await AnswerDao.Instance.loadAnswerByQuestionID(questionID);
            return dt;
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
            int rowCount = await QuestionDao
                .Instance
                .updateQuestionByQuestionID(
                    questionID, questionDetail, subjectName, difficultName, isTest 
                );
            return rowCount;
        }

        public async Task<int?> UpdateQuestionAndAnswer(
            int questionID ,
            string questionDetail ,
            string subjectName,
            string difficultName,
            bool isTest,
            string answerID,
            string answerDetail,
            string isTrue
        )
        {
            string query = "UpdateQuestionAndAnswer @questionID , @questionDetail , @subjectName" +
                " , @difficultName , @isTest , @answerID , @answerDetail , @isTrue";
            int? rowAffect = await DataProvider
                .Instance
                .ExcuteScalar(
                    query,
                    new object[] {
                        questionID, questionDetail, subjectName, difficultName, isTest,
                        answerID, answerDetail, isTrue
                    }
                );
            return rowAffect;
        }
    }
}
