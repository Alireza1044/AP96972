using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {
        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount: 25, linePerThread: 1000);
        }
        // Number of Threads               1     2      5      10     20     50      100
        // LockedLogWriterPerfTest     : 0.41   0.44   0.57   1.59   7.30   35.70   a lot
        //ConcurrentLogWriterPerfTest  : 0.40   0.42   0.52   0.87   1.60   4.84    a lot
        //LockedQueueLogWriterPerfTest : 0.47   0.50   0.62   0.94   1.91   5.75    a lot

        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount: 25, linePerThread: 1000);
        }

        [TestMethod()]
        public void LockedQueueLogWriterPerfTest()
        {
            var time = PerfTest<LockedQueueLogWriter>(threadCount: 100, linePerThread: 1000);
        }

        /// <summary>
        /// this method creates 25 threads
        /// there is no "lock" statement which means all the threads try to access an object at once
        /// by other means its not "thread-safe"
        /// and so there will be an exception thrown!
        /// </summary>
        //[TestMethod()]
        //public void NoLockPerfTest()
        //{
        //    var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        //}

        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter : GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join());
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();

            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i = 0; i < count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}