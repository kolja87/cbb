namespace cbb.core
{
    using System.IO;
    using System.Text;
    using System.Windows.Input;

    /// <summary>
    /// Represents a repository location folder with metadata attached to it.
    /// A folder that contains Revit relevant files/items.
    /// </summary>
    public class RepositoryItem
    {
        #region public properties

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath { get; set; }

        /// <summary>
        /// Gets the name of the repository folder.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => PathHelpers.GetFolderName(FullPath);

        #endregion

        #region commands

        public ICommand AddRepositoryCommand { get; set; }

        public ICommand RemoveRepositoryCommand { get; set; }

        public ICommand PropertiesRepositoryCommand { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Deafult constructor.
        /// Initializes a new instance of the <see cref="RepositoryItem"/> class.
        /// </summary>
        public RepositoryItem()
        {
            AddRepositoryCommand = new RouteCommands(AddRepositoryCmdFunc);
            RemoveRepositoryCommand = new RouteCommands(RemoveRepositoryCmdFunc);
            PropertiesRepositoryCommand = new RouteCommands(PropertiesRepositoryCmdFunc);
        }

        #endregion

        #region private methods

        /// <summary>
        /// AddRepositoryCommand execute method.
        /// </summary>
        private void AddRepositoryCmdFunc()
        {
            Repository.Add();
        }

        /// <summary>
        /// RemoveRepositoryCommand execute method.
        /// </summary>
        private void RemoveRepositoryCmdFunc()
        {
            // Load current repository paths.
            var prefs = Preferences.Load();
            var repository = prefs.Repository;

            var index = repository.IndexOf(FullPath);

            // Remove selected item from repository list.
            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[index].Equals(FullPath))
                    repository.RemoveAt(index);
            }

            prefs.Repository = repository;
            prefs.Save();
        }

        /// <summary>
        /// PropertiesRepositoryCommand execute method.
        /// </summary>
        private void PropertiesRepositoryCmdFunc()
        {
            //todo this is just test repository data code, replace later.
            var createTime = Directory.GetCreationTime(FullPath);
            var lastWriteTime = Directory.GetLastWriteTime(FullPath);
            var msg = new StringBuilder();
            msg.AppendLine("Last write time: " + lastWriteTime + "\n" + "Created: " + createTime);
            Message.Display(msg.ToString(), WindowType.Information);
        }

        #endregion
    }
}
