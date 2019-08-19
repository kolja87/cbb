namespace cbb.ui
{
    /// <summary>
    /// The page animation type.
    /// </summary>
    public enum PageAnimationType
    {
        /// <summary>
        /// No animation.
        /// </summary>
        None = 0,

        /// <summary>
        /// The fade animation absed on opacity property.
        /// </summary>
        Fade = 1,

        /// <summary>
        /// The slide animation absed on transform.
        /// </summary>
        Slide = 2,
    }
}
