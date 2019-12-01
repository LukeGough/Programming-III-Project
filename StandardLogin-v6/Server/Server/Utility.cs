// <copyright file="Utility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    /// <summary>
    /// Class that represents Utility.
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Method to convert string to byte[].
        /// </summary>
        /// <param name="str">Variable which passes through the string.</param>
        /// <returns>Returns a array of btyes.</returns>
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Method to convert byte[] to string.
        /// </summary>
        /// <param name="bytes">Variable which passes through the array of bytes.</param>
        /// <returns>Returns a string.</returns>
        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
