using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1
{
    class PlayerStats : IComparable<PlayerStats>
    {
        public string Player { get; set; }
        public int Level { get; set; }
        public long Time { get; set; }

        public PlayerStats(string Player, int Level, long Time)
        {
            this.Player = Player;
            this.Level = Level;
            this.Time = Time;
        }

        public int CompareTo(PlayerStats that)
        {
            if(this.Time < that.Time)
            {
                return -1;
            } else if(this.Time > that.Time)
            {
                return 1;
            }

            return 0;
        }

        public TimeSpan GetTimeSpan()
        {
            return TimeSpan.FromTicks(this.Time);
        }
    }
}
