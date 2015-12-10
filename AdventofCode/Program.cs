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
            string secret;
            do
            {
                Console.WriteLine("Enter one secret (press CTRL+Z to exit):");
                Console.WriteLine();
                secret = Console.ReadLine();

                bool found = false;
                int i = 0;
                int stepsize = 10000;


                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string log = "Trying " + secret;

                /* The Sequential version
                Console.Write(log);

                //609043
                for (i = 0; i < 10000000 && !found; i++)
                {
                    Console.SetCursorPosition(log.Length, Console.CursorTop);
                    Console.Write(i * stepsize);
                    found = linearCalc(secret, "000000", stepsize, stepsize * i);
                }
                Console.WriteLine();

                
                if (!found)
                    Console.WriteLine("Did not find correct hash in {0} steps", i);

                Console.WriteLine("Sequential loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);
                //*/// End of the sequential version

                stopwatch.Restart();
                Console.Write(log);
                found = false;

                //609043
                for (i = 0; i < 10000000 && !found; i++)
                {
                    Console.SetCursorPosition(log.Length, Console.CursorTop);
                    Console.Write(i * stepsize);
                    found = parallelCalc(secret, "000000", stepsize, stepsize * i);
                }
                Console.WriteLine();


                if (!found)
                    Console.WriteLine("Did not find correct hash in {0} steps", i);

                Console.WriteLine("Parallel loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);


                Console.WriteLine("\n\n");
            } while (secret != null);

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

        public static bool linearCalc(string secret, string match, int iterations, int start = 0)
        {
            bool found = false;
            int size = match.Length;
            for (int i = start; i < start + iterations && !found; i++)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, string.Concat(secret, i));
                    if (hash.Substring(0,size).Equals(match))
                    {
                        Console.WriteLine("\n\nThe MD5 hash of {0} is {1}.  Calculated in {2} steps", secret, hash, i);
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool parallelCalc(string secret, string match, int iterations, int start = 0)
        {
            bool found = false;
            int size = match.Length;
            Parallel.For(start, start+iterations, i =>
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, string.Concat(secret, i));
                    if (hash.Substring(0, size).Equals(match))
                    {
                        Console.WriteLine("\n\nThe MD5 hash of {0} is {1}.  Calculated in {2} steps", secret, hash, i);
                        found = true;
                    }
                    if (start + iterations == 609043)
                        Console.WriteLine("Should find now!");
                }
            });

            return found;
        }
    }

   
}
