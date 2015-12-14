using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Day14 d = new Day14();
            
            int total = 0;

            string line;
            Console.WriteLine("Enter one sentence (press CTRL+Z to exit):");
            Console.WriteLine();

            line = Console.ReadLine();

            while (line != null && line != "")
            {
                var regex = new Regex(@"(?<name>\w+) can fly (?<speed>\d+) km/s for (?<timeFlying>\d+) seconds, but then must rest for (?<timeResting>\d+) seconds.");
                var match = regex.Match(line);
                if (match.Success)
                {
                    d.addDeer(
                        match.Groups["name"].Value,
                        Int32.Parse(match.Groups["speed"].Value),
                        Int32.Parse(match.Groups["timeFlying"].Value),
                        Int32.Parse(match.Groups["timeResting"].Value));
                }
                line = Console.ReadLine();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Record: " + d.getMaxDistance(2503));
            Reindeer bestdeer = d.getHighScore(2503);
            Console.WriteLine("Highest score was {0} by {1}", bestdeer.getName(),bestdeer.getScore());
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
