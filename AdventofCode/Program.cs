using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            string line;
            Console.WriteLine("Enter one package (press CTRL+Z to exit):");
            Console.WriteLine();
            do
            {
                int w1=0, h1=0, w2=0,h2=0;
                int maxw=0, maxh=0, minw=0, minh=0;
                int houses = 0;

                line = File.ReadAllText("../../Day3.txt");

                for(int i=0; i< line.Length; i+=2)
                {
                    switch (line[i])
                    {
                        case '<': w1--; break;
                        case '>': w1++; break;
                        case '^': h1++; break;
                        case 'v': h1--; break;
                    }
                    switch (line[i+1])
                    {
                        case '<': w2--; break;
                        case '>': w2++; break;
                        case '^': h2++; break;
                        case 'v': h2--; break;
                    }
                    minw = new int[] { minw, w1, w2 }.Min();
                    minh = new int[] { minh, h1, h2 }.Min();
                    maxw = new int[] { maxw, w1, w2 }.Max();
                    maxh = new int[] { maxh, h1, h2 }.Max();
                }

                int totalw = maxw - minw + 1;
                int totalh = maxh - minh + 1;

                int[] start = new int[2] { -minw, -minh};
                int[,] presents = new int[totalw,totalh];

                // 1 present for the starter
                presents[-minw, -minh] = 1;
                houses += 1;

                for (int i1 = -minw,i2 = -minw, j1 = -minh, j2 = -minh, c=0; c < line.Length; c+=2)
                {
                    switch (line[c])
                    {
                        case '<': i1--; break;
                        case '>': i1++; break;
                        case '^': j1++; break;
                        case 'v': j1--; break;
                        default: continue;
                    }
                    switch (line[c+1])
                    {
                        case '<': i2--; break;
                        case '>': i2++; break;
                        case '^': j2++; break;
                        case 'v': j2--; break;
                        default: continue;
                    }
                    if (presents[i1, j1] == 0)
                        houses += 1;
                    if (presents[i2, j2] == 0)
                        houses += 1;
                    presents[i1, j1] += 1;
                    presents[i2, j2] += 1;
                }
                
                if (line != null)
                    Console.WriteLine("= " + houses + " huisjes - " );
                Console.ReadLine();
            } while (false);

        }
    }
   
}
