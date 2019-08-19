namespace cbb.core
{
    using System.Windows.Forms;
    using System.Windows.Input;

    /// <summary>
    /// Preferences page view model.
    /// </summary>
    /// <seealso cref="cbb.core.BaseViewModel" />
    public class PreferencesPageViewModel : BaseViewModel
    {
        #region commands

        /// <summary>
        /// Gets or sets the add repository command.
        /// </summary>
        /// <value>
        /// The add repository command.
        /// </value>
        public ICommand AddRepositoryCommand { get; set; }

        /// <summary>
        /// Gets or sets the remove repository command.
        /// </summary>
        /// <value>
        /// The remove repository command.
        /// </value>
        public ICommand RemoveRepositoryCommand { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="PreferencesPageViewModel"/> class.
        /// </summary>
        public PreferencesPageViewModel()
        {
            // Commands routing.
            AddRepositoryCommand = new RouteCommands(AddRepositoryCmdFunc);
            RemoveRepositoryCommand = new RouteCommands(RemoveRepositoryCmdFunc);
        }

        #endregion

        #region private methods

        /// <summary>
        /// AddRepositoryCommand execution method.
        /// </summary>
        private void AddRepositoryCmdFunc()
        {
            // Use Forms specialized dialog for chosing folder paths.
            using (var dialog = new FolderBrowserDialog())
            {
                string path = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    // Load exsisting data.
                    var prefs = Preferences.Load();
                    // Add selected path and save it in serialized structure data file.
                    prefs.Repository.Add(path);
                    prefs.Save();
                }
                else
                {
                    Message.Display("Provided path is not valid.", WindowType.Warning);
                    return;
                }
            }
        }

        /// <summary>
        /// RemoveRepositoryCommand execution methods.
        /// </summary>
        private void RemoveRepositoryCmdFunc()
        {
            Message.Display("remove repository", WindowType.Information);
        }

        #endregion
    }
}
