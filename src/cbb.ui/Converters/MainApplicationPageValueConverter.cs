namespace cbb.ui
{
    using System;
    using System.Windows.Data;
    using System.Globalization;

    using core;

    /// <summary>
    /// Convert <see cref="ApplicationPageType"/> to actual page.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class MainApplicationPageValueConverter : IValueConverter
    {
        #region public methods

        /// <summary>
        /// Converts a application page to actual view page.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Switch current application page based on provided type of the page.
            switch ((ApplicationPageType)value)
            {
                case ApplicationPageType.Family:
                    return new FamilyPage();
                case ApplicationPageType.Preferences:
                    return new PreferencesPage();
                default:
                    return new FamilyPage();
            }
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
