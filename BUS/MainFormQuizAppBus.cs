using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

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


        public async Task<DataTable> loadQuestionByUser(string username, int page, int offset)
        {

            DataTable data = await QuestionDao.Instance.loadQuestionByUser(username, page, offset);
            return data;
        }
    }
}
