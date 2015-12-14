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
    }

    class Reindeer
    {
        private int speed;
        private int timeFlying;
        private int timeResting;
        private string name;

        public Reindeer(string name, int speed, int timeFlying, int timeResting)
        {
            this.name = name;
            this.speed = speed;
            this.timeFlying = timeFlying;
            this.timeResting = timeResting;
        }

        public int getDistance(int timeFlown)
        {
            int completeruns = timeFlown / (this.timeFlying + timeResting);
            return completeruns * timeFlying * speed + Math.Min(timeFlown%(this.timeFlying+this.timeResting),this.timeFlying)*this.speed;
        }
    }
}
