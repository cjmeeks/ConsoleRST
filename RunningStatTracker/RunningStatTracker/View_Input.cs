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
            return option;
        }


        public string AskForName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }


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

        public string AskForTerrain()
        {
            Console.Write("Terrain: ");
            return Console.ReadLine();
        }


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
            return new DateTime(Convert.ToInt32(datearray[2]), Convert.ToInt32(datearray[0]), Convert.ToInt32(datearray[1]));
        }


        public void AskForNewRunner() { modal.AddRunner(AskForName(), AskForGender()); Console.WriteLine(); }

        //
        public LoginInfo Login()
        {
            LoginInfo loginStatus = new LoginInfo();
            Runner runner = null;
            if (loginStatus.Status = modal.Runners.TryGetValue(AskForName(), out runner))
            {
                Console.WriteLine();
                loginStatus.CurRunner = runner;
                return loginStatus;
            }
            else return loginStatus;
        }


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
            string terrain = AskForTerrain();
            Console.WriteLine();
            return new RunEvent(date, timeofrun, distance, terrain);
        }


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
