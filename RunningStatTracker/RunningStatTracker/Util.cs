using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningStatTracker
{
        public class Util
        {
            public Util(){}

            public double TotalTimeRun(IEnumerable runs)
            {
              return runs.Sum(x => x.Time_of_run);
            }

            public double TotalDistance(IEnumerable runs)
            {
                return runs.Sum(x => x.Distance);
            }

            public double MileAverageForRun(DateTime date, ref Runner runner){return GetRunByDate(date, ref  runner).MileAverage;}

            public double TotalMileAverage(IEnumerable runs) {return runs.Average(x => x.MileAverage;}

            public double TotalSpeedAverage(IEnumerable runs) {return runs.Average(x => x.SpeedAverage;}

            public double DayOfWeekMileAvg(IEnumerable runs)
            {
                return runs.Average(x => x.MileAverage;
            }

            public double DayOfWeekSpeedAvg(IEnumerable runs)
            {
                return runs.Average(x => x.SpeedAverage;)
            }

            public IEnumerable GetRunsByDayOfWeek(DayOfWeek day, List<RunEvent> runs)
            {
                return runs.Where(x => x.Date.DayOfWeek == day);
            }

            //ref runner
            public double AverageSpeedOneRun(DateTime date, ref Runner runner) { return GetRunByDate(date, ref runner).SpeedAverage; }

            //ref runner
            public DateTime ConvertToMinSec(double seconds) { return new DateTime(TimeSpan.FromSeconds(seconds).Ticks); }

            public static double StandardDeviation(IEnumerable values)
            {
                return Math.Sqrt(values.Average(v=>Math.Pow(v-values.Average(),2)));
            }
        }
}
