namespace cbb.ui
{
    using System.Windows;

    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;

    using core;

    /// <summary>
    /// Register Family Manager in zero state document.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand" />
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class RegisterFamilyManagerCommand : IExternalCommand
    {
        #region public methods

        /// <summary>
        /// Executes the specified command data.
        /// </summary>
        /// <param name="commandData">The command data.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Execute(commandData.Application);
        }

        /// <summary>
        /// Register dockable pane.
        /// </summary>
        /// <param name="uIApplication">The u i application.</param>
        /// <returns></returns>
        public Result Execute(UIApplication uIApplication)
        {
            var data = new DockablePaneProviderData();
            var managerPage = new FamilyManagerMainPage();

            data.FrameworkElement = managerPage as FrameworkElement;

            // Setup initial state.
            var state = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
            };

            // Use unique guid identifier for this dockable pane.
            var dpid = new DockablePaneId(PaneIdentifiers.GetManagerPaneIdentifier());
            // Register pane.
            uIApplication.RegisterDockablePane(dpid, "Family Manager", managerPage as IDockablePaneProvider);

            return Result.Succeeded;
        }

        #endregion
    }
}
