// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class that represents a User Repository.
    /// </summary>
    internal class UserRepository
    {
        // Must contain dynamic data structures
        // LinkedList which stores User objects
        private LinkedList<User> users = new LinkedList<User>();

        /// <summary>
        /// Method to add the user in memory dummy db.
        /// </summary>
        /// <param name="user">Variable which passes through the User.</param>
        public void AddUser(User user)
        {
            if (this.users.First == null)
            {
                this.users.AddFirst(user);
            }
            else
            {
                this.users.AddAfter(this.users.Last, user);
            }
        }

        /// <summary>
        /// Method to get the users.
        /// </summary>
        /// <returns>Returns a LinkedList of Users.</returns>
        public LinkedList<User> GetUsers()
        {
            return this.users;
        }

        /// <summary>
        /// Method to retrieve the user based on the UserId.
        /// </summary>
        /// <returns>Returns a List of Ints.</returns>
        public List<int> GetUserIds()
        {
            List<int> userIds = new List<int>();
            foreach (User u in this.users)
            {
                userIds.Add(u.UserId);
            }

            return userIds;
        }

        /// <summary>
        /// Method to get a User by userId.
        /// </summary>
        /// <param name="userid">Variable which passes through the userId.</param>
        /// <returns>Returns a User.</returns>
        public User GetUser(int userid)
        {
            return this.users.Single(u => u.UserId == userid);
        }

        /// <summary>
        /// Method to check if a User's UserId.
        /// </summary>
        /// <param name="userid">Variable which passes through the userId.</param>
        /// <returns>Returns a Boolean.</returns>
        public bool UserExists(int userid)
        {
            try
            {
                // (users.Single(u => u.UserId == userid)
                if (this.users.Any(cus => cus.UserId == userid))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
