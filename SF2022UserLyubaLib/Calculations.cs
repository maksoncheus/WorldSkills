using static System.Formats.Asn1.AsnWriter;

namespace SF2022UserLyubaLib
{
    public class Calculations
    {
        public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            if (startTimes is null || durations is null)
                throw new NullReferenceException("Один или оба массива не проинициализированы");
            if (startTimes.Length != durations.Length)
                throw new ArgumentException("Длины массивов не равны!");
            if (consultationTime <= 0)
                throw new ArgumentException("Необходимое время должно быть больше нуля!");
            if (beginWorkingTime > endWorkingTime) throw new ArgumentException("Рабочий день не может начинаться позже, чем он заканчивается!");
            if (startTimes.Length == 0 || durations.Length == 0)
                throw new ArgumentException("Один из массивов пуст");
            if (startTimes.Any(x => x < beginWorkingTime || x > endWorkingTime))
                throw new ArgumentException("Сотрудник не может быть занят вне своего рабочего времени!");
            List<string> periods = new List<string>();
            var sortedByTimes = startTimes
            .Zip(durations, (t, s) => new { time = t, duration = s })
            .OrderBy(x => x.time).ToList();

            periods.AddRange(GetPeriodsInRange(beginWorkingTime, sortedByTimes[0].time, consultationTime));
            for (int i = 0; i < sortedByTimes.Count - 1; i++)
            {
                periods.AddRange(GetPeriodsInRange(sortedByTimes[i].time + TimeSpan.FromMinutes(sortedByTimes[i].duration), sortedByTimes[i + 1].time, consultationTime));
            }
            periods.AddRange(GetPeriodsInRange(sortedByTimes.Last().time + TimeSpan.FromMinutes(sortedByTimes.Last().duration), endWorkingTime, consultationTime));

            return periods.ToArray();
        }

        private IEnumerable<string> GetPeriodsInRange(TimeSpan begin, TimeSpan end, int consultationTime)
        {
            List<string> periods = new();
            while (begin.Add(TimeSpan.FromMinutes(consultationTime)) <= end)
            {
                periods.Add(Format(begin) + "-" + Format(begin.Add(TimeSpan.FromMinutes(consultationTime))));
                begin = begin.Add(TimeSpan.FromMinutes(consultationTime));
            }
            return periods;
        }
        private string Format(TimeSpan ts)
        {
            return ts.ToString(@"hh\:mm");
        }
        static void Main()
        {

        }

        public int Sum(int v1, int v2) => v1 + v2;
        public int[] GetEmptyArray() => new int[] { };
    }
}