using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
    class StatsUtil
    {
        private Modal modal;
        public StatsUtil(Modal modalin) { modal = modalin; }

        public double TotalTimeRun(IEnumerable<RunEvent> runs)
        {
            return runs.Sum(x => x.Time_of_run);
        }

        public double TotalDistance(IEnumerable<RunEvent> runs)
        {
            return runs.Sum(x => x.Distance);
        }

        public double TotalMileAverage(IEnumerable<RunEvent> runs) { return runs.Average(x => x.MileAverage); }

        public double TotalSpeedAverage(IEnumerable<RunEvent> runs) { return runs.Average(x => x.SpeedAverage); }

        public double DayOfWeekMileAvg(IEnumerable<RunEvent> runs)
        {
            return runs.Average(x => x.MileAverage);
        }

        public double DayOfWeekSpeedAvg(IEnumerable<RunEvent> runs)
        {
            return runs.Average(x => x.SpeedAverage);
        }

        //
        public double MileAverageByDate(DateTime date, IEnumerable<RunEvent> runs) { return TotalMileAverage(modal.GetRunsByDate(date, runs)); }

        public double AverageSpeedByDate(DateTime date, IEnumerable<RunEvent> runs)
        {
            return TotalSpeedAverage(modal.GetRunsByDate(date, runs));
        }

        public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

        public double StandardDeviation(IEnumerable<double> values)
        {
            return Math.Sqrt(values.Average(v => Math.Pow(v - values.Average(), 2)));
        }
    }
}
