using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BookDao
    {
            private static BookDao instance;
            public static BookDao Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new BookDao();
                    }
                    return BookDao.instance;
                }
                set
                {
                    BookDao.instance = value;
                }
            }

            public BookDao() { }

            public async Task<DataTable> loadBook()
            {
                string query = (
                    "Select [BookName] from [Book]"
                );

                DataTable data = await DataProvider
                .Instance
                    .ExcuteQuery(query);
                return data;
            }
     }
}
