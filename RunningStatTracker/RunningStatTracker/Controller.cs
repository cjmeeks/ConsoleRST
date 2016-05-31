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
                option = input.AskForMenuOption();
                MainMenu(option, ref exitCode);
            }
        }

        public void MainMenu(int option , ref bool exitCode)
        {
            switch (option)
            {
                case 1:
                    string name = input.AskForName();
                    bool exit = false;
                    while(!exit)
                    {
                        output.DisplayRunnerMenu();
                        RunnerMenu(name, input.AskForMenuOption(), ref exit);
                    }
                    break;
                case 2:
                    input.AskForRunner();
                    break;
                case 3:
                    output.DisplayRunners();
                    break;
                case 4:
                    exitCode = true;
                    break;
            }
        }

        public void RunnerMenu(string name, int option, ref bool exitCode)
        {
            Runner runner = modal.GetRunnerByName(name);
            switch(option)
            {
                case 1:
                    runner.AddRun(input.AskForRun());
                    break;
                case 2:
                    output.DisplayRuns(ref runner);
                    break;
                case 3:
                    exitCode = true;
                    break;
            }
        }
    }
}
