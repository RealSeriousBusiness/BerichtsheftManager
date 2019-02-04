using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.Reflection;
using System.Windows.Forms;

namespace BerichtsheftManager
{
    [Obfuscation(Exclude = true)]
    public class bhdb
    {
        public Week[] weeks;
        public Week[] templates;
        public string owner;
    }

    public class DataLoader
    {
        internal static bool treeview, loadAtStart;
        internal static bool databaseIsSaved = true, fileIsCreated = false;
        internal static string datapath = "";
        internal static string filename
        {
            get
            {
                string[] buffer = datapath.Split('\\');
                return buffer[buffer.Length - 1];
            }
        }

        internal static void loadSettings()
        {
            string[] settings = new string[] { "1", "1", "" }; //standardsettings
            try
            {
                settings = File.ReadAllText("settings.ini").Split('|'); //overwrite standard settings with own
            }
            catch (Exception)
            {
                using (FileStream file = new FileStream("settings.ini", FileMode.OpenOrCreate))
                {
                    foreach (string element in settings)
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(element + "|");
                        file.Write(buffer, 0, buffer.Length);
                    }
                    file.Close();
                }
            }
            if (settings[0].Equals("1")) //setting for treeview at 0
                treeview = true;
            if (settings[1].Equals("1")) //setting for loadpath at 1
                loadAtStart = true;
            if (File.Exists(settings[2])) //check if given file exist
                datapath = settings[2];
        }

        internal static void saveSettings()
        {
            new Thread(new ThreadStart(delegate
            {
                string[] settings = new string[] { "1", "1", "" }; //standardsettings
                if (!treeview)
                    settings[0] = "0";
                if (!loadAtStart)
                    settings[1] = "0";
                if (datapath != null && File.Exists(datapath))
                    settings[2] = datapath;

                using (FileStream file = new FileStream("settings.ini", FileMode.OpenOrCreate))
                {
                    foreach (string element in settings)
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(element + "|");
                        file.Write(buffer, 0, buffer.Length);
                    }
                    file.Close();
                }
            }
            )).Start();
        }

        internal static void loadDataFromByteArray(byte[] toload)
        {
            MemoryStream stream = new MemoryStream(toload);
            loadDataFromStream(stream);
            
        }

        internal static byte[] saveDataToByteArray()
        {
            MemoryStream stream = new MemoryStream();
            saveDataToStream(stream);
            byte[] output = new byte[stream.Length];
            stream.Read(output, 0, output.Length);
            return output;
        }

        internal static bool loadDataFromFile(string toload)
        {
            using(FileStream fs = new FileStream(toload, FileMode.Open))
            {
                try
                {
                    loadDataFromStream(fs);
                    fs.Close();
                }
                catch (Exception)
                {
                    fs.Close();
                    return false;
                }
            }
            return true;
        }

        internal static void saveDataToFile(string tosave)
        {
            new Thread(new ThreadStart(delegate
            {
                using (FileStream fs = new FileStream(tosave, FileMode.Create))
                {
                    saveDataToStream(fs);
                    fs.Close();
                }
            }
            )).Start();
        }

        private static void loadDataFromStream(Stream source)
        {
            XmlSerializer sr = new XmlSerializer(typeof(bhdb));
            bhdb db = (bhdb)sr.Deserialize(source);

            Dataset.tView.Nodes.Clear();
            for (int i = 0; i < db.weeks.Length; i++)
                Dataset.addEntry(new Entry(db.weeks[i]));

            for (int i = 0; i < db.templates.Length; i++)
                Dataset.templates.Add(db.templates[i]);
        }

        private static void saveDataToStream(Stream destination)
        {
            bhdb db = new bhdb();
            db.owner = Dataset.owner;

            Entry[] entries = Dataset.getAllWeeks(false);
            Week[] weeks = new Week[entries.Length];
            for (int i = 0; i < weeks.Length; i++)
                weeks[i] = entries[i].linkedWeek;

            db.weeks = weeks;
            db.templates = Dataset.templates.ToArray();

            XmlSerializer sr = new XmlSerializer(typeof(bhdb));
            sr.Serialize(destination, db);
        }

        internal static string getLastfile()
        {
            if (File.Exists(datapath))
                return datapath;
            else
                return null;
        }
    }
}
