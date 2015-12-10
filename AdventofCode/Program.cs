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
            string word;
            Console.WriteLine("Enter one word (press CTRL+Z to exit):");
            Console.WriteLine();
            word = Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (word != null)
            {      
                if (IsNice2(word))
                    nice++;
                else
                    naughty++;

                Console.WriteLine("{0} is {1}", word, (IsNice2(word) ? "nice" : "naughty"));

                word = Console.ReadLine();
            }
            Console.WriteLine("Nice: {0}\nNaughty: {1}",nice,naughty);
            Console.WriteLine("loop time in milliseconds: {0}",
                                stopwatch.ElapsedMilliseconds);



            Console.WriteLine("\n\nPress Any Key To Exit...");
            Console.ReadLine();

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
