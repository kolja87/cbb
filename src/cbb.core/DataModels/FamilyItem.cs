namespace cbb.core
{
    /// <summary>
    /// Represents a data model for one single family item in list of the items.
    /// </summary>
    public class FamilyItem
    {
        #region public properties

        /// <summary>
        /// Gets or sets the full path to the item.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath { get; set; }

        /// <summary>
        /// Gets the name of the family item based on full path.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => PathHelpers.GetFileName(FullPath);

        /// <summary>
        /// Gets the type of item based on the full path to file.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public ItemType Type => ItemTypeHelper.GetType(FullPath);

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyItem"/> class.
        /// </summary>
        public FamilyItem()
        {

        }

        #endregion
    }
}
