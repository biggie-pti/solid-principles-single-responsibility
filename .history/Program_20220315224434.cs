using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Solid
{

    public class Journal
    {

        private readonly List<string> textEntries = new List<string>();
        private static int count = 0;

        public int AddEntry (string text)
        {
            textEntries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry (int index)
        {
            textEntries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, textEntries);
        }

    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename)) File.WriteAllText(filename, journal.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var journal = new Journal();
            journal.AddEntry("I am actually doing testing for you");
            journal.AddEntry("Again i am testing things");
            Console.WriteLine(journal);

            var persistence = new Persistence();
            var filename = @"C:\temp\journal.ttxt";
            persistence.SaveToFile(journal, filename, true);
            Process.Start(filename);
        }
    }
}
