06-;﻿using System;
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

        public string Name => name;
        public string Gender => gender;
        public List<RunEvent> Runs => list_of_runs;

        public void AddRun(RunEvent run) { list_of_runs.Add(run); }

        //still needs the %string whatever
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Name: {0}", name);
            sb.Append(name);
            sb.AppendFormat(" - Gender: %s", gender);
            sb.AppendFormat(" - #Runs = {0}", list_of_runs.Count);
            return sb.ToString;
        }














        //get day of week standard deviations












    }
}
