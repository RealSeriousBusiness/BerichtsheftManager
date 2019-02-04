using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace BerichtsheftManager
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        void MenuLoad(object sender, EventArgs e)
        {
            DataLoader.loadSettings(); //load settings.ini
            checkBoxTree.Checked = DataLoader.treeview; //set checkbox tree
            checkBoxFile.Checked = DataLoader.loadAtStart; //set checkbox loadatstart
            toggleButtons(false);

            textBoxName.Text = Dataset.owner;
            if (DataLoader.loadAtStart && DataLoader.getLastfile() != null && DataLoader.loadDataFromFile(DataLoader.getLastfile()))
            {
                this.Text += " - " + DataLoader.filename;
                labelFilePath.Text = DataLoader.datapath;
            }
            else
            {
                this.Text += " - Unbenannt.bhdb";
            }   
            Dataset.tView = treeViewMain;
        }

        void CheckBoxTreeCheckedChanged(object sender, EventArgs e)
        {
            DataLoader.treeview = checkBoxTree.Checked;
            if (checkBoxTree.Checked)
                treeViewMain.ExpandAll();
            else
                treeViewMain.CollapseAll();
        }

        void CheckBoxFileCheckedChanged(object sender, EventArgs e)
        {
            DataLoader.loadAtStart = checkBoxFile.Checked;
        }

        void TextBoxNameLeave(object sender, EventArgs e)
        {
            Dataset.owner = textBoxName.Text;
        }

        private void checkBoxMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            treeViewMain.CheckBoxes = checkBoxMultiSelect.Checked;
        }

        //-------TOOLSTRIPS-------
        void ÖffnenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Berichtsheft Datenbank (*.bhdb)|*.bhdb";
            if (fd.ShowDialog() == DialogResult.OK && File.Exists(fd.FileName))
            {
                if (DataLoader.loadDataFromFile(fd.FileName))
                {
                    DataLoader.datapath = fd.FileName;
                    DataLoader.fileIsCreated = true;
                    DataLoader.databaseIsSaved = true;
                }
                else
                {
                    MessageBox.Show("Konnte Datei nicht laden! Stell sicher dass die Datei nicht beschädigt ist.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataLoader.fileIsCreated)
            {
                DataLoader.saveDataToFile(DataLoader.datapath);
                DataLoader.databaseIsSaved = true;
            }
            else
            {
                specihernUnterToolStripMenuItem.PerformClick();
            }
        }

        private void specihernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Berichtsheft Datenbank (*.bhdb)|*.bhdb";
            if (sd.ShowDialog() == DialogResult.OK && sd.FileName != String.Empty)
            {
                DataLoader.saveDataToFile(sd.FileName);
                DataLoader.datapath = sd.FileName;
                DataLoader.databaseIsSaved = true;
                DataLoader.fileIsCreated = true;
            }
        }

        private void vorlageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Vorlagen().Show();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = string.Empty;
            if (!DataLoader.databaseIsSaved)
            {
                msg = DataLoader.fileIsCreated ?
                "Änderungen in " + DataLoader.filename + " nicht gespeichert. Möchtest du sie speichern?" :
                "Die Unbenannte Datenbank wurde noch nicht gespeichert. Möchtest du sie speichern?";

                switch (MessageBox.Show(msg, "Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        speichernToolStripMenuItem.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
            word.Dispose();
            DataLoader.saveSettings();
        }

        //-----BUTTONS-----
        Entry selected = null;
        MSWord word = new MSWord();

        void ButtonNewClick(object sender, EventArgs e)
        {
            contextMenuVorlagen.Items.Clear();
            contextMenuVorlagen.Items.Add("Ohne Vorlage", null, new EventHandler(delegate(Object ob, EventArgs args)
            {
                new MainForm().ShowDialog();
            }));
            if (Dataset.templates.Count > 0)
            contextMenuVorlagen.Items.Add(new ToolStripSeparator());
            for (int i = 0; i < Dataset.templates.Count; i++)
            {
                Week curTemplate = Dataset.templates[i];
                contextMenuVorlagen.Items.Add(curTemplate.caption, null, new EventHandler(delegate(Object obj, EventArgs ev)
                {
                    new MainForm(new Entry(curTemplate), true).Show();
                }));
            }
            contextMenuVorlagen.Show(this.PointToScreen(new Point(buttonNew.Location.X, buttonNew.Location.Y + buttonNew.Size.Height)));
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (!checkBoxMultiSelect.Checked)
            {
                if (MessageBox.Show("Möchtest du wirklich den ausgewählten Eintrag entfernen?", "Löschen?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Dataset.removeEntry(selected);
            }
            else
            {
                Entry[] checkedItems = Dataset.getAllWeeks(true);
                if (MessageBox.Show("Möchtest du wirklich diese " + checkedItems.Length + " Woche(n) entfernen?", "Löschen?", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < checkedItems.Length; i++)
                        Dataset.removeEntry(checkedItems[i]);
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (!checkBoxMultiSelect.Checked)
            {
                if (MessageBox.Show("Möchtest du den ausgewählten Eintrag drucken?", "Drucken?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String path = word.generateDocument(selected.linkedWeek);
                    word.printDocument(path);
                }
            }
            else
            {
                Entry[] checkedItems = Dataset.getAllWeeks(true);
                if (MessageBox.Show("Möchtest du diese " + checkedItems.Length + " Woche(n) drucken?", "Drucken?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String[] paths = new String[checkedItems.Length];
                    for (int i = 0; i < paths.Length; i++)
                        paths[i] = word.generateDocument(checkedItems[i].linkedWeek);
                    word.printDocument(paths);
                }
            }
          
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            String path = word.generateDocument(selected.linkedWeek);
            word.openDocument(path);     
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            new MainForm(selected).Show();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OnlineLoader().ShowDialog();
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SortNode cur = (SortNode)treeViewMain.SelectedNode;
            if (cur.type == 2)
            {
                selected = (Entry)cur;
                toggleButtons(true);
            }
            else 
            {
                selected = null;
                toggleButtons(false);
            }
        }

        private void toggleButtons(bool toToggle)
        {
            buttonDel.Enabled = toToggle;
            buttonPrint.Enabled = toToggle;
            buttonOpen.Enabled = toToggle;
            buttonWord.Enabled = toToggle;
            öffnenToolStripMenuItem1.Enabled = toToggle;
            löschenToolStripMenuItem.Enabled = toToggle;
            mitWordÖffnenToolStripMenuItem.Enabled = toToggle;
            druckenToolStripMenuItem.Enabled = toToggle;
        }

        private void treeViewMain_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            for (int i = 0; i < node.Nodes.Count; i++)
                node.Nodes[i].Checked = node.Checked;
        }

        private void treeViewMain_Click(object sender, EventArgs e)
        {
            treeViewMain.Refresh();
        }


    }
}
