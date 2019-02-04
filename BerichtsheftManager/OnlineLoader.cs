using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BerichtsheftManager
{
    public partial class OnlineLoader : Form
    {
        public OnlineLoader()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "" && textBoxPassword.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Bitte Benutzernamen und Passwort eingeben!");
            }
        }

        private void login(string username, string password)
        {
            new Thread(new ThreadStart(delegate
            {
                WebClient wc = new WebClient();
                wc.Proxy = null;
                string data = wc.DownloadString("http://rubyx377.tk/bhmanager/default.aspx?user=" + username + "&password=" + password);

                byte[] bytes = Convert.FromBase64String(data);

                DataLoader.loadDataFromByteArray(bytes);
               


            })).Start();
        }

        private void logoutAndSave()
        {
            byte[] data = DataLoader.saveDataToByteArray();
        }

        private void execute(Delegate toExecute)
        {
            this.Invoke((MethodInvoker)toExecute);
        }
    }
}
