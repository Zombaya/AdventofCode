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
            int total = 0;
            string line;
            Console.WriteLine("Enter one package (press CTRL+Z to exit):");
            Console.WriteLine();
            do
            {
                int w, l, h;
                string[] numbers;
                int thispackage = 0;
                var t = new Tuple<int, int>(1, 2);

                line = Console.ReadLine();

                string[] stringSeparators = new string[] { "x" };
                numbers = line.Split(stringSeparators, StringSplitOptions.None);

                w = Int32.Parse(numbers[0]);
                l = Int32.Parse(numbers[1]);
                h = Int32.Parse(numbers[2]);

                t = addSides(w, h, 0);
                thispackage += t.Item1;
                t = addSides(l, h, t.Item2);
                thispackage += t.Item1;
                t = addSides(w, l, t.Item2);
                thispackage += t.Item1;
                thispackage += t.Item2;

                total += thispackage;

                if (line != null)
                    Console.WriteLine("= " + thispackage + " - " + total);
            } while (line != null);

        }
        static public Tuple<int, int> addSides(int side1, int side2, int smallestSide)
        {
            int opp = side1 * side2;
            if (opp < smallestSide || smallestSide == 0)
                smallestSide = opp;

            return Tuple.Create(2 * opp, smallestSide);
        }
    }

}
