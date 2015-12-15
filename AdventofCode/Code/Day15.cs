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
        public List<ingredient> ingredients = new List<ingredient>(10);

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
            this.ingredients.Add(new ingredient(name, cap, dur, fla, tex, cal));
        }

        public void testCombinations(int c,int t)
        {
            List<List<int>> combo = this.getPossibleCombinations(c, t);
            foreach(List<int> lijst in combo)
            {
                foreach(int i in lijst)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
        }

        public void printBestCombination(int teaspoons)
        {
            int max = 0;
            List<int> best = new List<int>(this.ingredients.Count());
            List<List<int>> combolijst = this.getPossibleCombinations(this.ingredients.Count(), teaspoons);

            foreach(List<int> combo in combolijst)
            {
                int mult = 1;
                for (int x = 0; x < 4; x++)
                {
                    int sum = 0;
                    int i = 0;
                    foreach (int aantal in combo)
                    {
                        sum += aantal * this.ingredients[i].val[x];
                        i++;
                    }
                    mult *= Math.Max(sum, 0);
                }
                if (mult > max)
                {
                    max = mult;
                    best = combo;
                }
            }

            Console.WriteLine("Topscore: {0}", max);
            for(int i = 0; i < best.Count(); i++)
            {
                Console.WriteLine("{0} teaspoons of {1}", best[i], ingredients[i].name);
            }
        }

        public void printBestCombination(int teaspoons, int maxCal)
        {
            int max = 0;
            List<int> best = new List<int>(this.ingredients.Count());
            List<List<int>> combolijst = this.getPossibleCombinations(this.ingredients.Count(), teaspoons);

            foreach (List<int> combo in combolijst)
            {
                int mult = 1;
                int i = 0;
                for (int x = 0; x < 4; x++)
                {
                    int sum = 0;
                    i = 0;
                    foreach (int aantal in combo)
                    {
                        sum += aantal * this.ingredients[i].val[x];
                        i++;
                    }
                    mult *= Math.Max(sum, 0);
                }
                int cal = 0;
                i = 0;
                foreach(int aantal in combo)
                {
                    cal += aantal * this.ingredients[i++].val[4];
                }
                if (mult > max && cal == maxCal)
                {
                    max = mult;
                    best = combo;
                }
            }

            Console.WriteLine("Topscore with {1} calories: {0}", max, maxCal);
            for (int i = 0; i < best.Count(); i++)
            {
                Console.WriteLine("{0} teaspoons of {1}", best[i], ingredients[i].name);
            }
        }

        private List<List<int>> getPossibleCombinations(int variables, int total)
        {
            List<List<int>> result = new List<List<int>>();
            if(variables == 1)
            {
                List<int> t = new List<int>();
                t.Add(total);
                result.Add(t);
                return result;
            }
            for(int i = 0; i < total; i++)
            {
                List<List<int>> interresult = getPossibleCombinations(variables - 1, total - i) ;
                foreach(List<int> o in interresult)
                {
                    o.Add(i);
                    result.Add(o);
                }
            }
            return result;
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
