namespace cbb.core
{
    using System.Text;
    using System.Windows.Forms;

    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    /// <summary>
    /// Command code to be executed when button is clicked.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand" />
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class TagWallLayersCommand : IExternalCommand
    {
        #region public methods

        /// <summary>
        /// Tag wall layers by creating text note element on user specified point and populate it with layer information.
        /// </summary>
        /// <param name="commandData">The command data.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Application context.
            var uidoc = commandData.Application.ActiveUIDocument;
            var doc = uidoc.Document;

            // Check if we are in the Revit project , not in family one.
            if (doc.IsFamilyDocument)
            {
                Message.Display("Can't use command in family document", WindowType.Warning);
                return Result.Cancelled;
            }

            // Get access to current view.
            var activeView = uidoc.ActiveView;

            // Check if Text Note can be created in currently active project view.
            bool canCreateTextNoteInView = false;
            switch (activeView.ViewType)
            {
                case ViewType.FloorPlan:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.CeilingPlan:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Detail:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Elevation:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Section:
                    canCreateTextNoteInView = true;
                    break;
            }

            // Collector for data provided in window.
            var userInfo = new TagWallLayersCommandData();

            if (!canCreateTextNoteInView)
            {
                Message.Display("Text Note element can't be created in the current view.", WindowType.Error);
                return Result.Cancelled;
            }

            // Get user provided information from window and show dialog.
            using (var window = new TagWallLayersForm(uidoc))
            {
                window.ShowDialog();

                if (window.DialogResult == DialogResult.Cancel)
                    return Result.Cancelled;

                userInfo = window.GetInformation();
            }

            // Ask user to select one basic wall.
            var selectionReference = uidoc.Selection.PickObject(ObjectType.Element, new SelectionFilterByCategory("Walls"), "Select one basic wall.");
            var selectionElement = doc.GetElement(selectionReference);

            // Cast generic element type to more specific Wall type.
            var wall = selectionElement as Wall;

            // Check if wall is type of basic wall.
            if (wall.IsStackedWall)
            {
                Message.Display("Wall you selected is category of the Stacked Wall.\nIt's not supported by this command.", WindowType.Warning);
                return Result.Cancelled;
            }

            // Access list of wall layers.
            var layers = wall.WallType.GetCompoundStructure().GetLayers();

            // Get layer information in structured string format for Text Note.
            var msg = new StringBuilder();

            foreach (var layer in layers)
            {
                var material = doc.GetElement(layer.MaterialId) as Material;

                msg.AppendLine();

                if (userInfo.Function)
                    msg.Append(layer.Function.ToString());

                // Check if material is attached to the layer in wall compound structure.
                if (userInfo.Name)
                {
                    if (material != null)
                        msg.Append(" " + material.Name);
                    else
                        msg.Append("  <by category>");
                }

                // Convert units to metric.
                // Revit by default uses imperial units.
                if (userInfo.Thickness)
                    msg.Append(" " + LengthUnitConverter.ConvertToMetric(layer.Width, userInfo.UnitType, userInfo.Decimals).ToString());
            }

            // Create Text Note options.
            var textNoteOptions = new TextNoteOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                TypeId = userInfo.TextTypeId
            };

            // Open Revit document transaction to create new Text Note element.
            using (var transaction = new Transaction(doc))
            {
                transaction.Start("Tag Wall Layers Command");

                var pt = new XYZ();

                // Construct sketch plane for user to pick point if we are in elevation or section view.
                if (activeView.ViewType == ViewType.Elevation || activeView.ViewType == ViewType.Section)
                {
                    var plane = Plane.CreateByNormalAndOrigin(activeView.ViewDirection, activeView.Origin);
                    var sketchPlane = SketchPlane.Create(doc, plane);
                    activeView.SketchPlane = sketchPlane;

                    // Ask user to pick location point for the Text Note Element
                    pt = uidoc.Selection.PickPoint("Pick text note location point");
                }
                else
                {
                    // Ask user to pick location point for the Text Note Element
                    pt = uidoc.Selection.PickPoint("Pick text note location point");
                }

                // Create Text Note with wall layers information on user specified point in the current active view.
                var textNote = TextNote.Create(doc, activeView.Id, pt, msg.ToString(), textNoteOptions);

                transaction.Commit();
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Gets the full namespace path to this command.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            // Return constructed namespace path.
            return typeof(TagWallLayersCommand).Namespace + "." + nameof(TagWallLayersCommand);
        }

        #endregion
    }
}
