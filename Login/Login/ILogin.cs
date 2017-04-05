using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    interface ILogin
    {
        event Action RunClicked; //event for run button clicked
        event Action<string> RemoveClicked;
        event Action AddClicked;
        event Action<string> EditClicked;
        event Action<int> CharacterDelayChanged;
        event Action<int> GameDelayChanged;

        int numAccounts { set; }
        string BoxRemover { set; }
        string BoxAdder { set;}
    }
}
