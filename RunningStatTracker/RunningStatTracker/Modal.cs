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

        public IEnumerable GetAllRunners()
        {
            retrn runners.values;
        }


        public IEnumerable GetRunsByDate(DateTime date, IEnumerable runs)
        {
            return runs.Where(x => x.Date == date);
        }


        public IEnumerable GetRunsByDay(DayOfWeek day, IEnumerable runs)
        {
            return runs.Where(x => x.Date.DayOfWeek == day);
        }
        //
        /*public double[] GetMileAverages(List<RunEvent> runs)
        {
            double[] averages = new double[runs.Count];
            int i = 0;
            foreach(RunEvent run in runs)
            {
                averages[i] = run.MileAverage();
                i++;
            }
            return averages;
        }*/

        //
      /*  public double[] GetSpeedAverages(List<RunEvent> runs)
        {
            double[] averages = new double[runs.Count];
            int i = 0;
            foreach(RunEvent run in runs)
            {
                averages[i] = run.SpeedAverage();
                i++;
            }
            return averages;
        }*/

        

    }
}
