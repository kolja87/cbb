namespace cbb.core
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    /// <summary>
    /// Selection filter based on the user provided category name.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.Selection.ISelectionFilter" />
    public class SelectionFilterByCategory : ISelectionFilter
    {
        #region private members

        // Private variable that holds category name.
        private string mCategory = "";

        #endregion

        #region constructor

        /// <summary>
        /// default constrauctor.
        /// Initializes a new instance of the <see cref="SelectionFilterByCategory"/> class.
        /// </summary>
        /// <param name="category">The category of element, suche as Walls, Floors,...</param>
        public SelectionFilterByCategory(string category)
        {
            mCategory = category;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Allows the element selection if provided category is equal to selected one.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AllowElement(Element element)
        {
            // Check if category matches.
            if (element.Category.Name == mCategory)
                return true;

            return false;
        }

        /// <summary>
        /// Allows the reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }

        #endregion
    }
}
