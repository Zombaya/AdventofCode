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
                int level = 0;
                int step = 1;
                char c = ' ';
                for(;  ((c = Console.ReadKey().KeyChar) != ' ') && (level != -1);step++)
                {
                    if (c == ')')
                        level--;
                    else if (c == '(')
                        level++;
                    else
                        step--;

                    if (level == -1)
                        break;
                }
                Console.WriteLine("\n\nLevel " + level + " reached in " + step + " steps\n\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.S);
        }
    }
}
