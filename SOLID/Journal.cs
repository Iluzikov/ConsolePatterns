using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID
{
    public class PersistenceManager
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    public class Journal
        {
            private readonly List<string> entries = new List<string>();

            private static int count = 0;

            public void AddEntry(string text)
            {
                entries.Add(text);
            }

            public void RemoveEntry(int index)
            {
                if (index < entries.Count && index >= 0)
                    entries.RemoveAt(index);
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entries);
            }

            // breaks single responsibility principle
            public void Save(string filename, bool overwrite = false)
            {
                File.WriteAllText(filename, ToString());
            }

            public void Load(string filename)
            {

            }

            public void Load(Uri uri)
            {

            }
        }
}
