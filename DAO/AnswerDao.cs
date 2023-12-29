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

        public async Task<int?> createAnswerByQuestionID
        (
            int? questionID,
            string answerDetail,
            string isTrue
        )
        {
            string query = "createAnswer @questionID , @answerDetail , @isTrue";
            int? count = await DataProvider
                .Instance
                .ExcuteScalar(
                    query,
                    new object[] { questionID, answerDetail, isTrue}
                );
            return count;
        }

        public async Task<DataTable> loadAnswerByQuestionID(int questionID)
        {
            string query = "loadAnswerByQuestionID @questionID";
            DataTable dt = await DataProvider.Instance.ExcuteQuery(query, new object[] {questionID});
            return dt;
        }
    }
}
