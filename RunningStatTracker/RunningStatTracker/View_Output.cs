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
        public View_Output(Modal modalIn) { modal = modalIn; }

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
            Console.WriteLine(modal.Totals(ref runner));
            Console.Write(modal.SDTotals(ref runner));
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
            sb.AppendFormat(" --{0}\n", modal.DayOfWeekAverages(day, runs));
            sb.Append(modal.DayOfWeekSD(modal.GetRunsByDayOfWeek(day, runs)));
            Console.WriteLine(sb.ToString());
        }

        //%string
        public string DisplayTotals(IEnumerable<RunEvent> runs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("      Total Time Ran: {0}", ConvertToMinSec(TotalTimeRun(runs)).ToString("mm:ss"));
            sb.AppendFormat(" - Total Distance Ran: {0}", TotalDistance(runs).ToString("F2"));
            sb.AppendFormat(" - Miles  Total Mile Average Time: {0}", ConvertToMinSec(TotalMileAverage(runs)).ToString("mm:ss"));
            sb.AppendFormat(" - Total Speed Average: {0}", TotalSpeedAverage(runs).ToString("F2"));
            sb.Append("MPH");
            return sb.ToString();
        }

       //
        public string DisplayDayOfWeekAverages(DayOfWeek day, IEnumerable<RunEvent> runs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Average Mile Time: {0}", ConvertToMinSec(DayOfWeekMileAvg(GetRunsByDayOfWeek(day, runs))).ToString("mm:ss"));
            sb.AppendFormat("  Average Speed: {0}", DayOfWeekSpeedAvg(GetRunsByDayOfWeek(day, runs)).ToString("F2"));
            sb.Append("MPH\n");
            return sb.ToString;
        }

        //%string
        public string DisplaySDTotals(IEnumerable<RunEvent> runs)
        {
            double sdMile = StandardDeviation(GetMileAverages(runs));
            double sdSpeed = StandardDeviation(GetSpeedAverages(runs));
            StringBuilder sb = StringBuilder();
            sb.AppendFormat("      Usual mile time between {0}", ConvertToMinSec(TotalMileAverage(runs)- sdMile).ToString("mm:ss"));
            sb.AppendFormat(" and {0}", ConvertToMinSec(TotalMileAverage(runs)-sdMile).ToString("mm:ss"));
            sb.AppendFormat(" -- Usual speed between {0}", (TotalSpeedAverage(runs) - sdSpeed).ToString("F2"));
            sb.AppendFormat("MPH and {0}", (TotalSpeedAverage(runs) + sdSpeed).ToString("F2"));
            sb.Append("MPH\n");
            return sb.ToString();
        }
        //still need %whatever for strings
        public string DisplayDayOfWeekSD(IEnumerable<RunEvent> runs)
        {

            double sdmile = StandardDeviation(runs.Select(x => x.MileAverage));
            double sdspeed = StandardDeviation(runs.Select(x => x.SpeedAverage));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Usual mile time between {0}", ConvertToMinSec(TotalMileAverage(runs) - sdmile).ToString("mm:ss"));
            sb.AppendFormat(" and {0}", ConvertToMinSec(TotalMileAverage(runs) + sdmile).ToString("mm:ss"));
            sb.AppendFormat(" -- Usual speed between {0}", (TotalSpeedAverage(runs) - sdspeed).ToString("F2"));
            sb.AppendFormat("MPH and {0}", (TotalSpeedAverage(runs) + sdspeed).ToString("F2"));
            sb.Append("MPH\n");
            return sb.ToString();
        }

    }
}
