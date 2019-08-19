namespace cbb.ui
{
    using Autodesk.Revit.UI;

    /// <summary>
    /// Represents Revit push button data model.
    /// </summary>
    public class RevitPushButtonDataModel
    {
        #region public methods

        /// <summary>
        /// Gets or sets the label of the button.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the panel on which button is hosted.
        /// </summary>
        /// <value>
        /// The panel.
        /// </value>
        public RibbonPanel Panel { get; set; }

        /// <summary>
        /// Gets or sets the command namespace path.
        /// </summary>
        /// <value>
        /// The command namespace path.
        /// </value>
        public string CommandNamespacePath { get; set; }

        /// <summary>
        /// Gets or sets the tooltip.
        /// </summary>
        /// <value>
        /// The tooltip.
        /// </value>
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the name of the icon image.
        /// </summary>
        /// <value>
        /// The name of the icon image.
        /// </value>
        public string IconImageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the tooltip image.
        /// </summary>
        /// <value>
        /// The name of the tooltip image.
        /// </value>
        public string TooltipImageName { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="RevitPushButtonDataModel"/> class.
        /// </summary>
        public RevitPushButtonDataModel()
        {

        }

        #endregion
    }
}
