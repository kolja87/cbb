namespace cbb.core
{
    /// <summary>
    /// Conteiner class that contains functions for getting file type for Family Manager application.
    /// </summary>
    public static class ItemTypeHelper
    {
        #region public methods

        /// <summary>
        /// Gets the type of the item based on the full path to the file.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        public static ItemType GetType(string fullPath)
        {
            // check if provided full path is valid.
            if (string.IsNullOrEmpty(fullPath))
                return ItemType.None;

            // Determine item type.
            if (fullPath.Contains(".rvt") || fullPath.Contains(".rte"))
                return ItemType.Project;
            else if (fullPath.Contains(".rfa") || fullPath.Contains(".rft"))
                return ItemType.Family;
            else if (fullPath.Contains(".dwg") || fullPath.Contains(".dxf") || fullPath.Contains(".sat"))
                return ItemType.Cad;
            else if (fullPath.Contains(".doc") || fullPath.Contains(".docx") || fullPath.Contains(".pdf") || fullPath.Contains(".txt") || fullPath.Contains(".csv"))
                return ItemType.Document;
            else
                return ItemType.None;
        }

        #endregion
    }
}
