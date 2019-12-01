// <copyright file="HashComputer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    using System.Security.Cryptography;

    /// <summary>
    /// Class is used to create a HashComputer.
    /// </summary>
    internal class HashComputer
    {
        // Must contain hashing techniques

        /// <summary>
        /// Method is used to Hash and Salt passwords.
        /// </summary>
        /// <param name="message">Variable which passess through the user input.</param>
        /// <returns>Returns a string which has been hashed.</returns>
        public string GetPasswordHashAndSalt(string message)
        {
            // use SHA256 algorithm to generate the hash from this salted password
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return Utility.GetString(resultBytes);
        }
    }
}
