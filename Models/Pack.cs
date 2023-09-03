namespace Models
{
    /// <summary>
    /// Pack information
    /// </summary>
    public struct Pack
    {
        /// <summary>
        /// Incremental ID of the pack in the database
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// UUIDv4 for referencing the pack
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// UUIDv4 of the user who owns this pack
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// Title of the pack
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Description of the pack
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The creation date of the pack in Unix Epoch
        /// </summary>
        public long creation { get; set; }

        /// <summary>
        /// The last update date of the pack in Unix Epoch
        /// </summary>
        public long updated { get; set; }

        /// <summary>
        /// Stats of the pack, downloads, views, etc.
        /// </summary>
        public Stats stats { get; set; }
    }
}
