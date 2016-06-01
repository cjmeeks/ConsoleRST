using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Modal
    {
        private SortedDictionary<string, Runner> runners;

        public Modal() { runners = new SortedDictionary<string, Runner>(); }

        public SortedDictionary<string, Runner> Runners => runners;

        public void AddRunner(string name, string gender) { runners.Add(name, new Runner(name, gender)); }

        public Runner GetRunnerByName(string name) { return runners[name]; }

        public Runner[] GetAllRunners()
        {
            Runner[] tempRunners = new Runner[runners.Values.Count];
            runners.Values.CopyTo(tempRunners, 0);
            return tempRunners;
        }

        //get run by date
        public RunEvent GetRunByDate(DateTime date, ref Runner runner)
        {
            RunEvent run = null;
            foreach(RunEvent x in runner.Runs)
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
        public List<RunEvent> GetRunsByDay(DayOfWeek date, ref Runner runner)
        {
            List<RunEvent> dayofweekruns = new List<RunEvent>();
            foreach (RunEvent x in runner.Runs)
            {
                if (date == x.Day_of_week)
                {
                    dayofweekruns.Add(x);
                }
            }
            return dayofweekruns;
        }

        //get total time ran
        public double TotalTimeRun(ref Runner runner)
        {
            double total = 0;
            foreach(RunEvent run in runner.Runs)
            {
                total += run.Time_of_run;
            }
            return total;
        }

        //get total distance
        public double TotalDistance(ref Runner runner)
        {
            double total = 0;
            foreach (RunEvent run in runner.Runs)
            {
                total += run.Distance;
            }
            return total;
        }

        //get total time for all the runs
        public double TotalTime(ref Runner runner)
        {
            double total = 0;
            foreach (RunEvent run in runner.Runs)
            {
                total += run.Time_of_run;
            }
            return total;
        }

        //get mile average for a run
        public double MileAverageForRun(DateTime date, ref Runner runner){return GetRunByDate(date, ref  runner).MileAverage();}

        //get overall mile average
        public double TotalMileAverage(ref Runner runner){return GetMileAverages(ref runner).Average();}

        //get overall speed average
        public double TotalSpeedAverage(ref Runner runner){return GetSpeedAverages(ref runner).Average();}

        //gets mile averages
        public double[] GetMileAverages(ref Runner runner)
        {
            double[] averages = new double[runner.Runs.Count];
            int i = 0;
            foreach(RunEvent run in runner.Runs)
            {
                averages[i] = run.MileAverage();
                i++;
            }
            return averages;
        }

        //get Speed Averages
        public double[] GetSpeedAverages(ref Runner runner)
        {
            double[] averages = new double[runner.Runs.Count];
            int i = 0;
            foreach(RunEvent run in runner.Runs)
            {
                averages[i] = run.SpeedAverage();
                i++;
            }
            return averages;
        }

        //get day of week  mile average
        public double DayOfWeekMileAvg(DayOfWeek date, ref Runner runner)
        {
            List<double> averages = new List<double>();
            foreach(RunEvent x in runner.Runs)
            {
                if(x.Date.DayOfWeek == date)averages.Add(x.MileAverage());
            }
            return averages.Average();
        }

        //gets day of week speed average
        public double DayOfWeekSpeedAvg(DayOfWeek date, ref Runner runner)
        {
            List<double> averages = new List<double>();
            foreach(RunEvent x in runner.Runs)
            {
                if(x.Date.DayOfWeek == date)averages.Add(x.SpeedAverage());
            }
            return averages.Average();
        }

        //get average speed for 1 run
        public double AverageSpeedOneRun(DateTime date, ref Runner runner) { return GetRunByDate(date, ref runner).SpeedAverage(); }

        //converts seconds to min:sec for output
        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

        //display Totals
        public string Totals(ref Runner runner)
        {
            return "      Total Time Ran: "  + ConvertToMinSec(TotalTimeRun(ref runner)).ToString("mm:ss") + "  Total Distance Ran: " + TotalDistance(ref runner).ToString("F2") + " Miles  Total Mile Average Time: " + ConvertToMinSec(TotalMileAverage(ref runner)).ToString("mm:ss") +  "  Total Speed Average: " + TotalSpeedAverage(ref runner).ToString("F2") + "MPH";
        }

        //computes day of week averages and returns a string for output
        public string DisplayDayOfWeekAverages(DayOfWeek day, ref Runner runner)
        {
            return " Average Mile Time: " + ConvertToMinSec(DayOfWeekMileAvg(day, ref runner)).ToString("mm:ss") + "  Average Speed: " + DayOfWeekSpeedAvg(day, ref runner).ToString("F2") + "MPH" + "\n";
        }

        //standard deviation formula
        public static double StandardDeviation(List<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v=>Math.Pow(v-avg,2)));
        }
        

    }
}
