using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CreateAccountBus
    {
        private static CreateAccountBus instance;
        public static CreateAccountBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateAccountBus();
                }
                return CreateAccountBus.instance;
            }
            set
            {
                CreateAccountBus.instance = value;
            }
        }

        public bool CreateAccount(string username, string password, string passwordDouble, string fullname, int role)
        {
            return true;
        }
    }
}
