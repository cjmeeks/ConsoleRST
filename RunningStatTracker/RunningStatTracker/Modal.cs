using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Modal
    {
        private Dictionary<string, Runner> runners;

        public Modal()
        {
            runners = new Dictionary<string, Runner>();
        }

        public void AddRunner(string name, string gender)
        {
            runners.Add(name, new Runner(name, gender));
        }

        public Runner GetRunnerByName(string name)
        {
            return runners[name];
        }
        public Runner[] GetAllRunners()
        {
            Runner[] tempRunners = new Runner[runners.Values.Count];
            runners.Values.CopyTo(tempRunners, 0);
            return tempRunners;
        }




    }
}
