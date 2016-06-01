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

        public RunEvent(DateTime time, double timeofrun, double dis) { distance = dis; time_data = time; time_of_run = timeofrun; }

        //Properties
        public double Distance => distance;
        public double Time_of_run => time_of_run;
        public DayOfWeek Day_of_week{get{return time_data.DayOfWeek;}}
        public TimeSpan Time_of_day{get{return time_data.TimeOfDay;}}
        public DateTime Date {get{return time_data.Date;}}

        //Methods
        public double MileAverage(){return time_of_run / distance;}

        public double SpeedAverage(){return 3600/MileAverage();}    
            
        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

        public override string ToString()
        {
            return " Date: " + time_data.ToString("M/d/yyyy") +"   Distance: " + distance.ToString("F2") + " Miles   Time: " + ConvertToMinSec(time_of_run).ToString("mm:ss") + "   Average Mile Time: " + ConvertToMinSec(MileAverage()).ToString("mm:ss") + "   Average Speed: " + SpeedAverage().ToString("F2") + "MPH"; 
        }

    }
}
