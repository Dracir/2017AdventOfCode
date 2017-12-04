using System;

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
            
            //Finding nearest odd perfet square
            int i=1;
            while(MathF.Pow(i+=2,2) < n);
            i-=2;
            
            Console.WriteLine("asdr " + i*i) ;
             
            return;


            int steps = 0;
            int currentMin = 1;
            int currentMax = 2;
            //
            while(i != n){
                i++;

            }
            
            Console.WriteLine("For " + n + " : " + steps);
		}
        // 1,2,1,2,1,2,1,2
        // 3,2,3,4,3,2,3,4,3,2,3,4,3,2,3,4
        //5,4,3,4,5,4,3,4,5,4,3,4,5
        //6,5,4,5,6,7
        // +1, +1, -1, +1, -1, +1 ,-1,+1
        //
	}
}