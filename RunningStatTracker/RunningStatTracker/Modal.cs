using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Modal
    {
        private SortedDictionary<string, Runner> runners;

        public Modal() { runners = new SortedDictionary<string, Runner>(); }

        public void AddRunner(string name, string gender) { runners.Add(name, new Runner(name, gender)); }

        public Runner GetRunnerByName(string name) { return runners[name]; }

        public Runner[] GetAllRunners()
        {
            Runner[] tempRunners = new Runner[runners.Values.Count];
            runners.Values.CopyTo(tempRunners, 0);
            return tempRunners;
        }
        //converts to Min:sec
        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }


    }
}
