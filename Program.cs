using System;
using System.IO;

namespace DracirAdvent2017
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var fileContent = File.ReadAllLines("D2/D2p1.txt");
            var ints = InputParser.StringExcellToIntArrays(fileContent, '\t');
            foreach (var i in ints)
            {
                foreach (var j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.Write("\n");
            }
            D2.Checksum2(ints);
        }
    }
}
