namespace cbb.core
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Repository list view model for list view in ui control.
    /// </summary>
    /// <seealso cref="cbb.core.BaseViewModel" />
    public class RepositoryListViewModel : BaseViewModel
    {
        #region public properties

        /// <summary>
        /// Gets or sets the repository items.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public ObservableCollection<RepositoryItem> Repository { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="RepositoryListViewModel"/> class.
        /// </summary>
        public RepositoryListViewModel()
        {
            // Populate list on object construction time.
            Repository = GetRepositories();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Gets the repository items.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<RepositoryItem> GetRepositories()
        {
            // Empty container to populate and return.
            var items = new ObservableCollection<RepositoryItem>();

            // Load exsisting preferences from serialized file.
            var prefs = Preferences.Load();

            // Loads data from file.
            foreach (var path in prefs.Repository)
            {
                var repository = new RepositoryItem
                {
                    FullPath = path,
                };
                items.Add(repository);
            }

            return items;
        }

        #endregion
    }
}
