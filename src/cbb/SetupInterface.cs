namespace cbb
{
    using Autodesk.Revit.UI;

    using ui;
    using core;

    /// <summary>
    /// Setup whole plugins interface with tabs, panels, buttons,...
    /// </summary>
    public class SetupInterface
    {
        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="SetupInterface"/> class.
        /// </summary>
        public SetupInterface()
        {

        }

        #endregion

        #region public methods

        /// <summary>
        /// Initializes all interface elements on custom created Revit tab.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Initialize(UIControlledApplication app)
        {
            // Create ribbon tab.
            string tabName = "Circle's Bim Blog";
            app.CreateRibbonTab(tabName);

            // Create the ribbon panels.
            var annotateCommandsPanel =  app.CreateRibbonPanel(tabName, "Annotation Commands");
            var managerCommandsPanel = app.CreateRibbonPanel(tabName, "Family Manager Commands");

            #region annotate

            // Populate button data model.
            var TagWallButtonData = new RevitPushButtonDataModel
            {
                Label = "Tag Wall\nLayers",
                Panel = annotateCommandsPanel,
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                CommandNamespacePath = TagWallLayersCommand.GetPath(),
                IconImageName = "icon_TagWallLayers_32x32.png",
                TooltipImageName = "tooltip_TagWallLayers_320x320.png"
            };

            // Create button from provided data.
            var TagWallButton = RevitPushButton.Create(TagWallButtonData);

            #endregion

            #region manager

            var familyManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = "Show Family\nManager",
                Panel = managerCommandsPanel,
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                CommandNamespacePath = ShowFamilyManagerCommand.GetPath(),
                IconImageName = "icon_ShowFamilyManager_32x32.png",
                TooltipImageName = "tooltip_ShowFamilyManager_320x320.png"
            };
            var familyManagerShowButton = RevitPushButton.Create(familyManagerShowButtonData);

            var familyManagerHideButtonData = new RevitPushButtonDataModel
            {
                Label = "Hide Family\nManager",
                Panel = managerCommandsPanel,
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                CommandNamespacePath = HideFamilyManagerCommand.GetPath(),
                IconImageName = "icon_HideFamilyManager_32x32.png",
                TooltipImageName = "tooltip_HideFamilyManager_320x320.png"
            };
            var familyManagerHideButton = RevitPushButton.Create(familyManagerHideButtonData);

            #endregion
        }

        #endregion
    }
}
