using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ChooseTestBus
    {
        private static ChooseTestBus instance;
        public static ChooseTestBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChooseTestBus();
                }
                return ChooseTestBus.instance;
            }
            set
            {
                ChooseTestBus.instance = value;
            }
        }

        public ChooseTestBus() { }

        public DataTable loadSubject()
        {
            DataTable data = SubjectDao.Instance.loadSubject();
            return data;
        }
    }
}
