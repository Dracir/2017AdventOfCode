using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Printer
{

    public static void Print(int[] values){
        var n = values.Max();
        var nbDigit = (int)Math.Floor(Math.Log10(n) + 1);

        foreach (var v in values)
        {
            Print(v,nbDigit);
            Console.Write(" ");
        }
        Console.Write("\n");
    }   

    public static void Print(int value, int strFormatNbSpace){
        string s = "{0:";
        
        for (int i = 0; i < strFormatNbSpace; i++)
            s+= "0";
        s+= "}";
        
        Console.Write(String.Format(s,value));
    }

    public static void Print<t>(Dictionary<string,t> dictionary){
        foreach (var l in dictionary)
        {
            Console.Write(string.Format("{0} : {1}\n",l.Key,l.Value));
        }
    }
}
