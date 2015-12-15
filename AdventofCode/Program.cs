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
            Day15 d = new Day15();
            string line;
            

            Console.WriteLine("Enter one sentence (press CTRL+Z to exit):");
            Console.WriteLine();

            line = Console.ReadLine();

            while (line != null && line != "")
            {
                d.addIngredientLine(line);
                line = Console.ReadLine();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Part 1:");
            d.printBestCombination(100);
            Console.WriteLine("Part 2:");
            d.printBestCombination(100, 500);
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

        }
        

        static int addLine(string input)
        {
            int result=0;
            int current = 0;
            bool negative = false;
            
            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] >= '0' && input[i] <= '9')
                {
                    current = current * 10 + input[i] - '0';
                }
                else if(input[i] == '-')
                {
                    negative = true;
                }
                else
                {
                    if (negative)
                        result -= current;
                    else
                        result += current;
                    current = 0;
                    negative = false;
                }
            }

            return result;
        }
    }
}
