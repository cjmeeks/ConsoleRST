using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class LoginInfo
    {
        private bool login_status;
        private Runner runner;

        public LoginInfo(bool status, Runner runnerIn)
        {
            login_status = status;
            runner = runnerIn;
        }
        public LoginInfo() { }

        public bool Status => login_status;
        public Runner CurRunner => runner;
    }

}
