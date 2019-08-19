namespace cbb.core
{
    /// <summary>
    /// Represents a type of suported file in family manager list view.
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// The Revit project.
        /// </summary>
        Project = 0,

        /// <summary>
        /// The Revit family.
        /// </summary>
        Family = 1,

        /// <summary>
        /// The cad file, such as .dwg, .dxf,...
        /// </summary>
        Cad = 2,

        /// <summary>
        /// The document file such as .doc, .docx, .pdf,...
        /// </summary>
        Document = 3,

        /// <summary>
        /// The no supported file type.
        /// </summary>
        None = 4,
    }
}
