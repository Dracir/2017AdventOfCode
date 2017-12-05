using System;
using System.IO;

namespace DracirAdvent2017
{
    public class D5Trampolines
    {
        public static void Part1(){
            var instructions = InputParser.FileIntArray("D5Part1.txt","\n");

            int i = 0;
            int nbSteps = 0;
            while(i< instructions.Length){
                nbSteps++;

                var lastStep = i;
                i+= instructions[i];

                instructions[lastStep]++;
            }
            Console.WriteLine(nbSteps);
        }
        public static void Part2(){
            var instructions = InputParser.FileIntArray("D5Part1.txt","\n");

            int i = 0;
            int nbSteps = 0;
            while(i< instructions.Length){
                nbSteps++;

                var lastStep = i;
                i+= instructions[i];
                if(instructions[lastStep] >=3)
                    instructions[lastStep]--;
                else
                    instructions[lastStep]++;
            }
            Console.WriteLine(nbSteps);
        }
    }
}