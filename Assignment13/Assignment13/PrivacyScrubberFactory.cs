namespace Logger
{
    public static class PrivacyScrubberFactory
    {
        public static IPrivacyScrubber ScrubAll() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                EmailScrubber.Instance,
                CCScrubber.Instance,
                FullNameScrubber.Instance
    );
        public static IPrivacyScrubber ScrubNumbers() => new PrivacyScrubber(
            PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                CCScrubber.Instance
    );
        public static IPrivacyScrubber ScrubLetters() => new PrivacyScrubber(
        EmailScrubber.Instance,
        FullNameScrubber.Instance
    );
    }
}