using System;
using System.Collections.Generic;
namespace DracirAdvent2017
{
    public class D3
    {
        public static void SpiralMemory(){

            //number    
            // 1        1       1   0
            // 2-9      8       7   1
            // 10-25    16      8   2
            // 26-49    22      6   3

            //1 - 9 - 25 -49
            // 8 -16- 24
            //3

            // Il y a surment une facon mathematique mais jvais y aller avec un crawller.

            DoItFor(1);
            DoItFor(12);
            DoItFor(23);
            DoItFor(1024);
            DoItFor(325489);
        }

		private static void DoItFor(int n)
		{
            if(n == 1) {
                Console.WriteLine("For 1 : 0");
                return;
            }
            
            int x = 0;
            int y = 0;

            int nbSteps = 1;
            int stepRemaining = 1;
            int orientation = 0;

            for (int i = 2; i <= n; i++)
            {
                stepRemaining--;
                if(orientation == 0){
                    x++;
                }else if(orientation == 1){
                    y++;
                }else if(orientation == 2){
                    x--;
                }else if(orientation == 3){
                    y--;
                }

                if(stepRemaining == 0){
                    orientation++;
                    orientation %= 4;
                    if(orientation %2 == 0)
                        nbSteps++;
                    stepRemaining = nbSteps;
                }
            }
            
            
            Console.WriteLine("For " + n + " : " + (Math.Abs(x) + Math.Abs(y))) ;
             
            return;
		}

        public static void Part2(){
            int size = 11;
            int middle = size/2;
            int[,] values = new int[size,size];
            
            values[middle,middle] = 1;
            int x = 0;
            int y = 0;

            int nbSteps = 1;
            int stepRemaining = 1;
            int orientation = 0;

            int stepValue = 0;

            while(stepValue <= 325489){
                stepRemaining--;
                if(orientation == 0){
                    x++;
                }else if(orientation == 1){
                    y++;
                }else if(orientation == 2){
                    x--;
                }else if(orientation == 3){
                    y--;
                }
                
                stepValue = values[middle+x-1,middle+y]+values[middle+x+1,middle+y]
                +values[middle+x-1,middle+y+1]+values[middle+x,middle+y+1]+values[middle+x+1,middle+y+1]
                +values[middle+x-1,middle+y-1]+values[middle+x,middle+y-1]+values[middle+x+1,middle+y-1];
                values[middle+x,middle+y] = stepValue;
                Console.WriteLine(stepValue);

                if(stepRemaining == 0){
                    orientation++;
                    orientation %= 4;
                    if(orientation %2 == 0)
                        nbSteps++;
                    stepRemaining = nbSteps;
                }
            };

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(string.Format("{0:000000} ", values[i,j]) + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("First value larger :" + stepValue);
        }
        // 1,2,1,2,1,2,1,2
        // 3,2,3,4,3,2,3,4,3,2,3,4,3,2,3,4
        //5,4,3,4,5,4,3,4,5,4,3,4,5
        //6,5,4,5,6,7
        // +1, +1, -1, +1, -1, +1 ,-1,+1
        //
	}
}