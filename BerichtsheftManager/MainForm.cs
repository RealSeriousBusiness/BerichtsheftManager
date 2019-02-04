using System;
using System.Globalization;
using System.Windows.Forms;

namespace BerichtsheftManager
{
    public partial class MainForm : Form
    {
        bool isSaved = true, loaded = false, vorlageEdit = false, vorlageUse = false;
        Entry loadedEntry = null;

        public MainForm(bool vorlageEdit = false)
        {
            InitializeComponent();
            DateDateSelected(null, null);
            this.vorlageEdit = vorlageEdit;
            if (vorlageEdit) displayTemplateName();
            loaded = true;
        }

        public MainForm(Entry entryToLoad, bool vorlageUse = false, bool vorlageEdit = false)
        {
            InitializeComponent();
            this.loadedEntry = entryToLoad;
            Week weekToLoad = loadedEntry.linkedWeek;
            DateDateSelected(null, null);
            for (int day = 0; day < 5; day++) //browser thro all days
            {
                TextBox[] curDay = getTextFields(day); //get all textboxes of one day
                string[] lines = weekToLoad.block[day].Split('\n'); //get all lines of one day
                for (int i = 0; i < lines.Length - 1; i++) //copy all lines to all textboxes of one day
                    curDay[i].Text = lines[i];

                completions[day].Value = weekToLoad.completion[day];
                dayhrs[day].Text = weekToLoad.hrs[day].ToString();
            }
            calendar.SelectionStart = weekToLoad.start;
            DateDateSelected(null, null);

            radioButtonSchule.Checked = weekToLoad.school;
            radioButtonBetrieb.Checked = !weekToLoad.school;

            notes = weekToLoad.notes;
            
            this.vorlageUse = vorlageUse;
            this.vorlageEdit = vorlageEdit;
            if (vorlageEdit)
            {
                textBoxVorlageName.Text = weekToLoad.caption;
                displayTemplateName();
            }
                
            isSaved = true;
            loaded = true;
        }

        private void displayTemplateName()
        { 
            textBoxFrom.Hide();
            textBoxTo.Hide();
            buttonChoose.Hide();
            labelTo.Hide();
            textBoxVorlageName.Visible = true;
        }

        DateTime start;
        DateTime end;
        string notes = "";
        void DateDateSelected(object sender, DateRangeEventArgs e)
        {
            start = calendar.SelectionStart.AddDays(-(int)calendar.SelectionStart.DayOfWeek + 1); //get first day of week
            end = start.AddDays(4); //get last day of selected week

            textBoxFrom.Text = start.Day + "." + start.Month + "." + start.Year; //set first day of week in textbox
            textBoxTo.Text = end.Day + "." + end.Month + "." + end.Year; //set last day of week in textbox
            calendar.Hide(); //hide the calender after everything is done
            
            Label[] towrite = { labelDate1, labelDate2, labelDate3, labelDate4, labelDate5 }; //get all labels for date of every week of the day
            DateTime wholeWeek = start;
            foreach (Label l in towrite)
            {
                l.Text = wholeWeek.Day + "." + wholeWeek.Month + "." + wholeWeek.Year; //set the text of the current label to the date
                wholeWeek = wholeWeek.AddDays(1); //hop to next day
            }

        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (!calendar.Visible)
                calendar.Show();
            else
                calendar.Hide();
        }

        private void jumpToNextControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                this.SelectNextControl((Control)sender, true, true, true, true);
        }

        private TrackBar[] completions
        { get { return new TrackBar[] { trackBarMon, trackBarTue, trackBarWed, trackBarThu, trackBarFri }; } } //get all comp trackbars

        private TextBox[] dayhrs
        { get { return new TextBox[] { textBoxHrMon, textBoxHrTue, textBoxHrWed, textBoxHrThu, textBoxHrFri }; } } //get all boyes with given hrs


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
                switch (MessageBox.Show("Möchtest du die vorgenommenden Änderungen speichern?", "Speichern?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        Week curWeek = new Week(); //create new week
                        curWeek.caption = textBoxFrom.Text + " - " + textBoxTo.Text;
                        curWeek.start = this.start;
                        curWeek.end = this.end;
                        curWeek.school = radioButtonSchule.Checked;
                        curWeek.notes = notes;

                        curWeek.block = new string[5];
                        curWeek.completion = new int[5];
                        curWeek.hrs = new double[5];

                        int totalCompletion = 0;
                        for (int day = 0; day < 5; day++) //browse thro all days
                        {
                            foreach (TextBox t in getTextFields(day)) //get all textfields of the days beginning with 0
                                curWeek.block[day] += t.Text + '\n';
                            curWeek.completion[day] = completions[day].Value;
                            totalCompletion += completions[day].Value; //add values to totalcompletetion will be later divided by 5

                            double hr = 0;
                            Double.TryParse(dayhrs[day].Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out hr);
                            curWeek.hrs[day] = hr;
                        }

                        CultureInfo c = CultureInfo.CurrentCulture;
                        int weekNum = c.Calendar.GetWeekOfYear(start, c.DateTimeFormat.CalendarWeekRule, c.DateTimeFormat.FirstDayOfWeek); //not ISO 8601 compatible
                        curWeek.caption = !vorlageEdit ? "KW " + weekNum + "; " + (radioButtonSchule.Checked ? "BS" : "DU") + "; "  + start.Day + "." + start.Month + " - " + end.Day + "." + end.Month + " ("  + (totalCompletion / 5) + "%" + ")" : textBoxVorlageName.Text;

                        if (!vorlageEdit)
                            if (loadedEntry == null || vorlageUse)
                                Dataset.addEntry(new Entry(curWeek));
                            else
                                Dataset.updateEntry(loadedEntry, new Entry(curWeek));
                        else
                            if (loadedEntry == null)
                                Dataset.addTemplate(curWeek);
                            else
                                Dataset.updateTemplate(loadedEntry.linkedWeek, curWeek);

                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }

        private TextBox[] getTextFields(int dayOfTheWeek)
        {
            //data of the week with every single line
            TextBox[] mon = { textBoxB1L1, textBoxB1L2, textBoxB1L3, textBoxB1L4, textBoxB1L5, textBoxB1L6 };
            TextBox[] tue = { textBoxB2L1, textBoxB2L2, textBoxB2L3, textBoxB2L4, textBoxB2L5, textBoxB2L6 };
            TextBox[] wed = { textBoxB3L1, textBoxB3L2, textBoxB3L3, textBoxB3L4, textBoxB3L5, textBoxB3L6 };
            TextBox[] thu = { textBoxB4L1, textBoxB4L2, textBoxB4L3, textBoxB4L4, textBoxB4L5, textBoxB4L6 };
            TextBox[] fri = { textBoxB5L1, textBoxB5L2, textBoxB5L3, textBoxB5L4, textBoxB5L5, textBoxB5L6 };
            switch (dayOfTheWeek)
            {
                case 0:return mon;
                case 1:return tue;
                case 2:return wed;
                case 3:return thu;
                case 4:return fri;
                default: return null;
            }
        }

        void ButtonMoreClick(object sender, EventArgs e)
        {
            Bemerkungen b = new Bemerkungen(notes);
            b.saveNotes += new Action<string>(saveNotes);
            b.ShowDialog();
        }

        void saveNotes(string notes)
        {
            if (!this.notes.Equals(notes))
            {
                this.notes = notes;
                unsaved(null, null);
            }
        }

        void refreshHrs(object sender, EventArgs e)
        {
            double d;
            foreach (TextBox t in dayhrs)
                if (!Double.TryParse(t.Text.Replace(',', '.'), out d))
                    t.Text = "0,0";
        }

        internal void unsaved(object sender, EventArgs e)
        {
            if (isSaved && loaded)
            {
                isSaved = false;
                this.Text += "*";
            }
        }

    }
}
