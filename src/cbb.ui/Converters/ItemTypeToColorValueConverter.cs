namespace cbb.ui
{
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using System.Windows.Media;

    using core;

    /// <summary>
    /// Convert item type to <see cref="SolidColorBrush"/> color for ui as visual type indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    [ValueConversion(typeof(FamilyItem), typeof(SolidColorBrush))]
    public class ItemTypeToColorValueConverter : IValueConverter
    {
        #region public methods

        /// <summary>
        /// Converts a value.
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
            // Return color based on the 
            switch ((ItemType)value)
            {
                case ItemType.Project:
                    return new SolidColorBrush(Colors.OrangeRed);
                case ItemType.Family:
                    return new SolidColorBrush(Colors.CornflowerBlue);
                case ItemType.Cad:
                    return new SolidColorBrush(Colors.Yellow);
                case ItemType.Document:
                    return new SolidColorBrush(Colors.YellowGreen);
                case ItemType.None:
                    return new SolidColorBrush(Colors.Black);
            }

            // Indicate undefined item type, magenta for some kind of error in conversion process.
            return new SolidColorBrush(Colors.Magenta);
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
