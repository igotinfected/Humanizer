﻿namespace Humanizer
{
    /// <summary>
    /// <see cref="DateTime"/> extensions related to spatial or temporal relations
    /// </summary>
    public static class PrepositionsExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> with the specified hour and, optionally
        /// provided minutes, seconds, and milliseconds.
        /// </summary>
        public static DateTime At(this DateTime date, int hour, int min = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, min, second, millisecond);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to midnight
        /// </summary>
        public static DateTime AtMidnight(this DateTime date)
        {
            return date.At(0);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the time is set to noon
        /// </summary>
        public static DateTime AtNoon(this DateTime date)
        {
            return date.At(12);
        }

        /// <summary>
        /// Returns a new instance of DateTime based on the provided date where the year is set to the provided year
        /// </summary>
        public static DateTime In(this DateTime date, int year)
        {
            return new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
    }
}
