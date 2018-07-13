using System.Text.RegularExpressions;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        private EmailScrubber() { }

        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());

        /// <summary>
        /// Regular expression for Email:
        /// alireza@gmail.com
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\w*\@\w*\.com");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskLetters);
    }
}