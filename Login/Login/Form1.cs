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
    public partial class GW2Login : Form, ILogin
    {
        private string currentSelection;
        private int TimePerAccount;

        public string BoxAdder
        {
            set
            {
                accountListBox.Items.Add(value);
            }
        }

        public string BoxRemover
        {
            set
            {
                accountListBox.Items.Clear();
            }
        }

        public int numAccounts
        {
            set
            {
                TimeSpan ts = TimeSpan.FromSeconds(TimePerAccount*value);
                string output = string.Format("{2:D2}:{1:D2}:{2:D2}",
                ts.Hours,
                ts.Minutes,
                ts.Seconds);
                labelTT.Text = output;
            }
        }


        public GW2Login()
        {
            InitializeComponent();

            TimePerAccount = 60;
            TimeSpan ts = TimeSpan.FromSeconds(TimePerAccount);
            string output = string.Format("{0:D2}:{1:D2}",
                ts.Minutes,
                ts.Seconds);
            labelTPA.Text = output;
        }

        public event Action RunClicked;
        public event Action AddClicked;
        public event Action<string> EditClicked;
        public event Action<string> RemoveClicked;
        public event Action<int> CharacterDelayChanged;
        public event Action<int> GameDelayChanged;

        private void addButton_Click(object sender, EventArgs e)
        {
            AddClicked();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(currentSelection != null || currentSelection != "")
                EditClicked(currentSelection);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (currentSelection != null || currentSelection != "")
            {
                //remove from thing and repopulate?
                accountListBox.Items.Clear();
                RemoveClicked(currentSelection);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RunClicked();
        }

        private void accountListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(accountListBox.SelectedItem != null)
                currentSelection = accountListBox.SelectedItem.ToString();
        }

        private void numericUpDownCharacter_ValueChanged(object sender, EventArgs e)
        {
            CharacterDelayChanged(System.Convert.ToInt32(numericUpDownCharacter.Value));
            TimePerAccount = System.Convert.ToInt32(numericUpDownCharacter.Value + numericUpDownGame.Value);
            TimeSpan ts = TimeSpan.FromSeconds(TimePerAccount);
            string output = string.Format("{0:D2}:{1:D2}",
                ts.Minutes,
                ts.Seconds);
            labelTPA.Text = output;
        }

        private void numericUpDownGame_ValueChanged(object sender, EventArgs e)
        {
            GameDelayChanged(System.Convert.ToInt32(numericUpDownCharacter.Value));
            TimePerAccount = System.Convert.ToInt32(numericUpDownCharacter.Value + numericUpDownGame.Value);
            TimeSpan ts = TimeSpan.FromSeconds(TimePerAccount);
            string output = string.Format("{0:D2}:{1:D2}",
                ts.Minutes,
                ts.Seconds);
            labelTPA.Text = output;
        }
    }
}
