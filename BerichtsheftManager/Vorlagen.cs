using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BerichtsheftManager
{
    public partial class Vorlagen : Form
    {
        public Vorlagen()
        {
            InitializeComponent();
        }

        Week selected;
        private void Vorlagen_Load(object sender, EventArgs e)
        {
            Dataset.curBox = listBoxVorlagen;
            toggleButtons(false);
            listBoxVorlagen.Items.AddRange(Dataset.templates.ToArray());
        }

        private void Vorlagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dataset.curBox = null;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            new MainForm(new Entry(selected), false, true).Show();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            listBoxVorlagen.ClearSelected();
            new MainForm(true).Show();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchtest du diesen EIntrag wirklich löschen?", "Löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Dataset.removeTemplate(selected);
        }

        private void listBoxVorlagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (Week)listBoxVorlagen.SelectedItem;
            bool toggle = false;
            if (selected != null)
                toggle = true;
            toggleButtons(toggle);
           
        }

        private void toggleButtons(bool toggle)
        {
            buttonDel.Enabled = toggle;
            buttonOpen.Enabled = toggle;
            buttonUp.Enabled = listBoxVorlagen.SelectedIndex > 0 && toggle;
            buttonDown.Enabled = listBoxVorlagen.SelectedIndex < listBoxVorlagen.Items.Count -1 && toggle;
        }

        
    }
}
