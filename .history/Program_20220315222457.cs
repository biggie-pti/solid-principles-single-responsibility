using System;
using System.Collections.Generic;

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
    class Program
    {
        static void Main(string[] args)
        {
               var journal = new Journal();
            journal.AddEntry("I am actually doing testing for you");
            journal.AddEntry("Again i am testing things");
            Console.WriteLine(journal);
        }
    }
}
