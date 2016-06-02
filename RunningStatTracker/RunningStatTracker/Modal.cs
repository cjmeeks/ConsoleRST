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

        public SortedDictionary<string, Runner> Runners => runners;

        //methods
        public void AddRunner(string name, string gender) { runners.Add(name, new Runner(name, gender)); }

        public Runner GetRunnerByName(string name) { return runners[name]; }

        public IEnumerable<Runner> GetAllRunners()
        {
            return runners.Values;
        }

        public IEnumerable<RunEvent> GetRunsByDayOfWeek(DayOfWeek day, IEnumerable<RunEvent> runs)
        {
            return runs.Where(x => x.Date.DayOfWeek == day);
        }

        public IEnumerable<RunEvent> GetRunsByDate(DateTime date, IEnumerable<RunEvent> runs)
        {
            return runs.Where(x => x.Date == date);
        }

        public IEnumerable<RunEvent> GetRunsByDay(DayOfWeek day, IEnumerable<RunEvent> runs)
        {
            return runs.Where(x => x.Date.DayOfWeek == day);
        }


    }
}
