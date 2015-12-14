using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AdventofCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string word;

            string line;
            Console.WriteLine("Enter one word (press CTRL+Z to exit):");
            Console.WriteLine();
            line = Console.ReadLine();
            word = line;
            Console.WriteLine();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i = 0; i<50; i++) 
            {
                word = doStep(word);
            }
            Console.WriteLine("After 50 steps: " + word.Length);
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

        }
        

        static string doStep(string input)
        {
            StringBuilder result = new StringBuilder(1000000);
            char previous;
            int count = 1;

            if (input.Length == 0)
                return "";
            else
                previous = input[0];
            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] == previous)
                {
                    count += 1;
                }
                else
                {
                    result.Append(count).Append(previous);
                    previous = input[i];
                    count = 1;
                }
            }
            result.Append(count).Append(previous);

            return result.ToString();
        }
    }
}
