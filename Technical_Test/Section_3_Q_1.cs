using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WriteCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = SearchFiles(@"f:\", "log.png");
            //var data = FindFile(@"f:\", "log.txt");

            //Console.WriteLine(data);
            int j = 1;
            foreach (var i in data)
            {

                Console.WriteLine(j + ". " + i);
                j++;

            };
            Console.WriteLine("input Number to Delete File");
        }

        public static IEnumerable<string> SearchFiles(string rootFolder, string searchParam)
        {
            var files = new List<string>();

            foreach (var file in Directory.EnumerateFiles(rootFolder).Where(x => x.Contains(searchParam)))
            {
                files.Add(file);
            }
            foreach (var subDir in Directory.EnumerateDirectories(rootFolder))
            {
                try
                {
                    files.AddRange(SearchFiles(subDir, searchParam));
                }
                catch (UnauthorizedAccessException ex)
                {

                }
            }

            return files;
        }



    }
}