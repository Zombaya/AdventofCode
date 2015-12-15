using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventofCode
{
    class Day15
    {
        public List<ingredient> ingredients = new List<ingredient>(4);

        public bool addIngredientLine(string line)
        {
            var regex = new Regex(@"(?<name>\w+): capacity (?<cap>\-?[0-9]\d{0,2}), durability (?<dur>\-?[0-9]\d{0,2}), flavor (?<flav>\-?[0-9]\d{0,2}), texture (?<text>\-?[0-9]\d{0,2}), calories (?<cal>\-?[0-9]\d{0,2})");

            var match = regex.Match(line);
            if (match.Success)
            {
                this.addIngredient(
                    match.Groups["name"].Value,
                    Int32.Parse(match.Groups["cap"].Value),
                    Int32.Parse(match.Groups["dur"].Value),
                    Int32.Parse(match.Groups["flav"].Value),
                    Int32.Parse(match.Groups["text"].Value),
                    Int32.Parse(match.Groups["cal"].Value));
                return true;
            }
            else
            {
                Console.WriteLine("Error match!");
                return false;
            }
        }

        public void addIngredient(string name, int cap, int dur, int fla, int tex, int cal)
        {
            ingredients.Add(new ingredient(name, cap, dur, fla, tex, cal));
            //
            int i = 0;
        }

        public void printBestCombination(int teaspoons)
        {
            int max = 0;
            int[] best = new int[4];

            for (int i = 0 ; i < teaspoons ; i++)
            {
                for(int j = 0 ; j<teaspoons - i ; j++)
                {
                    for(int k = 0; k < teaspoons - i - j ; k++)
                    {
                        int l = teaspoons - i - j - k;
                        int sum = 1;
                        for (int x = 0; x < 4; x++)
                        {
                            sum *= Math.Max((i * ingredients[0].val[x] + j * ingredients[1].val[x] + k * ingredients[2].val[x] + l * ingredients[3].val[x]), 0);
                        }
                        if (sum > max)
                        {
                            max = sum;
                            best = new int[4] { i, j, k, l };
                        }
                    }
                }
                
            }
            Console.WriteLine("Topscore: {0}", max);
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} teaspoons of {1}", best[i], ingredients[i].name);
            }
        }

        public void printBestCombination(int teaspoons, int maxCal)
        {
            int max = 0;
            int[] best = new int[4];

            for (int i = 0; i < teaspoons; i++)
            {
                for (int j = 0; j < teaspoons - i; j++)
                {
                    for (int k = 0; k < teaspoons - i - j; k++)
                    {
                        int l = teaspoons - i - j - k;
                        int sum = 1;
                        for (int x = 0; x < 4; x++)
                        {
                            sum *= Math.Max((i * ingredients[0].val[x] + j * ingredients[1].val[x] + k * ingredients[2].val[x] + l * ingredients[3].val[x]), 0);
                        }
                        int cal = i * ingredients[0].val[4] + j * ingredients[1].val[4] + k * ingredients[2].val[4] + l * ingredients[3].val[4];
                        if (sum > max && cal == maxCal)
                        {
                            max = sum;
                            best = new int[4] { i, j, k, l };
                        }
                    }
                }

            }
            Console.WriteLine("Topscore with {1} calories: {0}", max,maxCal);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} teaspoons of {1}", best[i], ingredients[i].name);
            }
        }

    }

    class ingredient
    {
        public string name;
        public int[] val;

        public ingredient(string name, int cap, int dur, int fla, int tex, int cal)
        {
            this.name = name;
            this.val = new int[5] { cap, dur, fla, tex, cal };
        }
    }
}
