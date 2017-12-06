using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Utils
{
    public static int IndexOfFirstMax(int[] values){
        int max = int.MinValue;
        int maxI = -1;
        for (int i = 0; i < values.Length; i++)
        {
            if(values[i] > max){
                maxI = i;
                max = values[i];
            }
        }
        return maxI;
    }
}