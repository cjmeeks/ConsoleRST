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

        //methods
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
        public double TotalMileAverage(List<RunEvent> runs) {return GetMileAverages(runs).Average();}

        //get overall speed average
        public double TotalSpeedAverage(List<RunEvent> runs) {return GetSpeedAverages(runs).Average();}

        //gets mile averages
        public double[] GetMileAverages(List<RunEvent> runs)
        {
            double[] averages = new double[runs.Count];
            int i = 0;
            foreach(RunEvent run in runs)
            {
                averages[i] = run.MileAverage();
                i++;
            }
            return averages;
        }

        //get Speed Averages
        public double[] GetSpeedAverages(List<RunEvent> runs)
        {
            double[] averages = new double[runs.Count];
            int i = 0;
            foreach(RunEvent run in runs)
            {
                averages[i] = run.SpeedAverage();
                i++;
            }
            return averages;
        }

        //get day of week  mile average
        public double DayOfWeekMileAvg(List<RunEvent> runs)
        {
            List<double> averages = new List<double>();
            foreach(RunEvent run in runs)
            {
               averages.Add(run.MileAverage());
            }
            return averages.Average();
        }

        //gets day of week speed average
        public double DayOfWeekSpeedAvg(List<RunEvent> runs)
        {
            List<double> averages = new List<double>();
            foreach(RunEvent run in runs)
            {
                averages.Add(run.SpeedAverage());
            }
            return averages.Average();
        }

        //gets all the runs by day of the week
        public List<RunEvent> GetRunsByDayOfWeek(DayOfWeek day, List<RunEvent> runs)
        {
            List<RunEvent> list = new List<RunEvent>();
            foreach(RunEvent run in runs)
            {
                if (run.Date.DayOfWeek == day) list.Add(run);
            }
            return list;
        }

        //get average speed for 1 run
        public double AverageSpeedOneRun(DateTime date, ref Runner runner) { return GetRunByDate(date, ref runner).SpeedAverage(); }

        //converts seconds to min:sec for output
        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

        //display Totals
        public string Totals(ref Runner runner)
        {
            return "      Total Time Ran: "  + ConvertToMinSec(TotalTimeRun(ref runner)).ToString("mm:ss") + " - Total Distance Ran: " + TotalDistance(ref runner).ToString("F2") + " - Miles  Total Mile Average Time: " + ConvertToMinSec(TotalMileAverage(runner.Runs)).ToString("mm:ss") +  " - Total Speed Average: " + TotalSpeedAverage(runner.Runs).ToString("F2") + "MPH";
        }

        //computes day of week averages and returns a string for output
        public string DayOfWeekAverages(DayOfWeek day, List<RunEvent> runs)
        {
            return " Average Mile Time: " + ConvertToMinSec(DayOfWeekMileAvg(GetRunsByDayOfWeek(day, runs))).ToString("mm:ss") + "  Average Speed: " + DayOfWeekSpeedAvg(GetRunsByDayOfWeek(day, runs)).ToString("F2") + "MPH" + "\n";
        }

        //standard deviation formula
        public static double StandardDeviation(double[] values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v=>Math.Pow(v-avg,2)));
        }

        public string SDTotals(ref Runner runner)
        {
            double sdMile = StandardDeviation(GetMileAverages(runner.Runs));
            double sdSpeed = StandardDeviation(GetSpeedAverages(runner.Runs));
            return "      Usual mile time between " + ConvertToMinSec(TotalMileAverage(runner.Runs)- sdMile).ToString("mm:ss") + " and " + ConvertToMinSec(TotalMileAverage(runner.Runs) + sdMile).ToString("mm:ss") + " -- Usual speed between " + (TotalSpeedAverage(runner.Runs) - sdSpeed).ToString("F2") + "MPH and " + (TotalSpeedAverage(runner.Runs) + sdSpeed).ToString("F2")  + "MPH\n";
        }

        public string DayOfWeekSD(List<RunEvent> runs)
        {
            double[] miletimes = new double[runs.Count];
            double[] speeds = new double[runs.Count];
            for(int i = 0; i < runs.Count; i++)
            {
                miletimes[0] = runs[0].MileAverage();
                speeds[0] = runs[0].SpeedAverage();
            }
            double sdmile = StandardDeviation(miletimes);
            double sdspeed = StandardDeviation(speeds);
            return " Usual mile time between " + ConvertToMinSec(TotalMileAverage(runs) - sdmile).ToString("mm:ss") + " and " + ConvertToMinSec(TotalMileAverage(runs) + sdmile).ToString("mm:ss") + " -- Usual speed between " + (TotalSpeedAverage(runs) - sdspeed).ToString("F2") + "MPH and " + (TotalSpeedAverage(runs) + sdspeed).ToString("F2") + "MPH\n";
        }

    }
}
