namespace cbb.core
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RouteCommands : ICommand
    {
        #region private memebers

        /// <summary>
        /// The action to execute.
        /// </summary>
        private Action mAction = null;

        #endregion

        #region events

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="RouteCommands"/> class.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public RouteCommands(Action action)
        {
            mAction = action;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns>
        ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
