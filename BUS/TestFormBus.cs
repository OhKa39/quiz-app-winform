using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class TestFormBus
    {
        private static TestFormBus instance;
        public static TestFormBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestFormBus();
                }
                return TestFormBus.instance;
            }
            set
            {
                TestFormBus.instance = value;
            }
        }

        public TestFormBus() { }

        public DataTable loadQuestionsTest(
            int rowNumber, int IsOK, int subjectID, int questionType
        )
        {
            DataTable data = QuestionDao.Instance.loadQuestionsTest(
                   rowNumber, IsOK, subjectID, questionType
            );

            return data;
        }
    }
}
