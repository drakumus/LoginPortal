using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class LoginController
    {


        public static readonly string FILEDIRECTORY = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GW2Login");
        public static readonly string FILEPATH = System.IO.Path.Combine(FILEDIRECTORY, "save.txt");

        private int waitCharacter = 20;
        private int waitGame = 40;

        private GW2Login loginWindow;
        Dictionary<string, AccountObject> accountLookUp;
        private string currentSelection;

        private LoginModule activeLauncher;

        public LoginController(GW2Login window)
        {
            currentSelection = "";
            loginWindow = window;
            accountLookUp = new Dictionary<string, AccountObject>();

            LoadAccounts();

            activeLauncher = new LoginModule();

            loginWindow.AddClicked += AddHandler;
            loginWindow.EditClicked += EditHandler;
            loginWindow.RemoveClicked += RemoveHandler;
            loginWindow.RunClicked += HandleRunClicked;
            loginWindow.CharacterDelayChanged += HandleCharacterUpDownChanged;
            loginWindow.GameDelayChanged += HandleGameUpDownChanged;
        }

        private void LoadAccounts()
        {
            //load from a text document account names and passwords.
            string line;
            string[] lineSplit;
            AccountObject objTemp = new AccountObject();
            FileInfo f = new FileInfo(FILEPATH);
            DirectoryInfo d = new DirectoryInfo(FILEDIRECTORY);

            if (!d.Exists)
            {
                d.Create();
            }
            if (!f.Exists)
            {
                f.Create().Dispose();
            }
            else
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(f.ToString());
                    while ((line = file.ReadLine()) != null)
                    {
                        lineSplit = line.Split('\t');
                        objTemp.nickname = lineSplit[0];
                        objTemp.email = lineSplit[1];
                        objTemp.password = lineSplit[2];

                        accountLookUp.Add(objTemp.nickname, objTemp);
                    }

                    RefreshListBox();
                    loginWindow.numAccounts = accountLookUp.Count;

                    file.Close();
                }
                catch
                {

                }
            }
        }

        private void WriteAccounts()
        {

            string line;
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FILEPATH))
                {

                    foreach (AccountObject obj in accountLookUp.Values)
                    {
                        line = obj.nickname + "\t" + obj.email + "\t" + obj.password;
                        file.WriteLine(line);
                    }
                }
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }

        public void AddHandler()
        {
            AccountForm form = new AccountForm();
            form.DoneClicked += DoneAdd;
            form.Show();
        }

        public void EditHandler(string currentSelection)
        {
            if (currentSelection != null) {
                AccountForm form = new AccountForm();
                form.nameText = currentSelection;
                if (accountLookUp.ContainsKey(currentSelection))
                {
                    form.emailText = accountLookUp[currentSelection].email;
                    form.passwordText = accountLookUp[currentSelection].password;
                }
                form.DoneClicked += DoneAdd;
                this.currentSelection = currentSelection;
                form.Show();
            }
        }

        private void DoneAdd(AccountObject ao)
        {
            if (ao.nickname.Length > 0 && ao.email.Length > 0 && ao.password.Length > 0)
            {
                if (!accountLookUp.ContainsKey(ao.nickname))
                {

                    loginWindow.BoxAdder = ao.nickname;
                    accountLookUp.Add(ao.nickname, ao);
                    if (currentSelection != "" && currentSelection != ao.nickname)
                    {
                        accountLookUp.Remove(currentSelection);
                        loginWindow.BoxRemover = currentSelection;
                        RefreshListBox();
                        currentSelection = "";
                    }
                }
                else
                {
                    accountLookUp[ao.nickname] = ao;
                }
                loginWindow.numAccounts = accountLookUp.Keys.Count;
                //call write to text file here after clearing it
                File.WriteAllText(FILEPATH, String.Empty);
                WriteAccounts();
            }
        }

        public void RemoveHandler(string currentSelection)
        {
            if (accountLookUp.ContainsKey(currentSelection))
            {
                accountLookUp.Remove(currentSelection);
                loginWindow.BoxRemover = currentSelection;
                RefreshListBox();
                loginWindow.numAccounts = accountLookUp.Keys.Count;
                File.WriteAllText(FILEPATH, String.Empty);
                WriteAccounts();

            }
        }

        private void RefreshListBox()
        {
            foreach (string s in accountLookUp.Keys)
                loginWindow.BoxAdder = s;
        }

        private void HandleCharacterUpDownChanged(int value)
        {
            waitCharacter = value;
        }

        private void HandleGameUpDownChanged(int value)
        {
            waitGame = value;
        }

        private void HandleRunClicked()
        {
            AccountObject obj;
            string email;
            string password;
            foreach(string s in accountLookUp.Keys)
            {
                obj = accountLookUp[s];
                email = obj.email;
                password = obj.password;
                activeLauncher.LaunchGW2(email, password, waitCharacter, waitGame);
            }
        }
    }
}
