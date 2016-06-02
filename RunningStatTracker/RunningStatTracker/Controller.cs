using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Controller
    {
        private Modal modal;
        private View_Output output;
        private View_Input input;

        public Controller()
        {
            modal = new Modal();
            output = new View_Output(modal);
            input = new View_Input(modal);
        }

        public void Go()
        {
            int option = 0;
            bool exitCode = false;
            output.DisplayTitleMessage();
            while(!exitCode)
            {
                output.DisplayMainMenu();
                option = input.AskForMainMenuOption();
                MainMenu(option, ref exitCode);
            }
        }

        public void MainMenu(int option , ref bool exitCode)
        {
            switch (option)
            {
                case 1:
                    Runner runner = null;
                    bool login = input.Login(ref runner);
                    if (!login) Console.WriteLine("login failed \n");
                    else
                    {
                        bool exit = false;
                        while (!exit)
                        {
                            output.DisplayRunnerMenu();
                            RunnerMenu(ref runner, input.AskForRunnerMenuOption(), ref exit);
                        }
                    }
                    break;
                case 2:
                    input.AskForNewRunner();
                    break;
                case 3:
                    output.DisplayRunners(modal.GetAllRunners());
                    break;
                case 4:
                    exitCode = true;
                    break;
            }
        }

        public void RunnerMenu(ref Runner runner, int option, ref bool exitCode)
        {

            switch(option)
            {
                case 1:
                    runner.AddRun(input.AskForNewRun());
                    break;
                case 2:
                    output.DisplayRuns(ref runner);
                    break;
                case 3:
                    output.DisplayRunByDate(input.AskForDate(), ref runner);
                    break;
                case 4:
                    DayOfWeek date = input.AskForDayOfWeek();
                    output.DisplayRunsByDayOfWeek(date,modal. GetRunsByDayOfWeek(date, ref runner), ref runner);
                    break;
                case 5:
                    exitCode = true;
                    break;
            }
        }
    }
}
