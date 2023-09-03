﻿using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// User information stored in the database
    /// </summary>
    public struct User
    {
        /// <summary>
        /// Incremental ID of the user in the database
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// UUIDv4 for referencing the user's account
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Password hash stored on the server (Not exposed)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string password { get; set; }

        /// <summary>
        /// The creation date of the user in Unix Epoch
        /// </summary>
        public long creation { get; set; }

        /// <summary>
        /// Last logged in IP address. Used for security reason on the server (Not exposed)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ip { get; set; }

        /// <summary>
        /// API tokens generated by the user for accessing the private portions of the API (Not exposed)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<Token> tokens { get; set; }
    }
}
