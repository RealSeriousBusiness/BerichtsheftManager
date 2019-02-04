using System;
using System.Windows.Forms;

namespace BerichtsheftManager
{
    public partial class Bemerkungen : Form
    {
        internal event Action<string> saveNotes;
        public Bemerkungen(string notes)
        {
            InitializeComponent();
            textBoxNotes.Text = notes;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveNotes(textBoxNotes.Text);
            Close();
        }

        private void buttonCanc_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
