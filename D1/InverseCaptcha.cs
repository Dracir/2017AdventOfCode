using System;
using System.IO;

public class InverseCaptcha
{
    public static void Do(int[] values){
        var sum = 0;
        for (int i = 0; i < values.Length-1; i++)
        {
            if(values[i] == values[i+1])
                sum+= values[i];
        }
        if(values[0] == values[values.Length-1])
            sum+= values[0];
        
        Console.WriteLine("InverseCaptcha : " + sum);
    }

    public static void DoPart2(int[] values){
        var sum = 0;
        int halfWay = values.Length/2;
        for (int i = 0; i < values.Length; i++)
        {
            if(values[i] == values[(i+halfWay) % values.Length])
                sum+= values[i];
        }
        
        Console.WriteLine("InverseCaptcha Part2: " + sum);
    }
}
