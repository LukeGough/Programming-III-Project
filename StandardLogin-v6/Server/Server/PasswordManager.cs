// <copyright file="PasswordManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    /// <summary>
    /// Class is used to create a Password Manager.
    /// </summary>
    internal class PasswordManager
    {
        private HashComputer hashComputer = new HashComputer();

        /// <summary>
        /// Method to generate a Password Hash.
        /// </summary>
        /// <param name="plainTextPassword">Variable which passes through the  plain text password.</param>
        /// <param name="salt">Variable which passes through the  salt.</param>
        /// <returns>Returns a string.</returns>
        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return this.hashComputer.GetPasswordHashAndSalt(finalString);
        }

        /// <summary>
        /// Method to get if Passwords match.
        /// </summary>
        /// <param name="password">Variable which passes through the Password.</param>
        /// <param name="salt">Variable which passes through the Salt.</param>
        /// <param name="hash">Variable which passes through the Password hash.</param>
        /// <returns>Returns a Boolean.</returns>
        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == this.hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }
}
