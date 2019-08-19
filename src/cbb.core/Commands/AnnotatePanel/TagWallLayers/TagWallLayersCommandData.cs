namespace cbb.core
{
    using Autodesk.Revit.DB;

    /// <summary>
    /// Information and data model for command <see cref="TagWallLayersCommand"/> to execute.
    /// </summary>
    public class TagWallLayersCommandData
    {
        #region public properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TagWallLayersCommandData"/> should display layer function information.
        /// </summary>
        /// <value>
        ///   <c>true</c> if function; otherwise, <c>false</c>.
        /// </value>
        public bool Function { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TagWallLayersCommandData"/> should display layer name;
        /// </summary>
        /// <value>
        ///   <c>true</c> if name; otherwise, <c>false</c>.
        /// </value>
        public bool Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TagWallLayersCommandData"/> should display layer thickness information.
        /// </summary>
        /// <value>
        ///   <c>true</c> if thickness; otherwise, <c>false</c>.
        /// </value>
        public bool Thickness { get; set; }

        /// <summary>
        /// Gets or sets the text type identifier <see cref="ElementId"/>.
        /// </summary>
        /// <value>
        /// The text type identifier.
        /// </value>
        public ElementId TextTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit to convert to.
        /// </summary>
        /// <value>
        /// The type of the unit.
        /// </value>
        public LengthUnitType UnitType { get; set; }

        /// <summary>
        /// Gets or sets the decimal places precision.
        /// </summary>
        /// <value>
        /// The decimals.
        /// </value>
        public int Decimals { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="TagWallLayersCommandData"/> class.
        /// </summary>
        public TagWallLayersCommandData()
        {

        }

        #endregion
    }
}
