using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class SendTestBus
    {
        private static SendTestBus instance;
        public static SendTestBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SendTestBus();
                }
                return SendTestBus.instance;
            }
            set
            {
                SendTestBus.instance = value;
            }
        }

        public SendTestBus() { }

        public DataTable loadQuestionByUser(string username)
        {
            DataTable data = QuestionDao.Instance.loadQuestionByUser(username);
            return data;
        }

        public DataTable loadSubject()
        {
            DataTable data = SubjectDao.Instance.loadSubject();
            return data;
        }

        public int addQuestion
        (  
          string question, string answer1,
          string answer2, string answer3,
          string answer4, int selectSubject,
          int trueAnswer, int questionType,
          int accountID
        )
        {
            int count = QuestionDao.Instance.addQuestion(
                question, answer1, answer2, answer3, answer4, 
                selectSubject, trueAnswer, questionType, accountID
            );
            return count; 
        }

        public int updateQuestion
        (
          string question, string answer1,
          string answer2, string answer3,
          string answer4, int selectSubject,
          int trueAnswer, int questionType,
          int questionID
        )
        {
            int count = QuestionDao.Instance.updateQuestion(
                question, answer1, answer2, answer3, answer4,
                selectSubject, trueAnswer, questionType, questionID
            );
            return count;
        }

    }
}
