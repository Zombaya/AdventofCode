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
            int totaloriginal = 0;
            int totalencoded = 0;

            string line;
            Console.WriteLine("Enter one word (press CTRL+Z to exit):");
            Console.WriteLine();
            line = Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (line != null && !line.Equals(""))
            {
                string encoded = encode(line);

                totaloriginal += line.Length;
                totalencoded += encoded.Length;

                Console.WriteLine("\t Totaal encoded: {0}\toriginal: {1}", line.Length, encoded.Length);

                line = Console.ReadLine();
            }
            Console.WriteLine("Totaal encoded: {0} - original: {1} = {2}", totaloriginal, totalencoded, totaloriginal - totalencoded);
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

        }

        static string encode(string s)
        {
            string result = "";
            for(int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '"': result += "\\\""; break;
                    case '\\': result += "\\\\"; break;
                    default: result += s[i]; break;
                }
            }
            return '"' + result + '"';
        }
    }
}
