using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RunningStatTracker
{
    class View_Input
    {
        private Modal modal;
        public View_Input(Modal modalIn) { modal = modalIn; }

        //done
        public int AskForMainMenuOption()
        {
            bool CorrectInput = false;
            int option = 0;
            while(!CorrectInput)
            {
                Console.Write("Menu Option: ");
                option = Convert.ToInt32(Console.ReadLine().Trim());
                if (option > 0 && option < 5) { CorrectInput = true; break; }
                Console.WriteLine("Please enter 1-4....");
            }
            //Console.WriteLine("\n");
            return option;
        }

        public int AskForRunnerMenuOption()
        {
            bool CorrectInput = false;
            int option = 0;
            while(!CorrectInput)
            {
                Console.Write("Menu Option: ");
                option = Convert.ToInt32(Console.ReadLine().Trim());
                if (option > 0 && option < 6) { CorrectInput = true; break; }
                Console.WriteLine("Please enter 1-4....");
            }
            //Console.WriteLine("\n");
            return option;
        }

        //done
        public string AskForName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }

        //done
        public string AskForGender()
        {
            bool correctInput = false;
            string gender = " ";
            while (!correctInput)
            {
                Console.Write("Gender(M/F): ");
                gender = Console.ReadLine().ToUpper().Trim();
                if(gender.Equals("M") || gender.Equals("F")) { correctInput = true; break; }
                Console.WriteLine("Please enter M for male or F for female");

            }
            return gender;
        }

        //done
        public DateTime AskForDate()
        {
            bool correctInput = false;
            string[] datearray = null;
            while (!correctInput)
            {
                Console.Write("Date(mm/dd/yyyy): ");
                string date = Console.ReadLine().Trim();
                datearray = date.Split('/');
                if(datearray.Length == 3) { correctInput = true; break; }
                Console.WriteLine("Please enter date in the correct format");
            }
            Console.WriteLine();
            return new DateTime(Convert.ToInt32(datearray[2]), Convert.ToInt32(datearray[0]), Convert.ToInt32(datearray[1]));
        }

        //Asks for runner info to add
        public void AskForNewRunner() { modal.AddRunner(AskForName(), AskForGender()); Console.WriteLine("\n"); }

        //done
        public bool Login(ref Runner runner)
        {
            if (modal.Runners.TryGetValue(AskForName(), out runner)) return true;
            else return false;
        }

        //done
        public RunEvent AskForNewRun()
        {

            DateTime date = AskForDate();
            bool correctInput = false;
            string[] time = null;
            while (!correctInput)
            {
                Console.Write("Time Of Run(min:sec): ");
                time = Console.ReadLine().Trim().Split(':');
                if(time.Length == 2) { correctInput = true; break; }
                Console.WriteLine("Please enter time in correct format (Min:Sec");
            }
            double timeofrun = (Convert.ToDouble(time[0]) * 60) + Convert.ToDouble(time[1]);
            correctInput = false;
            double distance = 0;
            while (!correctInput)
            {
                Console.Write("Miles ran: ");
                distance = Convert.ToDouble(Console.ReadLine().Trim());
                if(distance > 0 && distance < 30) { correctInput = true; break; }
                Console.WriteLine("Ya right you didnt run {0} miles", distance);
            }

            Console.WriteLine();
            return new RunEvent(date, timeofrun, distance);
        }

        //error check
        public DayOfWeek AskForDayOfWeek()
        {
            Console.Write("Day of Week(m/tu/w/th/f/sa/sun): ");
            string day = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();
            switch(day)
            {
                case "m":
                    return DayOfWeek.Monday;
                case "tu":
                    return DayOfWeek.Tuesday;
                case "w":
                    return DayOfWeek.Wednesday;
                case "th":
                    return DayOfWeek.Thursday;
                case "f":
                    return DayOfWeek.Friday;
                case "sa":
                    return DayOfWeek.Saturday;
                case "sun":
                    return DayOfWeek.Sunday;
            }
           return DayOfWeek.Monday;
        }

    }
}
