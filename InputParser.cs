using System.Collections.Generic;
using System.Linq;

namespace DracirAdvent2017
{
    public class InputParser
    {
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
}