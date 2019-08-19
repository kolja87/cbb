namespace cbb.ui
{
    using System.Windows.Controls;

    using core;

    /// <summary>
    /// Interaction logic for FamilyListControl.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class FamilyListControl : UserControl
    {
        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyListControl"/> class.
        /// </summary>
        public FamilyListControl()
        {
            InitializeComponent();

            // List model binded to data context.
            DataContext = new FamilyListViewModel();
        }

        #endregion
    }
}
