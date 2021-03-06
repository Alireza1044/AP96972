﻿using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest 
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's KodMelli is  108-0492704";
            string expectedString = "Ali's KodMelli is  XXX-XXXXXXX";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void EmailTest()
        {
            string testString = "Ali's Email is Ali@gmail.com";
            string expectedString = "Ali's Email is Xxx@xxxxx.xxx";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void CCTest()
        {
            string testString = "Ali's CC is 6037-4324-5432-7547";
            string expectedString = "Ali's CC is XXXX-XXXX-XXXX-XXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }


    }

}
