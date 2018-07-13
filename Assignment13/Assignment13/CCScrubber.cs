using System.Text.RegularExpressions;

namespace Logger
{
    public class CCScrubber : AbstractScrubber
    {
        private CCScrubber() { }

        private static CCScrubber _Instance;

        public static CCScrubber Instance => _Instance ?? (_Instance = new CCScrubber());

        /// <summary>
        /// Regular expression for CC:
        /// 2133-3123-3123-3123
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}|\d{16}");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}