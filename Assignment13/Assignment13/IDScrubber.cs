using System.Text.RegularExpressions;

namespace Logger
{
    public class IDScrubber : AbstractScrubber
    {
        private IDScrubber() { }

        private static IDScrubber _Instance;

        public static IDScrubber Instance => _Instance ?? (_Instance = new IDScrubber());

        /// <summary>
        /// Regular expression for ID:
        /// 521-321212
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\d{3}[-]\d{7}");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}