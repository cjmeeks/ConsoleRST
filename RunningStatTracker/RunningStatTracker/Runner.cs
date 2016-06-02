using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class Runner
    {
        private List<RunEvent> list_of_runs;
        private string name;
        private string gender;

        public Runner(string nameIn, string genderIn)
        {
            name = nameIn;
            gender = genderIn;
            list_of_runs = new List<RunEvent>();
        }

        public string Name { get { return name; } }
        public string Gender { get { return gender; } }
        public List<RunEvent> Runs{ get { return list_of_runs; } }

        //add run
        public void AddRun(RunEvent run) { list_of_runs.Add(run); }

        //to string
        public override string ToString() { return " Name: " + name + " - Gender: " + gender + " - #Runs = " + list_of_runs.Count; }














        //get day of week standard deviations












    }
}
