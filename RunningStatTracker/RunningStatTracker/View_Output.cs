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
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Add Runner");
            Console.WriteLine("3) Display Runners");
            Console.WriteLine("4) Exit");
        }

        public void DisplayRunnerMenu()
        {
            Console.WriteLine("1) Add Run");
            Console.WriteLine("2) Display Runs");
            Console.WriteLine("3) Exit to Main Menu");
        }

        public void DisplayRunners()
        {
            int runnerNum = 1;
            Runner[] runners = modal.GetAllRunners();
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runners----");
            foreach (Runner runner in runners)
            {
                Console.WriteLine(runnerNum + ": Name: " + runner.Name + " Gender: " + runner.Gender);
                runnerNum++;
            }
            Console.WriteLine("\n" + "\n");
        }

        public void DisplayRuns(ref Runner runner)
        {
            int Run_Number = 1;
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runs----");
            foreach (Run run in runner.Runs)
            {
                
                Console.WriteLine(Run_Number + ")   Date: " + run.Date.ToString("M/d/yyyy") +"   Distance: " + run.Distance.ToString("F2") + " Miles   Time: " + modal.ConvertToMinSec(run.Time_of_run).ToString("mm:ss") + "   Average Mile Time: " + modal.ConvertToMinSec(run.MileAverage()).ToString("mm:ss") + "   Average Speed: " + run.SpeedAverage().ToString("F2") + "MPH");
                Run_Number++;
            }
            Console.WriteLine("      Total Time Ran: "  + modal.ConvertToMinSec(runner.TotalTimeRun()).ToString("mm:ss") + "  Total Distance Ran: " + runner.TotalDistance().ToString("F2") + " Miles  Total Mile Average Time: " + modal.ConvertToMinSec(runner.TotalMileAverage()).ToString("mm:ss") +  "  Total Speed Average: " + runner.TotalSpeedAverage().ToString("F2") + "MPH");
            Console.WriteLine("\n" + "\n");
        }

    }
}
