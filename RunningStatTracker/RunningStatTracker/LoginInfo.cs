using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class LoginInfo
    {
        private bool status;
        private Runner currunner;

        public LoginInfo()
        {
            status = false;
            currunner = null;
        }

        public bool Status { get { return status; } set { status = value; } }
        public Runner CurRunner { get { return currunner; } set { currunner = value; } }
    }

}
