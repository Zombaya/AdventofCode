using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int i = 0;
                char c = ' ';
                while ((c = Console.ReadKey().KeyChar) != ' ')
                {
                    if (c == ')')
                        i--;
                    if (c == '(')
                        i++;
                }
                Console.WriteLine("\n\nResult is: " + i + "\n\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.S);
        }
    }
}
