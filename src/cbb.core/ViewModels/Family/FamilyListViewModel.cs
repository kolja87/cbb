namespace cbb.core
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// A view model for list of the family items.
    /// </summary>
    /// <seealso cref="cbb.core.BaseViewModel" />
    public class FamilyListViewModel : BaseViewModel
    {
        #region public properties

        /// <summary>
        /// Gets or sets the items for the list view.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<FamilyItem> Items { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyListViewModel"/> class.
        /// </summary>
        public FamilyListViewModel()
        {
            // Populate Items list for list control.
            Items = Populate();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Populates the list with items from provided folder paths.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<FamilyItem> Populate()
        {
            var items = new ObservableCollection<FamilyItem>();

            // Loadpaths from saved preferences file.
            foreach (var path in Preferences.Load().Repository)
            {
                // Get family items from repository.
                var children = FamilyList.GetItems(path);

                // Add them to collection.
                foreach (var child in children)
                    items.Add(child);
            }

            return items;
        }

        #endregion
    }
}
