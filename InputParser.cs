using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class InputParser
{


    /* 
    * Transform the whole file, separated by <i>separator</i> to a array of int.
    Used for D6 each line has a number : 15\n23\n0\n123\n0\n4\n-2 
    */
    public static int[] FileIntArray(string filename, string separator){
        string[] items = File.ReadAllText("Files/" + filename).Split(separator);
        int[] arr = new int[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            arr[i] = Int32.Parse(items[i]);
        }
        return arr;
    }


    public static int[] StringToIntArray(string str){
        int[] arr = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            arr[i] = (int)char.GetNumericValue(str[i]);
        }
        return arr;
    }

    /* Prend chaque ligne du strs et separe par le caracter de separation */
    public static int[][] StringExcellToIntArrays(string[] strs, char separator ){
        var tabs = new List<int[]>();

        foreach (var line in strs)
        {
            var splited = line.Split(separator);
            int[] values = new int[splited.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = int.Parse(splited[i]);
            }
            tabs.Add(values);
        }

        return tabs.ToArray();
    }
}