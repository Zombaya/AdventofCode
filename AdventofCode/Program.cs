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
            int total = 0;
            int nice = 0;
            int naughty = 0;
            bool[,] lichtjes = new bool[1000, 1000];
            int xmin, xmax, ymin, ymax;
            string[] nummers;

            string line;
            Console.WriteLine("Enter one word (press CTRL+Z to exit):");
            Console.WriteLine();
            line = Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (line != null)
            {
                string[] values = line.Split(' ');
                if (values[0].Equals("turn"))
                {
                    nummers = values[2].Split(',');
                    xmin = Int32.Parse(nummers[0]);
                    ymin = Int32.Parse(nummers[1]);
                    nummers = values[4].Split(',');
                    xmax = Int32.Parse(nummers[0]);
                    ymax = Int32.Parse(nummers[1]);

                    if (values[1].Equals("on"))
                    {
                        for (int i = xmin; i <= xmax; i++)
                        {
                            for (int j = ymin; j <= ymax; j++)
                            {
                                lichtjes[i, j] = true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = xmin; i <= xmax; i++)
                        {
                            for (int j = ymin; j <= ymax; j++)
                            {
                                lichtjes[i, j] = false;
                            }
                        }
                    }
                }
                else if (values[0].Equals("toggle"))
                {
                    nummers = values[1].Split(',');
                    xmin = Int32.Parse(nummers[0]);
                    ymin = Int32.Parse(nummers[1]);
                    nummers = values[3].Split(',');
                    xmax = Int32.Parse(nummers[0]);
                    ymax = Int32.Parse(nummers[1]);
                    for (int i = xmin; i <= xmax; i++)
                    {
                        for (int j = ymin; j <= ymax; j++)
                        {
                            lichtjes[i, j] = !lichtjes[i, j];
                        }
                    }
                }
                else
                    break;

                Console.WriteLine("\tTotaal lichtjes: "+ getTotal(lichtjes));
                line = Console.ReadLine();
            }
            Console.WriteLine("Totaal lichtjes: "+getTotal(lichtjes));
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

        }
        static string getTotal(bool[,] lichtjes)
        {
            int total = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (lichtjes[i, j])
                        total++;
                }
            }
            return total.ToString() ;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool IsNice1(string s)
        {
            bool isnice = false;
            for(int i=0; i< (s.Length - 1); i++)
            { 
                string sub = s.Substring(i, 2);
                if (sub.Equals("ab") || sub.Equals("cd") || sub.Equals("pq") || sub.Equals("xy"))
                {
                    return false;
                }
            }

            for (int i = 0; i < (s.Length - 1); i++)
            {
                string sub = s.Substring(i, 2);
                if (sub[0] == sub[1])
                    isnice=true;
            }
            if (!isnice)
                return false;

            int vowels = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a': case 'e': case 'i': case 'o': case 'u': vowels++; break;
                    default: break;   
                }
            }
            if (vowels >= 3) return true;


            return false;
        }

        public static bool IsNice2(string s)
        {
            bool isniceTo1 = false;
            for (int i = 0; i < (s.Length - 1); i++)
            {
                string sub = s.Substring(i, 2);
                for (int j = i + 2; j < (s.Length - 1) ; j++)
                {
                    if (sub.Equals(s.Substring(j, 2))){
                        isniceTo1 = true;
                        break;
                    }
                }
            }
            if (!isniceTo1)
                return false;

            for(int i=0; i< (s.Length - 2); i++)
            {
                if (s[i] == s[i + 2])
                    return true;
            }

            return false;
        }

    }

   
}
