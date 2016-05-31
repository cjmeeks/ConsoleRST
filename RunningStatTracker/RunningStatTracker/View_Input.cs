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
        //error check
        public int AskForMenuOption()
        {
            Console.Write("Menu Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        //error check
        public string AskForName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        //error check
        public string AskForGender()
        {
            Console.Write("Gender(M/F): ");
            return Console.ReadLine().ToUpper().Trim();
        }

        //error check
        public DateTime AskForDate()
        {
            Console.Write("Date(mm/dd/yyyy): ");
            string date = Console.ReadLine().Trim();
            string[] datearray = date.Split('/');
            return new DateTime(Convert.ToInt32(datearray[2]), Convert.ToInt32(datearray[0]), Convert.ToInt32(datearray[1]));
        }

        public void AskForRunner() { modal.AddRunner(AskForName(), AskForGender()); }

        //error check
        public Run AskForRun()
        {
                DateTime date = AskForDate();
                Console.Write("Time Of Run(min:sec): ");
                string[] time = Console.ReadLine().Trim().Split(':');
                double timeofrun = (Convert.ToDouble(time[0]) * 60) + Convert.ToDouble(time[1]);
                Console.Write("Miles ran: ");
                double distance = Convert.ToDouble(Console.ReadLine().Trim());
                return new Run(date, timeofrun, distance);
        }

    }
}
