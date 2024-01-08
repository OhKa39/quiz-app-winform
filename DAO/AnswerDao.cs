using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AnswerDao
    {
        private static AnswerDao instance;
        public static AnswerDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnswerDao();
                }
                return AnswerDao.instance;
            }
            set
            {
                AnswerDao.instance = value;
            }
        }

        public AnswerDao() { }

        public async Task<DataTable> loadAnswerByQuestionID(int questionID)
        {
            string query = "loadAnswerByQuestionID @questionID";
            DataTable dt = await DataProvider.Instance.ExcuteQuery(query, new object[] {questionID});
            return dt;
        }
    }
}
