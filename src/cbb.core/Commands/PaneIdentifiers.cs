namespace cbb.core
{
    using System;

    /// <summary>
    /// Guid container that holds guid references to dockable panes.
    /// </summary>
    public static class PaneIdentifiers
    {
        #region public methods

        /// <summary>
        /// The family manager dockable pane identifier.
        /// </summary>
        /// <returns></returns>
        public static Guid GetManagerPaneIdentifier()
        {
            return new Guid("E839010B-35C6-47AA-A9FD-B4597AA00229");
        }

        #endregion
    }
}
