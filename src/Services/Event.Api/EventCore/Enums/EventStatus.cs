namespace EventCore.Enums
{
    /// <summary>
    /// Enumeration representing the status of a event property.
    /// </summary>
    public enum EventStatus
    {
        /// <summary>
        /// The property is active and available.
        /// </summary>
        Active,

        /// <summary>
        /// The property is deactive and available.
        /// </summary>
        Deactive,

        /// <summary>
        /// The property has been archived and is not active.
        /// </summary>
        Archived,

        /// <summary>
        /// The property listing has expired.
        /// </summary>
        Expired
    }
}