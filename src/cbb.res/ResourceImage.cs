namespace cbb.res
{
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Gets the embedded resource image from the cbb.res assembly based on user provided file name with extension.
    /// Helper methods.
    /// </summary>
    public static class ResourceImage
    {
        #region public methods

        /// <summary>
        /// Gets the icon image from reource assembly.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static BitmapImage GetIcon(string name)
        {
            // Create the resource reader stream.
            var stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Images.Icons." + name);

            var image = new BitmapImage();

            // Construct and return image.
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            // Return constructed BitmapImage.
            return image;
        }

        #endregion
    }
}
