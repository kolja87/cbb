namespace cbb.ui
{
    using System.Windows.Controls;

    using core;

    /// <summary>
    /// Interaction logic for RepositoryListControl.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class RepositoryListControl : UserControl
    {
        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="RepositoryListControl"/> class.
        /// </summary>
        public RepositoryListControl()
        {
            InitializeComponent();

            DataContext = new RepositoryListViewModel();
        }

        #endregion
    }
}
