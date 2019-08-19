namespace cbb.ui
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

    /// <summary>
    /// A base page to extend basic page functionality.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    public class BasePage : Page
    {
        #region public properties

        /// <summary>
        /// Gets or sets the animation type.
        /// </summary>
        /// <value>
        /// The animation.
        /// </value>
        public PageAnimationType Animation { get; set; } = PageAnimationType.Slide;

        /// <summary>
        /// Gets or sets the duration of the animation in seconds.
        /// </summary>
        /// <value>
        /// The duration of the animation.
        /// </value>
        public float AnimationDuration { get; set; } = 0.3f;

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        public BasePage()
        {
            // If there is animation then hide page to beggin animation.
            if (Animation != PageAnimationType.None)
                Visibility = Visibility.Collapsed;

            // Do animation on loadded event.
            Loaded += BasePage_Loaded;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Animates the page based on provided animation type.
        /// </summary>
        private void AnimatePage()
        {
            // If there is no animation just return and do nothing.
            if (Animation == PageAnimationType.None)
                return;
            // Fade animation based on the opacity property.
            else if (Animation == PageAnimationType.Fade)
            {
                // Define animation properties.
                var animation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(AnimationDuration * 2.5),
                    DecelerationRatio = 0.85f
                };
                // Do the animation.
                BeginAnimation(OpacityProperty, animation);
                Visibility = Visibility.Visible;
            }
            // Slide in animation based on transform.
            else
            {
                var storyBoard = new Storyboard();
                // Define animation properties.
                var animation = new ThicknessAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(AnimationDuration)),
                    From = new Thickness(640, 0, -640, 0),
                    To = new Thickness(0),
                    DecelerationRatio = 0.85f
                };
                // Do the animation.
                BeginAnimation(MarginProperty, animation);
                Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the BasePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimatePage();
        }

        #endregion
    }
}
