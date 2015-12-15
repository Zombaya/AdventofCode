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
            Day12 d = new Day12();
            string line;

            List<string> tests = new List<string>();
            tests.Add("[1,2,3]");
            tests.Add("{ \"a\":2,\"b\":4}");
            tests.Add("[[[3]]]");
            tests.Add("{\"a\":{\"b\":4},\"c\":-1}");
            tests.Add("{\"a\":[-1,1]}");
            tests.Add("[-1,{\"a\":1}]");
            tests.Add("{}");
            tests.Add("[]");
            tests.Add("[1,{\"c\":\"red\",\"b\":2},3]");
            tests.Add("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}");
            tests.Add("[1,\"red\",5]");
            tests.Add("[1,{\"c\":\"red\",\"b\":2},3]");
            tests.Add("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}");
            tests.Add("[1,\"red\",5]");

            foreach (string test in tests)
            {
                //Console.WriteLine("{0} ==> {1}", test, d.removeRed(test));
                //Console.WriteLine("{0}: {1} - {2}", test, d.doCalculation(test), d.doCalculation2(test));
            }
    


            line = File.ReadAllText("../../Day12.txt");


            /*
            Console.WriteLine("Enter one sentence (press CTRL+Z to exit):");
            Console.WriteLine();

            line = Console.ReadLine();

            while (line != null && line != "")
            {
                //d.addIngredientLine(line);
                line = Console.ReadLine();
            }
            */
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("{0}", d.doCalculation(line));
            Console.WriteLine("{0}", d.doCalculation2(line));
            Console.WriteLine("Part 1:");
            //d.printBestCombination(100);
            Console.WriteLine("Part 2:");
            //d.printBestCombination(100, 500);
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

        }
    }
}
