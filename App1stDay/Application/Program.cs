using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"../../in.txt");
            string line;
            string[] words;
            Dictionary<string, int> table = new Dictionary<string, int>();
            while ((line = file.ReadLine()) != null)
            {
                words = Regex.Split(line, "[ ,.;\n!?]+");
                foreach (string word in words)
                {
                    if (table.ContainsKey(word))
                        table[word] += 1;
                    else
                        table.Add(word, 1);
                }
            }

            var orderedTable = table.OrderBy(x => -x.Value);
            int i = 0;
            foreach (var pair in orderedTable)
            {
                if (i < 10)
                    Console.WriteLine("Cuvantul \"{0}\" are {1} aparitii", pair.Key, pair.Value);
                else
                    break;
            }
        }
    }
}
