// <copyright file="SaltGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    using System.Security.Cryptography;

    /// <summary>
    /// Class to generate a salt.
    /// </summary>
    internal class SaltGenerator
    {
        private const int SALTSIZE = 24;
        private static RNGCryptoServiceProvider cryptoServiceProvider = null;

        static SaltGenerator()
        {
            cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        /// <summary>
        /// Method to get a salt.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string GetSaltString()
        {
            // create a byte array tostore the salt bytes
            byte[] saltBytes = new byte[SALTSIZE];

            // generate the salt in the byte array
            cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            // get string representation for this salt
            string saltString = Utility.GetString(saltBytes);

            // returnt the saltString
            return saltString;
        }
    }
}
