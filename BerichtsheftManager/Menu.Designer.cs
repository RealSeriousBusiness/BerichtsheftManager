/*
 * Erstellt mit SharpDevelop.
 * Benutzer: azbhaaseal
 * Datum: 02.07.2013
 * Zeit: 11:17
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace BerichtsheftManager
{
    partial class Menu
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specihernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vorlageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eintragToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mitWordÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.druckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byRubyX377ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxFile = new System.Windows.Forms.CheckBox();
            this.checkBoxTree = new System.Windows.Forms.CheckBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonWord = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.contextMenuVorlagen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonNew = new System.Windows.Forms.Button();
            this.checkBoxMultiSelect = new System.Windows.Forms.CheckBox();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewMain
            // 
            this.treeViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewMain.HideSelection = false;
            this.treeViewMain.Location = new System.Drawing.Point(11, 56);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(571, 282);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterCheck);
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(124, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Ausbildungsnachweis für";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(139, 30);
            this.textBoxName.MaxLength = 150;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(133, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Leave += new System.EventHandler(this.TextBoxNameLeave);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrint.Location = new System.Drawing.Point(497, 344);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(83, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Drucken";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.Location = new System.Drawing.Point(101, 344);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(83, 23);
            this.buttonOpen.TabIndex = 6;
            this.buttonOpen.Text = "Öffnen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.eintragToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(590, 24);
            this.menuStripMain.TabIndex = 7;
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.specihernUnterToolStripMenuItem,
            this.toolStripSeparator1,
            this.vorlageToolStripMenuItem,
            this.toolStripSeparator3,
            this.accountToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.ÖffnenToolStripMenuItemClick);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // specihernUnterToolStripMenuItem
            // 
            this.specihernUnterToolStripMenuItem.Name = "specihernUnterToolStripMenuItem";
            this.specihernUnterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.specihernUnterToolStripMenuItem.Text = "Speichern unter...";
            this.specihernUnterToolStripMenuItem.Click += new System.EventHandler(this.specihernUnterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // vorlageToolStripMenuItem
            // 
            this.vorlageToolStripMenuItem.Name = "vorlageToolStripMenuItem";
            this.vorlageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vorlageToolStripMenuItem.Text = "Vorlagen bearbeiten";
            this.vorlageToolStripMenuItem.Click += new System.EventHandler(this.vorlageToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.accountToolStripMenuItem.Text = "Account";
            this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShowShortcutKeys = false;
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // eintragToolStripMenuItem
            // 
            this.eintragToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.öffnenToolStripMenuItem1,
            this.löschenToolStripMenuItem,
            this.toolStripSeparator2,
            this.mitWordÖffnenToolStripMenuItem,
            this.druckenToolStripMenuItem});
            this.eintragToolStripMenuItem.Name = "eintragToolStripMenuItem";
            this.eintragToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.eintragToolStripMenuItem.Text = "Eintrag";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.ButtonNewClick);
            // 
            // öffnenToolStripMenuItem1
            // 
            this.öffnenToolStripMenuItem1.Name = "öffnenToolStripMenuItem1";
            this.öffnenToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.öffnenToolStripMenuItem1.Text = "Öffnen";
            this.öffnenToolStripMenuItem1.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // mitWordÖffnenToolStripMenuItem
            // 
            this.mitWordÖffnenToolStripMenuItem.Name = "mitWordÖffnenToolStripMenuItem";
            this.mitWordÖffnenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mitWordÖffnenToolStripMenuItem.Text = "Mit Word öffnen";
            this.mitWordÖffnenToolStripMenuItem.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // druckenToolStripMenuItem
            // 
            this.druckenToolStripMenuItem.Name = "druckenToolStripMenuItem";
            this.druckenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.druckenToolStripMenuItem.Text = "Drucken";
            this.druckenToolStripMenuItem.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byRubyX377ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // byRubyX377ToolStripMenuItem
            // 
            this.byRubyX377ToolStripMenuItem.Name = "byRubyX377ToolStripMenuItem";
            this.byRubyX377ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.byRubyX377ToolStripMenuItem.Text = "by RubyX377";
            // 
            // checkBoxFile
            // 
            this.checkBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFile.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxFile.Checked = true;
            this.checkBoxFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFile.Location = new System.Drawing.Point(451, 0);
            this.checkBoxFile.Name = "checkBoxFile";
            this.checkBoxFile.Size = new System.Drawing.Size(132, 24);
            this.checkBoxFile.TabIndex = 8;
            this.checkBoxFile.Text = "Dateipfad speichern";
            this.checkBoxFile.UseVisualStyleBackColor = false;
            this.checkBoxFile.CheckedChanged += new System.EventHandler(this.CheckBoxFileCheckedChanged);
            // 
            // checkBoxTree
            // 
            this.checkBoxTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTree.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTree.Checked = true;
            this.checkBoxTree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTree.Location = new System.Drawing.Point(305, 0);
            this.checkBoxTree.Name = "checkBoxTree";
            this.checkBoxTree.Size = new System.Drawing.Size(140, 24);
            this.checkBoxTree.TabIndex = 10;
            this.checkBoxTree.Text = "Baumansicht erweitern";
            this.checkBoxTree.UseVisualStyleBackColor = false;
            this.checkBoxTree.CheckedChanged += new System.EventHandler(this.CheckBoxTreeCheckedChanged);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(408, 344);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(83, 23);
            this.buttonDel.TabIndex = 11;
            this.buttonDel.Text = "Löschen";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonWord
            // 
            this.buttonWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWord.Location = new System.Drawing.Point(190, 344);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(83, 23);
            this.buttonWord.TabIndex = 12;
            this.buttonWord.Text = "Word öffnen";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(278, 33);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(35, 13);
            this.labelFile.TabIndex = 13;
            this.labelFile.Text = "Datei:";
            // 
            // labelFilePath
            // 
            this.labelFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(319, 33);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(45, 13);
            this.labelFilePath.TabIndex = 14;
            this.labelFilePath.Text = "<keine>";
            // 
            // contextMenuVorlagen
            // 
            this.contextMenuVorlagen.Name = "contextMenuVorlagen";
            this.contextMenuVorlagen.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNew.Image = global::BerichtsheftManager.Properties.Resources.spriteArrow;
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNew.Location = new System.Drawing.Point(12, 344);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(83, 23);
            this.buttonNew.TabIndex = 9;
            this.buttonNew.Text = "Neu";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNewClick);
            // 
            // checkBoxMultiSelect
            // 
            this.checkBoxMultiSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMultiSelect.AutoSize = true;
            this.checkBoxMultiSelect.Location = new System.Drawing.Point(282, 348);
            this.checkBoxMultiSelect.Name = "checkBoxMultiSelect";
            this.checkBoxMultiSelect.Size = new System.Drawing.Size(120, 17);
            this.checkBoxMultiSelect.TabIndex = 15;
            this.checkBoxMultiSelect.Text = "Mehrfache Auswahl";
            this.checkBoxMultiSelect.UseVisualStyleBackColor = true;
            this.checkBoxMultiSelect.CheckedChanged += new System.EventHandler(this.checkBoxMultiSelect_CheckedChanged);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 378);
            this.Controls.Add(this.checkBoxMultiSelect);
            this.Controls.Add(this.treeViewMain);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.checkBoxTree);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.checkBoxFile);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(603, 164);
            this.Name = "Menu";
            this.Text = "Berichtsheft-Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.MenuLoad);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Button buttonWord;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.CheckBox checkBoxTree;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.CheckBox checkBoxFile;
        private System.Windows.Forms.ToolStripMenuItem druckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitWordÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eintragToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem vorlageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem specihernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuVorlagen;
        private System.Windows.Forms.ToolStripMenuItem byRubyX377ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxMultiSelect;
    }
}
