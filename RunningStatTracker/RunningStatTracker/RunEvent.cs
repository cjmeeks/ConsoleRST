using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class RunEvent
    {
        private double distance;//miles
        private double time_of_run;//seconds
        private DateTime time_data;
        private string terrain;
        private double mileAverage;
        private double speedAverage;

        public RunEvent(DateTime time, double timeofrun, double dis, string terr)
        {
          distance = dis;
          time_data = time;
          time_of_run = timeofrun;
          terrain = terr;
          mileAverage = time_of_run/distance;
          speedAverage = 3600/mileAverage;
        }

        //Properties
        public double Distance => distance;
        public double Time_of_run => time_of_run;

        public DayOfWeek Day_of_week => time_data.DayOfWeek;
        public TimeSpan Time_of_day => time_data.TimeOfDay;
        public DateTime Date => time_data;
        public string Terrain => terrain;
        public double MileAverage => mileAverage;
        public double SpeedAverage => speedAverage;

        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

        //still needs %string thing
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Date: {0}", time_data.ToString("MM/dd/yyyy"));
            sb.AppendFormat("   Distance: {0}",distance.ToString("F2"));
            sb.AppendFormat(" Miles   Time: {0}", ConvertToMinSec(time_of_run).ToString("mm:ss"));
            sb.AppendFormat("   Average Mile Time: {0}", ConvertToMinSec(MileAverage()).ToString("mm:ss"));
            sb.AppendFormat("   Average Speed: {0}", SpeedAverage().ToString("F2"));
            sb.Append("MPH");
            sb.AppendFormat("  Terrain: {0}", terrain);
            return sb.ToString();
        }

    }
}
