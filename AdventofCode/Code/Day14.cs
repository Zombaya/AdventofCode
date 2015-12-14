using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    class Day14
    {
        private List<Reindeer> reindeers = new List<Reindeer>();
        
        public void addDeer(string name, int speed, int timeFlying, int timeResting)
        {
            this.reindeers.Add(new Reindeer(name, speed, timeFlying, timeResting));
        }

        public int getMaxDistance(int timeFlown)
        {
            int max = 0;
            foreach(Reindeer deer in this.reindeers)
            {
                int distance = deer.getDistance(timeFlown);
                if (distance > max)
                    max = distance;
            }
            return max;
        }

        public Reindeer getHighScore(int timeFlown)
        {
            int max = 0;
            List<Reindeer> bests = new List<Reindeer>();
            for (int i=1; i <= timeFlown; i++)
            {
                //Console.WriteLine("T={0}", i);
                max = 0;
                bests.Clear();
                foreach (Reindeer deer in this.reindeers)
                {
                    int distance = deer.getDistance(i);
                    if (distance == max)
                    {
                        bests.Add(deer);
                    }
                    else if (distance > max)
                    {
                        max = distance;
                        bests.Clear();
                        bests.Add(deer);
                    }
                    //Console.WriteLine("{0} is at {1}", deer.getName(), deer.getDistance(i));
                }

                foreach(Reindeer deer in bests)
                    deer.addPoint();

                //Console.WriteLine("{0} was best and has now {1} points.\n", best.getName(), best.getScore());
                //Console.WriteLine();
                //Console.ReadLine();
            }
            
            Reindeer best = null;
            max = 0;
            foreach (Reindeer deer in this.reindeers)
            {
                if (deer.getScore() > max)
                {
                    max = deer.getScore();
                    best = deer;
                }
            }
            return best;
        }
    }

    class Reindeer
    {
        private int speed;
        private int timeFlying;
        private int timeResting;
        private string name;
        private int score;

        public Reindeer(string name, int speed, int timeFlying, int timeResting)
        {
            this.name = name;
            this.speed = speed;
            this.timeFlying = timeFlying;
            this.timeResting = timeResting;
            this.score = 0;
        }

        public int getDistance(int timeFlown)
        {
            int completeruns = timeFlown / (this.timeFlying + timeResting);
            return completeruns * timeFlying * speed + Math.Min(timeFlown%(this.timeFlying+this.timeResting),this.timeFlying)*this.speed;
        }

        public void addPoint(int p = 1)
        {
            this.score += p;
        }

        public int getScore()
        {
            return this.score;
        }

        public string getName()
        {
            return this.name;
        }
    }
}
