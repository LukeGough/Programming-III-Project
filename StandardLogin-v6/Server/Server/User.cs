// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    /// <summary>
    /// Class that represents a User.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the PasswordHash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the Salt.
        /// </summary>
        public string Salt { get; set; }
    }
}
