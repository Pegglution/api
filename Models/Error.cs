using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// Error response structure on API request failure
    /// </summary>
    public struct Error
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string msg { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Error(string msg) { this.msg = msg; }
    }
}