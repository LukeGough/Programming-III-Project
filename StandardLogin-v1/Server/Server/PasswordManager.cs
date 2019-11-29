using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class PasswordManager
    {
        HashComputer m_HashComputer = new HashComputer();

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return m_HashComputer.GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == m_HashComputer.GetPasswordHashAndSalt(finalString);
        }
    }
}
