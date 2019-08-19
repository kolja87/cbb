namespace cbb.core
{
    using System.Windows.Input;

    /// <summary>
    /// A view model for the main application page.
    /// </summary>
    /// <seealso cref="cbb.core.BaseViewModel" />
    public class FamilyManagerMainPageViewModel : BaseViewModel
    {
        #region public properties

        /// <summary>
        /// Gets or sets the current page of the application.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public ApplicationPageType CurrentPage { get; set; } = ApplicationPageType.Family;

        #endregion

        #region commands

        /// <summary>
        /// Gets or sets the family page as current.
        /// </summary>
        /// <value>
        /// The family BTN command.
        /// </value>
        public ICommand FamilyBtnCommand { get; set; }

        /// <summary>
        /// Gets or sets the preferences page as current.
        /// </summary>
        /// <value>
        /// The preferences BTN command.
        /// </value>
        public ICommand PreferencesBtnCommand { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyManagerMainPageViewModel"/> class.
        /// </summary>
        public FamilyManagerMainPageViewModel()
        {
            // Application page switch commands and actions.
            FamilyBtnCommand = new RouteCommands(() => CurrentPage = ApplicationPageType.Family);
            PreferencesBtnCommand = new RouteCommands(() => CurrentPage = ApplicationPageType.Preferences);
        }

        #endregion
    }
}
