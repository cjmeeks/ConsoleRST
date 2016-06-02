using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class View_Output
    {
        private Modal modal;
        private StatsUtil stats;
        public View_Output(Modal modalIn) { modal = modalIn; stats = new StatsUtil(modal); }

        public void DisplayTitleMessage() { Console.WriteLine("Welcome To My Running Stat Tracker!"); }

        public void DisplayMainMenu()
        {
            Console.WriteLine("\n Main Menu");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Add Runner");
            Console.WriteLine("3) Display Runners");
            Console.WriteLine("4) Exit");

        }

        public void DisplayRunnerMenu()
        {
            Console.WriteLine("Runner Menu");
            Console.WriteLine("1) Add Run");
            Console.WriteLine("2) Display Runs");
            Console.WriteLine("3) Display Run");
            Console.WriteLine("4) Display Run average by day of the week");
            Console.WriteLine("5) Exit to Main Menu");
        }

        //
        public void DisplayRunners(IEnumerable<Runner> runners)
        {
            int runnerNum = 1;
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runners----");
            runners.ToList().ForEach(x => {
                Console.Write("{0}:", runnerNum);
                Console.WriteLine(x.ToString());
                runnerNum++;
                });
            Console.WriteLine();
        }

        //
        public void DisplayRuns(IEnumerable<RunEvent> runs)
        {
            int Run_Number = 1;
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runs----");
            runs.ToList().ForEach(x => {
                Console.Write("{0})", Run_Number);
                Console.WriteLine(x.ToString());
                Run_Number++;
                });
            Console.WriteLine("Totals**");
            Console.WriteLine(DisplayTotals(runs));
            Console.Write(DisplaySDTotals(runs));
            Console.WriteLine();
        }
        //
        public void DisplayRunByDate(DateTime date, IEnumerable<RunEvent> runs)
        {
            Console.WriteLine();
            runs.ToList().ForEach(x => {
                Console.WriteLine(x.ToString());
                });
            Console.WriteLine();
        }

        //
        public void DisplayRunsByDayOfWeek(DayOfWeek day, IEnumerable<RunEvent> runs)
        {
            Console.WriteLine(day.ToString());
            runs.ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" --{0}\n", DisplayDayOfWeekAverages(day, runs));
            sb.Append(DisplaySDTotals(modal.GetRunsByDayOfWeek(day, runs)));
            Console.WriteLine(sb.ToString());
        }

        //%string
        public string DisplayTotals(IEnumerable<RunEvent> runs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("      Total Time Ran: {0}", stats.ConvertToMinSec(stats.TotalTimeRun(runs)).ToString("mm:ss"));
            sb.AppendFormat(" - Total Distance Ran: {0}", stats.TotalDistance(runs).ToString("F2"));
            sb.AppendFormat(" - Miles  Total Mile Average Time: {0}", stats.ConvertToMinSec(stats.TotalMileAverage(runs)).ToString("mm:ss"));
            sb.AppendFormat(" - Total Speed Average: {0}", stats.TotalSpeedAverage(runs).ToString("F2"));
            sb.Append("MPH");
            return sb.ToString();
        }

       //
        public string DisplayDayOfWeekAverages(DayOfWeek day, IEnumerable<RunEvent> runs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Average Mile Time: {0}", stats.ConvertToMinSec(stats.DayOfWeekMileAvg(modal.GetRunsByDayOfWeek(day, runs))).ToString("mm:ss"));
            sb.AppendFormat("  Average Speed: {0}", stats.DayOfWeekSpeedAvg(modal.GetRunsByDayOfWeek(day, runs)).ToString("F2"));
            sb.Append("MPH\n");
            return sb.ToString();
        }

        //%string
        public string DisplaySDTotals(IEnumerable<RunEvent> runs)
        {
            double sdMile = stats.StandardDeviation(modal.GetMileAverages(runs));
            double sdSpeed = stats.StandardDeviation(modal.GetSpeedAverages(runs));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("      Usual mile time between {0}", stats.ConvertToMinSec(stats.TotalMileAverage(runs) - sdMile).ToString("mm:ss"));
            sb.AppendFormat(" and {0}", stats.ConvertToMinSec(stats.TotalMileAverage(runs) + sdMile).ToString("mm:ss"));
            sb.AppendFormat(" -- Usual speed between {0}", (stats.TotalSpeedAverage(runs) - sdSpeed).ToString("F2"));
            sb.AppendFormat("MPH and {0}", (stats.TotalSpeedAverage(runs) + sdSpeed).ToString("F2"));
            sb.Append("MPH\n");
            return sb.ToString();
        }      
    }
}
