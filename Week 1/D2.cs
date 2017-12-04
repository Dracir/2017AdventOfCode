using System.IO;
using System;

namespace DracirAdvent2017
{
    public class D2
    {
        public static void Checksum (int[][] values){
            int checksum = 0;

            
            foreach (var line in values)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                foreach (var v in line)
                {
                    max = Math.Max(max,v);
                    min = Math.Min(min,v);
                }
                Console.WriteLine(max-min);
                checksum += max-min;
            }

            Console.WriteLine("" + checksum); 
        }
        public static void Checksum2 (int[][] values){
            int checksum = 0;

            
            foreach (var line in values)
            {
                int value1=0,value2 =0;
                foreach (var v1 in line)
                {
                    foreach (var v2 in line)
                    {
                        if(v1!=v2 && v1%v2 == 0)
                        {
                            value1 = v1;
                            value2 = v2;
                            break;
                        }

                    }
                }
                var r = Math.Max(value2,value1)/Math.Min(value2,value1);
                Console.WriteLine(value1 + " - " + value2 + " - " + r);
                checksum += r;
            }

            Console.WriteLine("" + checksum); 
        }
    }
}