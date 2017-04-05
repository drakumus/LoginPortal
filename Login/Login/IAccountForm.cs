using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    interface IAccountForm
    {
        event Action<AccountObject> DoneClicked;

        string nameText { set; }
        string emailText { set; }
        string passwordText { set; }
    }
}
