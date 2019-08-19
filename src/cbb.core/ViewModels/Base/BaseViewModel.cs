namespace cbb.core
{
    using System.ComponentModel;

    /// <summary>
    /// A base view model functionality for all view models.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region public methods

        /// <summary>
        /// Call this method to raise <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">The name.</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
