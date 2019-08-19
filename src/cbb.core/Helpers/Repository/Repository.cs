namespace cbb.core
{
    using System.Windows.Forms;

    /// <summary>
    /// Repository helper functions.
    /// </summary>
    public static class Repository
    {
        #region public methods

        /// <summary>
        /// Adds one repository to saved file.
        /// </summary>
        public static void Add()
        {
            // Use Windows Forms specialized dilog for chosing folder path.
            using (var dialog = new FolderBrowserDialog())
            {
                string path = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;

                    // Load exsisting data.
                    var prefs = Preferences.Load();
                    // Add selected path and save it in serialized strecture data file.
                    prefs.Repository.Add(path);
                    prefs.Save();
                }
                else if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    Message.Display("Provided path is not valid", WindowType.Warning);
                    return;
                }
            }
            
        }

        #endregion
    }
}
