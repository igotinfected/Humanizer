﻿using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.Formatters
{
    internal class LithuanianFormatter : DefaultFormatter
    {
        public LithuanianFormatter()
            : base("lt")
        {
        }

        protected override string GetResourceKey(string resourceKey, int number)
        {
            if (resourceKey == "TimeSpanHumanize_Zero")
            {
                return resourceKey;
            }

            var grammaticalNumber = LithuanianNumberFormDetector.Detect(number);
            var suffix = GetSuffix(grammaticalNumber);
            return resourceKey + suffix;
        }

        private static string GetSuffix(LithuanianNumberForm form)
        {
            if (form == LithuanianNumberForm.Singular)
            {
                return "_Singular";
            }

            if (form == LithuanianNumberForm.GenitivePlural)
            {
                return "_Plural";
            }

            return "";
        }
    }
}
