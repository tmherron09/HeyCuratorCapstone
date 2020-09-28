using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Hubs
{
    public static class ChatManager
    {

        public static Dictionary<string, string> UsersLoggedIn = new Dictionary<string, string>();
        public static List<string> UserCheckedIn = new List<string>();


        public static void AddUser(string userName, string connectionId)
        {
            if(userName == null || userName.Length == 0)
            {
                throw new Exception("Invalid User.");
            }

            if(!UsersLoggedIn.ContainsKey(userName))
            {
                UsersLoggedIn.Add(userName, connectionId);
            }
            else
            {
                UsersLoggedIn[userName] = connectionId;
            }

        }

        public static void RemoveConnection(string connectionId)
        {

            var user = UsersLoggedIn.Where(u => u.Key == connectionId).SingleOrDefault();
            UsersLoggedIn.Remove(user.Key);
        }

        /// <summary>
        /// Returns the ConnectId of the Employee userName (First name and last initial.
        /// </summary>
        /// <param name="username">Employee Username</param>
        /// <returns></returns>
        public static string GetUserConnection(string username)
        {
            var connectionId = UsersLoggedIn[username];
            return connectionId;
        }

        public static bool DidUserCheckIn(string username)
        {
            bool result = UserCheckedIn.Contains(username);
            if(result)
            {
                UserCheckedIn.Remove(username);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UserCheckingIn(string userName)
        {
            if (!UserCheckedIn.Contains(userName))
            {
                UserCheckedIn.Add(userName);
            }
        }

        public static string GetUserName(string connectionId)
        {
            var userName = UsersLoggedIn.Where(u=> u.Value == connectionId).Select(u=> u.Key).SingleOrDefault();
            return userName;
        }

        public static List<string> GetListOfUsers()
        {

            var keys = UsersLoggedIn.Keys.ToList();
            return keys;
        }


    }
}
