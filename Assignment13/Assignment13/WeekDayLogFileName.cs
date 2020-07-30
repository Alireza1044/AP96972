using System;
using System.IO;
using System.Linq;

namespace Logger
{
    public class WeekDayLogFileName : LogFileNamePolicy
    {
        public WeekDayLogFileName(string logDir, string logPrefix, string logExt)
            : base(logDir, logPrefix, logExt)
        { }

        public override string NextFileName() =>
            Path.Combine(LogDir,
                $"{LogPrefix}_{DateTime.Today.DayOfWeek.ToString()}.{LogExt}");

    }
}