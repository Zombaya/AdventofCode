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
            int total = 0;

            string line;
            Console.WriteLine("Enter one word (press CTRL+Z to exit):");
            Console.WriteLine();
            line = File.ReadAllText("../../Day12.txt"); ;
            word = line;
            Console.WriteLine();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (line != null && line != "")
            {
                int sum = addLine(line);
                total += sum;
                Console.WriteLine("\t{0}", sum);

                line = Console.ReadLine();
            }
            Console.WriteLine("Total: {0}",total);
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
