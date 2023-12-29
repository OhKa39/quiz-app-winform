using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SubjectDao
    {
        private static SubjectDao instance;
        public static SubjectDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubjectDao();
                }
                return SubjectDao.instance;
            }
            set
            {
                SubjectDao.instance = value;
            }
        }

        public SubjectDao() { }

        public async Task<DataTable> loadSubjectByBookName(string bookname)
        {
            string query = "SELECT [SubjectName] FROM [SUBJECT], [Book], [BookSubject] where [Subject].[SubjectID] = [BookSubject].[SubjectID] and [Book].[BookID] = [BookSubject].[BookID] and [BookName] = @BookName";
            DataTable data = await DataProvider.Instance.ExcuteQuery(query, new object[] {bookname});
            return data;
        }
    }
}
