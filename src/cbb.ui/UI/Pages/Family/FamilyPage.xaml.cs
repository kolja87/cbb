namespace cbb.ui
{
    /// <summary>
    /// Interaction logic for FamilyPage.xaml
    /// </summary>
    /// <seealso cref="cbb.ui.BasePage" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class FamilyPage : BasePage
    {
        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyPage"/> class.
        /// </summary>
        public FamilyPage()
        {
            InitializeComponent();

            Animation = PageAnimationType.Fade;
        }

        #endregion
    }
}
