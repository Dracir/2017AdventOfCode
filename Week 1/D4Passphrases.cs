using System.IO;
using System;
using System.Text.RegularExpressions;

namespace DracirAdvent2017
{
    public class D4Passphrases
    {

        public static void Part1B(){
            string[] passphrases = File.ReadAllLines("Files/D4PassPhrases.txt");
            var nbValid = 0;
            
            foreach (var line in passphrases)
            {
                var words = line.Split(" ");
                bool valid = true;
                for (int i = 0; i < words.Length; i++)
                {
                    var w = words[i];
                    for (int j = i+1; j < words.Length; j++)
                    {
                        if(w.Equals(words[j]))
                        valid = false;
                    }
                }
                if(valid)nbValid++;
            }

            Console.WriteLine(nbValid);
        }

        public static void Part2B(){
            string[] passphrases = File.ReadAllLines("Files/D4PassPhrases.txt");
            var nbValid = 0;
            
            foreach (var line in passphrases)
            {
                var words = line.Split(" ");
                bool valid = true;
                for (int i = 0; i < words.Length; i++)
                {
                    var w = words[i];
                    for (int j = i+1; j < words.Length; j++)
                    {
                        //if(w.Equals(words[j]))
                        if(isAnagram(w,words[j])) 
                            valid = false;
                    }
                }
                if(valid)nbValid++;
            }

            Console.WriteLine(nbValid);
        }

        public static bool isAnagram(string a, string b){
            if(a.Length != b.Length)
                return false;
            
            var remaining = b;
            foreach (var l in a)
            {
                if(remaining.IndexOf(l) == -1)
                    return false;
                else
                    remaining = remaining.Remove(remaining.IndexOf(l),1);
            }
            return true;
        }

        public static void Part1(){
            string[] passphrases = File.ReadAllLines("Files/D4PassPhrases.txt");
            var nbValid = 0;
            
            foreach (var line in passphrases)
            {
                var words = line.Split(" ");
                var p = " " + line + " ";
                var valid = true;
                foreach (var w in words)
                {
                    Regex r = new Regex(" " + w + " ");
                    var matchs = r.Matches(p);
                    if(matchs.Count > 1){
                        valid = false;
                        Console.WriteLine("duplicate : " + w  + " in " + p);
                        break;
                    }
                }

                if(valid)nbValid++;

                
            }
            Console.WriteLine(nbValid);
        }
    }
}