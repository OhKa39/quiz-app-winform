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

        public async Task<int?> getCurrentSchoolYearID()
        {
            int? data = await SchoolYearDao.Instance.getCurrentSchoolYearID();
            return data;
        }

        public async Task<DataTable> loadClass(int? id)
        {
            DataTable data = await ClassDao.Instance.loadClassBySchoolYearID(id);
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
                .loadQuestionByFilter
                (
                    username, page, offset, questionDetail, difficultName,
                    subjectName, from, To, isTest, isOK, ""
                );
            return data;
        }

        public async Task<int> createQuestionAndAnswerByUserID
        (
           string questionDetail,
           string subjectName,
           string difficultName,
           string isTest,
           int userID,
           string answerDetail,
           string isTrue
        )
        {
            string query = "CreateQuestionAndAnswer @questionDetail , @subjectName , " +
                "@difficultName , @isTest , @userID , @answerDetail , @isTrue";
            int IsTest = (isTest == "Thi") ? 1 : 0;
            int rowAffect = await DataProvider
            .Instance
            .ExcuteNonQuery(
                query,
                new object[]{
                    questionDetail, subjectName, difficultName, IsTest, userID,
                    answerDetail, isTrue
                }
             );
            return rowAffect;
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

        public async Task<int> UpdateQuestionAndAnswer(
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
            int rowAffect = await DataProvider
                .Instance
                .ExcuteNonQuery(
                    query,
                    new object[] {
                        questionID, questionDetail, subjectName, difficultName, isTest,
                        answerID, answerDetail, isTrue
                    }
                );
            return rowAffect;
        }

        public async Task<DataTable> loadQuestionForQuestionSet
        (
            int page, int offset, string questionDetail,
            string difficultName, string subjectName, DateTime from,
            DateTime To, int? isTest, int? IsOK, string questionID
        )
        {

            DataTable data = await QuestionDao
                .Instance
                .loadQuestionByFilter
                (
                    "", page, offset, questionDetail, difficultName,
                    subjectName, from, To, isTest, IsOK, questionID
                );
            return data;
        }

        public async Task<int> createQuestionSet(
                string questionSetName,
                int Time,
                int AccountID,
                string questionID,
                int isTest
        )
        {
            int rowAffect = await QuestionSetDao.Instance.createQuestionSet(
                questionSetName, Time, AccountID, questionID, isTest
            );
            return rowAffect;
        }

        public async Task<DataTable> loadQuestionSetByUser
        (
                int? AccountID,
                int pagenumber,
                int rowsofpage,
                int? isTest,
                int? time,
                int? totalQuestion,
                DateTime from,
                DateTime to,
                int? isOK,
                string questionSetName,
                string questionSetID
        )
        {
            DataTable data = await QuestionSetDao
                .Instance
                .findAllQuestionSet(
                        AccountID, pagenumber, rowsofpage, isTest, time, totalQuestion,
                        from, to, isOK, questionSetName, questionSetID
                );
            return data;
        }

        public async Task<int?> countQuestionInQuestionSet(int questionSetID)
        {    
            int? count = await QuestionSetDao
                .Instance
                .countQuestionInQuestionSet(questionSetID );
            return count;
        }

        public async Task<DataTable> findQuestionIDinQuestionSet(int questionSetID)
        {
            
            DataTable count = await QuestionSetDao
                .Instance
                .findQuestionIDinQuestionSet(questionSetID);
            return count;
        }

        public async Task<int> updateQuestionSet(
           int questionSetID, string questionSetName,
           int time, int isTest, string questionID
        )
        {
            int rowAffect = await QuestionSetDao.Instance.updateQuestionSet( 
                questionSetID, questionSetName, time, isTest, questionID
            );
            return rowAffect;
        }

        public async Task<int> createTestSet(
            int accountID,
            int time,
            int totalQuestion,
            string testSetManageName,
            string questionSetID,
            string classID
        )
        {
            int count = await TestSetManageDao.Instance.createTestSet
            (
               accountID, time, totalQuestion, testSetManageName,
               questionSetID, classID
            );
            return count;
        }


        public async Task<DataTable> loadTestSetOfUser(int accountID)
        {
            DataTable data = await TestSetManageDao.Instance.loadTestSetofUser(accountID);

            return data;
        }

        public async Task<DataTable> getCurrentSchoolYear()
        {
            DataTable data = await SchoolYearDao.Instance.getCurrentSchoolYear();
            return data;
        }

        public async Task<int?> randomQuestionSet(int testSetManageID)
        {
            int? value = await QuestionSetDao.Instance.randomQuestionSet(testSetManageID);
            return value;
        }

        public async Task<DataTable> loadAllQuestionInQuestionSet(int? questionSetID)
        {
            DataTable data = await QuestionDao.Instance.loadAllQuestionInQuestionSet(questionSetID);
            return data;
        }

        public async Task<int?> createTestLog(
            int accountID,
            bool isTest,
            string accountChoices,
            string questionID,
            int timeTaken,
            int? testSetManage
        )
        {
            int? rowAffect = await TestLogDao.Instance.createTestLog(
                accountID, isTest, accountChoices, questionID, timeTaken, testSetManage
            );

            return rowAffect;
        }

        public async Task<DataTable> findTestLogByTestSetID(int testSetID, int accountID)
        {
            DataTable scalar = await TestLogDao.Instance.findTestLogByTestSetID(testSetID, accountID);
            return scalar;
        }

        public async Task<int?> countTrueAnswerByTestLog(int testLogID)
        {
            int? scalar = await TestLogDao.Instance.countTrueAnswerByTestLog(testLogID);
            return scalar;
        }

        public async Task<DataTable> loadAllQuestionFromTestLog(int testLogID)
        {
            
            DataTable data = await QuestionDao
                .Instance.loadAllQuestionFromTestLog(testLogID);
            return data;
        }

        public async Task<int> deleteQuestionSetbyID(string testSetManageID)
        { 
            int value = await QuestionSetDao
                .Instance.deleteQuestionSetbyID(testSetManageID);
            return value;
        }

        public async Task<int> validateQuestionSetbyID(string testSetManageID, int isOK)
        {
            int value = await QuestionSetDao
                .Instance.validateQuestionSetbyID(testSetManageID, isOK);
            return value;
        }

        public async Task<DataTable> getAllTestSet
        (
            int? accountID, string searchBox,
            int rowOfPage, int pageNumber
        )
        {
            DataTable data = await TestSetManageDao
                .Instance.getAllTestSet(accountID, searchBox, rowOfPage, pageNumber);

            return data;
        }

        public async Task<DataTable> findAllQuestionSetIDinTestSet(int testSetManageID)
        {
            DataTable value = await QuestionSetDao
                .Instance.findAllQuestionSetIDinTestSet(testSetManageID);
            return value;
        }

        public async Task<DataTable> loadAllUserTestLog(
            int classID,
            int testSetManageID,
            string searchBox,
            int rowsofpage,
            int pagenumber
        )
        {
            DataTable data = await TestLogDao.Instance.loadAllUserTestLog(
                classID, testSetManageID, searchBox, rowsofpage, pagenumber
             );
            return data;
        }

        public async Task<DataTable> loadClassInTestSetManageClass(int testSetManageID)
        {
            DataTable data = await ClassDao
                .Instance.loadClassInTestSetManageClass(testSetManageID);
            return data;
        }

        public async Task<int> deleteTestSetByID
        (
            string TestSetID
        )
        {
            int data = await TestSetManageDao.Instance.deleteTestSetByID(TestSetID);

            return data;
        }

        public async Task<DataTable> loadRandomQuestionbySubject(
            string subjectName, int questionCount
        )
        {
            DataTable data = await QuestionDao.Instance.loadRandomQuestionbySubject
            (
                subjectName, questionCount
            );
            return data;
        }

        public async Task<DataTable> loadAllPracticeTestLog(
            int accountID,
            int rowsofpage,
            int pagenumber
        )
        {
            DataTable data = await TestLogDao.Instance.loadAllPracticeTestLog
            (
                accountID, rowsofpage, pagenumber
            );
            return data;
        }

        public async Task<int?> countAllQuestionInTestLog(
            int testLogID
        )
        {
            int? data = await QuestionDao.Instance.countAllQuestionInTestLog(testLogID);
            return data;
        }

        public async Task<int> updateQuestionIsOKByID(
            string questionID, int state
        )
        {
            int data = await QuestionDao
                .Instance.updateQuestionIsOKByID(questionID, state);
            return data;
        }

        public async Task<DataTable> getPercenTestLogDone(
            int accountID
        )
        {
            DataTable data = await TestLogDao.Instance.getPercenTestLogDone(accountID);
            return data;
        }
    }
}
