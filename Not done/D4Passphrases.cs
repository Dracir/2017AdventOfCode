using System.IO;
using System;
using System.Text.RegularExpressions;

namespace DracirAdvent2017
{
    public class D4Passphrases
    {

        public static void Part1(){
            string[] passphrases = File.ReadAllLines("Files/D4PassPhrases.txt");
            var nbValid = 0;
            
            foreach (var line in passphrases)
            {
                var words = line.Split(" ");
                var p = " " + line + " ";
                nbValid++;
                foreach (var w in words)
                {
                    Regex r = new Regex(" " + w + " ");
                    var matchs = r.Matches(p);
                    if(matchs.Count > 1){
                        nbValid--;
                        Console.WriteLine("duplicate : " + w  + " in " + p);
                        break;
                    }
                }

                
                Console.WriteLine(nbValid);
            }
        }
    }
}