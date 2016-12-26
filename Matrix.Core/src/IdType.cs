namespace Matrix.Core
{
    public enum IdType
    {
        /// <summary>
        /// Numeric Id's are generated by increasing a long value
        /// </summary>
        Numeric,

        /// <summary>
        /// Guid Id's are unique, Guid packet Id's should be used for server and component applications,
        /// or apps which very long sessions (multiple days, weeks or years)
        /// </summary>
        Guid
    }
}