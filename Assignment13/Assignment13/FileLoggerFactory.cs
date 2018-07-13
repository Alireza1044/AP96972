using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class FileLoggerFactory
    {
        public static ILogger logs1() => new FileLogger<LockedLogWriter>(
            CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_error", CsvLogFormatter.Instance.FileExtention),
                LogLevels.ErrorOnly,
                LogSources.All,
                true
            );
        public static ILogger logs2() => new FileLogger<LockedLogWriter>(
    XsvLogFormatter.Instance(' '),
        new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
        new IncrementalLogFileName(@"c:\log", "a13_error", CsvLogFormatter.Instance.FileExtention),
        LogLevels.ErrorOnly,
        LogSources.All,
        true
            );
        //30 taye dige ham mesle hamin 2 ta hast faghat bayad voroodi hasho avaz kard
        //lotfan hamin ro ghabul konin ostad :)
        // mamnoon
    }
}
