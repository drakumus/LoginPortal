using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class AccountForm : Form, IAccountForm
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        public string emailText
        {
            set
            {
                emailBox.Text = value;
            }
        }

        public string nameText
        {
            set
            {
                nameBox.Text = value;
            }
        }

        public string passwordText
        {
            set
            {
                passwordBox.Text = value;
            }
        }

        public event Action<AccountObject> DoneClicked;

        private void doneButton_Click(object sender, EventArgs e)
        {
            DoneClicked(new AccountObject { nickname = nameBox.Text, email = emailBox.Text, password = passwordBox.Text });
            Close();
        }
    }
}
