﻿using System.Globalization;
using System.Reflection;
using Humanizer.DateTimeHumanizeStrategy;
using Humanizer.Localisation.CollectionFormatters;
using Humanizer.Localisation.DateToOrdinalWords;
using Humanizer.Localisation.Formatters;
using Humanizer.Localisation.NumberToWords;
using Humanizer.Localisation.Ordinalizers;
#if NET6_0_OR_GREATER
using Humanizer.Localisation.TimeToClockNotation;
#endif

namespace Humanizer.Configuration
{
    /// <summary>
    /// Provides a configuration point for Humanizer
    /// </summary>
    public static class Configurator
    {
        /// <summary>
        /// A registry of formatters used to format collections based on the current locale
        /// </summary>
        public static LocaliserRegistry<ICollectionFormatter> CollectionFormatters { get; } = new CollectionFormatterRegistry();

        /// <summary>
        /// A registry of formatters used to format strings based on the current locale
        /// </summary>
        public static LocaliserRegistry<IFormatter> Formatters { get; } = new FormatterRegistry();

        /// <summary>
        /// A registry of number to words converters used to localise ToWords and ToOrdinalWords methods
        /// </summary>
        public static LocaliserRegistry<INumberToWordsConverter> NumberToWordsConverters { get; } = new NumberToWordsConverterRegistry();

        /// <summary>
        /// A registry of ordinalizers used to localise Ordinalize method
        /// </summary>
        public static LocaliserRegistry<IOrdinalizer> Ordinalizers { get; } = new OrdinalizerRegistry();

        /// <summary>
        /// A registry of ordinalizers used to localise Ordinalize method
        /// </summary>
        public static LocaliserRegistry<IDateToOrdinalWordConverter> DateToOrdinalWordsConverters { get; } = new DateToOrdinalWordsConverterRegistry();

#if NET6_0_OR_GREATER
        /// <summary>
        /// A registry of ordinalizers used to localise Ordinalize method
        /// </summary>
        public static LocaliserRegistry<IDateOnlyToOrdinalWordConverter> DateOnlyToOrdinalWordsConverters { get; } = new DateOnlyToOrdinalWordsConverterRegistry();

        /// <summary>
        /// A registry of time to clock notation converters used to localise ToClockNotation methods
        /// </summary>
        public static LocaliserRegistry<ITimeOnlyToClockNotationConverter> TimeOnlyToClockNotationConverters { get; } = new TimeOnlyToClockNotationConvertersRegistry();
#endif

        internal static ICollectionFormatter CollectionFormatter
        {
            get
            {
                return CollectionFormatters.ResolveForUiCulture();
            }
        }

        /// <summary>
        /// The formatter to be used
        /// </summary>
        /// <param name="culture">The culture to retrieve formatter for. Null means that current thread's UI culture should be used.</param>
        internal static IFormatter GetFormatter(CultureInfo culture)
        {
            return Formatters.ResolveForCulture(culture);
        }

        /// <summary>
        /// The converter to be used
        /// </summary>
        /// <param name="culture">The culture to retrieve number to words converter for. Null means that current thread's UI culture should be used.</param>
        internal static INumberToWordsConverter GetNumberToWordsConverter(CultureInfo culture)
        {
            return NumberToWordsConverters.ResolveForCulture(culture);
        }

        /// <summary>
        /// The ordinalizer to be used
        /// </summary>
        internal static IOrdinalizer Ordinalizer
        {
            get
            {
                return Ordinalizers.ResolveForUiCulture();
            }
        }

        /// <summary>
        /// The ordinalizer to be used
        /// </summary>
        internal static IDateToOrdinalWordConverter DateToOrdinalWordsConverter
        {
            get
            {
                return DateToOrdinalWordsConverters.ResolveForUiCulture();
            }
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// The ordinalizer to be used
        /// </summary>
        internal static IDateOnlyToOrdinalWordConverter DateOnlyToOrdinalWordsConverter
        {
            get
            {
                return DateOnlyToOrdinalWordsConverters.ResolveForUiCulture();
            }
        }

        internal static ITimeOnlyToClockNotationConverter TimeOnlyToClockNotationConverter
        {
            get
            {
                return TimeOnlyToClockNotationConverters.ResolveForUiCulture();
            }
        }
#endif

        /// <summary>
        /// The strategy to be used for DateTime.Humanize
        /// </summary>
        public static IDateTimeHumanizeStrategy DateTimeHumanizeStrategy { get; set; } = new DefaultDateTimeHumanizeStrategy();

        /// <summary>
        /// The strategy to be used for DateTimeOffset.Humanize
        /// </summary>
        public static IDateTimeOffsetHumanizeStrategy DateTimeOffsetHumanizeStrategy { get; set; } = new DefaultDateTimeOffsetHumanizeStrategy();

#if NET6_0_OR_GREATER
        /// <summary>
        /// The strategy to be used for DateOnly.Humanize
        /// </summary>
        public static IDateOnlyHumanizeStrategy DateOnlyHumanizeStrategy { get; set; } = new DefaultDateOnlyHumanizeStrategy();

        /// <summary>
        /// The strategy to be used for TimeOnly.Humanize
        /// </summary>
        public static ITimeOnlyHumanizeStrategy TimeOnlyHumanizeStrategy { get; set; } = new DefaultTimeOnlyHumanizeStrategy();
#endif

        private static readonly Func<PropertyInfo, bool> DefaultEnumDescriptionPropertyLocator = p => p.Name == "Description";
        private static Func<PropertyInfo, bool> _enumDescriptionPropertyLocator = DefaultEnumDescriptionPropertyLocator;
        /// <summary>
        /// A predicate function for description property of attribute to use for Enum.Humanize
        /// </summary>
        public static Func<PropertyInfo, bool> EnumDescriptionPropertyLocator
        {
            get { return _enumDescriptionPropertyLocator; }
            set { _enumDescriptionPropertyLocator = value ?? DefaultEnumDescriptionPropertyLocator; }
        }
    }
}
