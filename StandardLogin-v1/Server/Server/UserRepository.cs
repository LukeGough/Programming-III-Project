using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UserRepository
    {
        //List<User> users = new List<User>();
        LinkedList<User> users = new LinkedList<User>();

        // function to add the user in memory dummy db
        public void AddUser(User user)
        {
            users.AddLast(user);
        }

        public LinkedList<User> GetUsers()
        {
            return users;
        }

        // function to retrieve the user based on the user id
        public User GetUser(string userid)
        {
            return users.Single(u => u.UserId == userid);
        }

        // function to check if a User's UserId
        public bool UserExists(string userid)
        {
            try
            {
                // (users.Single(u => u.UserId == userid)
                if (users.Any(cus => cus.UserId == userid))
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
