using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Run
    {
        //miles
        private double distance;
        //seconds
        private double time_of_run;
        private double run_Number
        private DateTime time_data;
        public Run(DateTime time, double timeofrun, double dis)
        {
            distance = dis;
            time_data = time;
            time_of_run = timeofrun;
        }
        public double Distance => distance;
        public double Time_of_run => time_of_run;
        public DayOfWeek Day_of_week{get{return time_data.DayOfWeek;}}
        public TimeSpan Time_of_day{get{return time_data.TimeOfDay;}}
        public DateTime Date {get{return time_data.Date;}}
        public double Run_Number{get{return run_Number;}}

        public double MileAverage(){return time_of_run / distance;}
        public double SpeedAverage(){return 3600/MileAverage();}



    }
}
