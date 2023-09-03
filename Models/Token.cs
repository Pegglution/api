using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// API token attached to a user
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Token
    {
        /// <summary>
        /// The UUIDv4 of the token
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// The creation date of the token in Unix Epoch
        /// </summary>
        public long creation { get; set; }

        /// <summary>
        /// The expiration date of the token in Unix Epoch
        /// </summary>
        public long expiration { get; set; }
    }
}
