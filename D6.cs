using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class D6
{
        
    public static void Part1(){
        var values = InputParser.FileIntArray("D6.txt","\t");
        var PastValues = new List<int[]>();
        Printer.Print(values);
        int steps = 0;

        while(PastValues.Where(a=> a.SequenceEqual(values)).Count() == 0){
            PastValues.Add((int[])values.Clone());

            int maxI = Utils.IndexOfFirstMax(values);
            var bank = values[maxI];
            values[maxI] = 0;
            for (int i = maxI+1; i < maxI+1+bank; i++)
            {
                values[i%values.Length]++;
            }
            Printer.Print(values);
            steps ++;
        }

        var index = PastValues.FindIndex(async=>async.SequenceEqual(values));
        
        Console.WriteLine(String.Format("{0} steps with repeated seen after {1} cycles",steps,(PastValues.Count- index)));
    }
}
