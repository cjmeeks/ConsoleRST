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
            Console.WriteLine("Main Menu");
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

        public void DisplayRunners(Runner[] runners)
        {
            int runnerNum = 1;
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runners----");
            foreach (Runner runner in runners)
            {
                Console.Write(runnerNum + ":");
                Console.WriteLine(runner.ToString());
                runnerNum++;
            }
            Console.WriteLine("\n" + "\n");
        }

        //need
        public void DisplayRuns(ref Runner runner)
        {
            int Run_Number = 1;
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("Runs----");
            foreach (RunEvent run in runner.Runs)
            {

                Console.Write(Run_Number + ")");
                Console.WriteLine(run.ToString());
                Run_Number++;
            }
            Console.WriteLine(modal.Totals(ref runner));
            Console.WriteLine("\n");

        }


        public void DisplayRunByDate(DateTime date, Runner runner)
        {
            Console.WriteLine("\n" + "\n");
            RunEvent run = modal.GetRunByDate(date, ref runner);
            Console.Write(run.ToString());
            Console.WriteLine("\n" + "\n");
        }

        //need
        public void DisplayRunByDayOfWeek(DayOfWeek day, Runner runner)
        {
            Console.WriteLine(day.ToString() + modal.DisplayDayOfWeekAverages(day, ref runner));
        }

    }
}
