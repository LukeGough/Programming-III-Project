// <copyright file="CSVRecord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    /// <summary>
    /// Class is used to create a CSV Record.
    /// </summary>
    internal class CSVRecord
    {
        /// <summary>
        /// Gets or sets UserID.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets PasswordHash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets Salt.
        /// </summary>
        public string Salt { get; set; }
    }
}