﻿using System;

namespace Humanizer.Localisation
{
    public partial class ResourceKeys
    {
        /// <summary>
        /// Encapsulates the logic required to get the resource keys for DateTime.Humanize
        /// </summary>
        public static class DateHumanize
        {
            /// <summary>
            /// Resource key for Now.
            /// </summary>
            public const string Now = "DateHumanize_Now";

            /// <summary>
            /// Resource key for Never.
            /// </summary>
            public const string Never = "DateHumanize_Never";

            /// <summary>
            /// Examples: DateHumanize_SingleMinuteAgo, DateHumanize_MultipleHoursAgo
            /// Note: "s" for plural served separately by third part.
            /// </summary>
            private const string DateTimeFormat = "DateHumanize_{0}{1}{2}";

            private const string Ago = "Ago";
            private const string FromNow = "FromNow";

            /// <summary>
            /// Generates Resource Keys according to convention.
            /// </summary>
            /// <param name="timeUnit">Time unit</param>
            /// <param name="timeUnitTense">Is time unit in future or past</param>
            /// <param name="count">Number of units, default is One.</param>
            /// <returns>Resource key, like DateHumanize_SingleMinuteAgo</returns>
            public static string GetResourceKey(TimeUnit timeUnit, Tense timeUnitTense, int count = 1)
            {
                ValidateRange(count);

                if (count == 0)
                {
                    return Now;
                }

                string singularity;
                var unit = timeUnit.ToString();
                if (count == 1)
                {
                    singularity = Single;
                }
                else
                {
                    unit += "s";
                    singularity = Multiple;
                }

                var tense = timeUnitTense == Tense.Future ? FromNow : Ago;
                return DateTimeFormat.FormatWith(singularity, unit, tense);
            }
        }
    }
}
