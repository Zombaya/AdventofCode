using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    class Day12
    {

        public int doCalculation(string input)
        {
            return this.getCount(input);
        }

        public int doCalculation2(string input)
        {
            return this.getCount(this.removeRed(input));
        }

        private int getCount(string input)
        {
            int result = 0;
            int current = 0;
            bool negative = false;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    current = current * 10 + input[i] - '0';
                }
                else if (input[i] == '-')
                {
                    negative = true;
                }
                else
                {
                    if (negative)
                        result -= current;
                    else
                        result += current;
                    current = 0;
                    negative = false;
                }
            }

            return result;
        }

        public string removeRed(string input)
        {
            string output = input;
            int f;
            int previouslength = Int32.MaxValue;

            StringBuilder s = new StringBuilder(input.Length);
            s.Append(input);
            s[1] = 'j';

            while( (f = s.ToString().IndexOf("\"red\"")) != -1){
                int curlength = s.Length;
                if (curlength > previouslength)
                {
                    Console.WriteLine("Something went wrong, string grew!");
                    return "";
                }
                    
                previouslength = curlength;

                int level = 0;
                int levelh = 0;
                for(int i = f; i >= 0; i--)
                {
                    // Als
                    if (s[i] == '}')
                        level++;
                    if (s[i] == ']')
                        levelh++;
                    if (s[i] == '[')
                    {
                        if (level ==  0 && levelh == 0)
                        {
                            int length = s.Length;
                            s[f + 1] = 'b';
                            //output = output.Substring(0, f - 1) + output.Substring(f + 1, length - f - 1);
                            break;
                        }
                        else
                            levelh--;
                    }
                    if (s[i] == '{')
                    {
                        if(level == 0)
                        {
                            do {
                                if (s[i] == '{')
                                    level++;
                                if (s[i] == '}')
                                    level--;
                                s.Remove(i, 1);
                            } while (level > 0);
                            break;
                        }
                        level--;
                    }
                }
            }
            return s.ToString();
        }
    }
}
