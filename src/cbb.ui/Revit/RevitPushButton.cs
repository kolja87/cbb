namespace cbb.ui
{
    using System;

    using Autodesk.Revit.UI;

    using res;
    using core;

    /// <summary>
    /// The Revit push button methods.
    /// </summary>
    public static class RevitPushButton
    {
        #region public methods

        /// <summary>
        /// Creates the push button based on data provided in <see cref="RevitPushButtonDataModel"/>.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static PushButton Create(RevitPushButtonDataModel data)
        {
            // The button name based on unique identifier.
            var btnDataName = Guid.NewGuid().ToString();

            // Sets the button data.
            var btnData = new PushButtonData(btnDataName, data.Label, CoreAssembly.GetAssemblyLocation(), data.CommandNamespacePath)
            {
                ToolTip = data.Tooltip,
                LargeImage = ResourceImage.GetIcon(data.IconImageName),
                ToolTipImage = ResourceImage.GetIcon(data.TooltipImageName)
            };

            // Return created button and host it on panel provided in required data model.
            return data.Panel.AddItem(btnData) as PushButton;
        }

        #endregion
    }
}
