using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Xml.Serialization;

namespace BerichtsheftManager
{
    [Obfuscation(Exclude = true)]
    public class Week
    {
        public string caption;
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool school;
        public string[] block;
        public int[] completion;
        public double[] hrs;
        public string notes;
        public override string ToString()
        {
            return caption;
        }
    }

    public class SortNode : TreeNode
    {
        public byte type;
        public int value;
    }
    
    public class Entry : SortNode
    {
        public Week linkedWeek;
        public Entry(Week toLink)
        {
            type = 2;
            linkedWeek = toLink;
            base.Text = linkedWeek.ToString();
        }
        
    }

    public class Dataset
    {
        internal static string owner = "Vorname Nachname";
        internal static List<Week> templates = new List<Week>();
        internal static ListBox curBox;
        internal static TreeView tView;

        internal static Entry[] getAllWeeks(bool checkedEntries)
        {
            var contents = new List<Entry>();
            TreeNodeCollection years = Dataset.tView.Nodes;
            for (int y = 0; y < years.Count; y++)
            {
                TreeNodeCollection months = years[y].Nodes;
                for (int m = 0; m < months.Count; m++)
                {
                    TreeNodeCollection weeks = months[m].Nodes;
                    for (int w = 0; w < weeks.Count; w++)
                    {
                        SortNode cur = (SortNode)weeks[w];
                        if (cur.type == 2)
                        {
                            Entry e = (Entry)cur;
                            if (!checkedEntries || e.Checked)
                                contents.Add(e);
                        }
                    }
                }
            }
            return contents.ToArray();
        }


        internal static void addTemplate(Week toAdd)
        {
            templates.Add(toAdd);
            if (curBox != null)
                curBox.Items.Add(toAdd);
        }

        internal static void removeTemplate(Week toDel)
        {
            templates.Remove(toDel);
            if (curBox != null)
                curBox.Items.Remove(toDel);
        }

        internal static void updateTemplate(Week oldItem, Week newItem)
        {
            int index = templates.IndexOf(oldItem);
            templates.RemoveAt(index);
            templates.Insert(index, newItem);
            if (curBox != null)
            {
                curBox.Items.RemoveAt(index);
                curBox.Items.Insert(index, newItem);
            }
        }

        internal static void addEntry(Entry toAdd)
        {
            SortNode year = addOrGetYear(toAdd.linkedWeek.start.Year);
            SortNode month = addOrGetMonth(year, toAdd.linkedWeek.start.Month);
            int insertPos = 0;
            for (; insertPos < month.Nodes.Count; insertPos++)
            {
                if (toAdd.linkedWeek.start.Day < ((Entry)month.Nodes[insertPos]).linkedWeek.start.Day)
                    break;
            } 
            month.Nodes.Insert(insertPos, toAdd);
        }

        internal static void removeEntry(Entry toRemove)
        {
            SortNode year = addOrGetYear(toRemove.linkedWeek.start.Year);
            SortNode month = addOrGetMonth(year, toRemove.linkedWeek.start.Month);
            month.Nodes.Remove(toRemove);
            if (month.Nodes.Count < 1)
            {
                month.Remove();
                if (year.Nodes.Count < 1)
                    year.Remove();
            }
                
        }

        internal static void updateEntry(Entry oldItem, Entry newItem)
        {
            removeEntry(oldItem);
            addEntry(newItem);
        }

        private static SortNode addOrGetYear(int yearToFind)
        {
            int i = 0;
            for (; i < tView.Nodes.Count; i++) //search all years
            {
                SortNode year = (SortNode)tView.Nodes[i];
                if (year.type != 0) continue;

                if (year.value == yearToFind)
                    return year;
                else if (yearToFind < year.value)
                    break;
            }
            SortNode newYear = new SortNode();
            newYear.value = yearToFind;
            newYear.type = 0;
            newYear.Text = yearToFind.ToString();
            tView.Nodes.Insert(i, newYear);
            return newYear;
        }

        private static SortNode addOrGetMonth(SortNode parentNode, int monthToFind)
        {
            int i = 0;
            for (; i < parentNode.Nodes.Count; i++)
            {
                SortNode month = (SortNode)parentNode.Nodes[i];
                if (month.type != 1) continue;

                if (month.value == monthToFind)
                    return month;
                else if (monthToFind < month.value)
                    break;
            }
            SortNode newMonth = new SortNode();
            newMonth.value = monthToFind;
            newMonth.type = 1;
            newMonth.Text = resolveMonthName(monthToFind);
            parentNode.Nodes.Insert(i, newMonth);
            return newMonth;
        }

        private static string resolveMonthName(int month)
        {
            string[] names = {"1-Januar", "2-Febuar", "3-März", "4-April", "5-Mai", "6-Juni", 
                                 "7-Juli", "8-August", "9-September", "10-Oktober", "11-November", "12-Dezember"};
            if (month > 0 && month < 12)
                return names[month - 1];
            return "";
        }

    }

}
