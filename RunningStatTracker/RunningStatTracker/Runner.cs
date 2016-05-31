using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Runner
    {
        private List<Run> list_of_runs;
        private string name;
        private string gender;

        public Runner(string nameIn, string genderIn)
        {
            name = nameIn;
            gender = genderIn;
            list_of_runs = new List<Run>();
        }

        public string Name { get { return name; } }
        public string Gender { get { return gender; } }
        public List<Run> Runs{ get { return list_of_runs; } }

        //add run
        public void AddRun(Run run) { list_of_runs.Add(run); }

        //get run by date
        public Run GetRunByDate(DateTime date)
        {
            Run run = null;
            foreach(Run x in list_of_runs)
            {
                if(date == x.Date)
                {
                    run = x;
                    break;
                }
            }
            return run;
        }

        //get run by day of week
        public Run GetRunByDay(DayOfWeek date)
        {
            Run run = null;
            foreach (Run x in list_of_runs)
            {
                if (date == x.Day_of_week)
                {
                    run = x;
                    break;
                }
            }
            return run;
        }

        //get total time ran
        public double TotalTimeRun()
        {
            double total = 0;
            foreach(Run run in list_of_runs)
            {
                total += run.Time_of_run;
            }
            return total;
        }

        //get total distance
        public double TotalDistance()
        {
            double total = 0;
            foreach (Run run in list_of_runs)
            {
                total += run.Distance;
            }
            return total;
        }

        //get total time for all the runs
        public double TotalTime()
        {
            double total = 0;
            foreach (Run run in list_of_runs)
            {
                total += run.Time_of_run;
            }
            return total;
        }

        //get mile average for a run
        public double MileAverageForRun(DateTime date){return GetRunByDate(date).MileAverage();}

        //get overall mile average
        public double TotalMileAverage(){return GetMileAverages().Average();}

        //get overall speed average
        public double TotalSpeedAverage(){return GetSpeedAverages().Average();}

        //get day of week average (needs work)
        /*public double DayOfWeekAvg(DayOfWeek date)
        {
            double[] averages = GetMileAverages();
            double dayAverage = 0;
            foreach(double average in averages)
            {
                dayAverage += average;
            }
            return dayAverage / averages.Length;
        }*/

        //get average speed for 1 run
        public double AverageSpeedOneRun(DateTime date) { return GetRunByDate(date).SpeedAverage(); }

        //convert for output
        //takes in seconds
        
        //gets mile averages
        public double[] GetMileAverages()
        {
            double[] averages = new double[list_of_runs.Count];
            int i = 0;
            foreach(Run run in list_of_runs)
            {
                averages[i] = run.MileAverage();
                i++;
            }
            return averages;
        }

        //get Speed Averages
        public double[] GetSpeedAverages()
        {
            double[] averages = new double[list_of_runs.Count];
            int i = 0;
            foreach(Run run in list_of_runs)
            {
                averages[i] = run.SpeedAverage();
                i++;
            }
            return averages;
        }
    }
}
