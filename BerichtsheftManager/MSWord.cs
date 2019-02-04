using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Novacode;
using System.Drawing.Printing;

namespace BerichtsheftManager
{
    public class MSWord : IDisposable
    {
        static int filecount = 0;
        public MSWord()
        {
            Dispose();
            if (!Directory.Exists("cache"))
            {
                DirectoryInfo di = Directory.CreateDirectory("cache");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        internal string generateDocument(Week touse)
        {
            filecount++;
            string filepath = "cache\\temp" + filecount + ".docx";
            
            File.WriteAllBytes(filepath, BerichtsheftManager.Properties.Resources.template);

            DocX doc = DocX.Load(filepath);
            DateTime start = touse.start;
            DateTime end = touse.end;
            doc.ReplaceText("[NAME]", Dataset.owner);
            doc.ReplaceText("[START]", start.Day + "." + start.Month);
            doc.ReplaceText("[END]", end.Day + "." + end.Month);
            doc.ReplaceText("[YEAR]", start.Year.ToString());
            doc.ReplaceText("[NOTES]", touse.notes);

            for (int day = 0; day < 5; day++)
            {
                string[] lines = touse.block[day].Split('\n');
                for (int line = 0; line < 6; line++)
                    doc.ReplaceText("[B" + day + "Z" + line + "]", lines[line]);
                doc.ReplaceText("[B" + day + "S]", touse.hrs[day].ToString());
            }

            doc.Save();
            FileInfo f = new FileInfo(filepath);
            f.Attributes = FileAttributes.Hidden;

            return filepath;
        }

        internal void openDocument(string open)
        {
            if (open.Contains(".docx"))
                Process.Start(open);
        }

        internal void printDocument(string toPrint)
        {
            printDocument(new String[] {toPrint});
        }

        internal void printDocument(string[] toPrint)
        {
            PrintDialog pd = new PrintDialog();
            pd.UseEXDialog = false;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                for(int i = 0; i < toPrint.Length; i++)
                {
                    ProcessStartInfo info = new ProcessStartInfo(toPrint[i]);
                    info.Verb = "PrintTo";
                    info.Arguments = pd.PrinterSettings.PrinterName;
                    info.CreateNoWindow = true;
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(info);
                }
            }
        }

        internal void removeDocument(string toRemove)
        {
            File.Delete(toRemove);
        }

        public void Dispose()
        {
            try
            {
                foreach (string f in Directory.GetFiles("cache"))
                    File.Delete(f);
                Directory.Delete("cache");
                filecount = 0;
            }
            catch (Exception) { }
        }
    }
}
