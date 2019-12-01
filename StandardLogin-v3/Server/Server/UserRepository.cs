using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UserRepository
    {
        // Must contain dynamic data structures
        // LinkedList which stores User objects
        LinkedList<User> users = new LinkedList<User>();

        // Method to add the user in memory dummy db
        public void AddUser(User user)
        {
            if (users.First == null)
                users.AddFirst(user);
            else
                users.AddAfter(users.Last, user);
        }

        public LinkedList<User> GetUsers()
        {
            return users;
        }

        // Method to retrieve the user based on the UserId
        public List<int> GetUserIds()
        {
            List<int> userIds = new List<int>();
            foreach (User u in users)
                userIds.Add(u.UserId);
            return userIds;
        }

        // Method to get a User by userId
        public User GetUser(int userid)
        {
            return users.Single(u => u.UserId == userid);
        }

        // Method to check if a User's UserId
        public bool UserExists(int userid)
        {
            try
            {
                // (users.Single(u => u.UserId == userid)
                if (users.Any(cus => cus.UserId == userid))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
