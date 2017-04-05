using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class AccountObject
    {
        public string nickname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return nickname + "\t" + email;
        }
    }


}
