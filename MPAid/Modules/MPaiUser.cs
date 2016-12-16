using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    /// <summary>
    /// Class representing a user in the MPAi system.
    /// </summary>
    public class MPAiUser
    {
        private string userName;
        private string passWord;
        private readonly string adminStr = "admin";
        /// <summary>
        /// Wrapper property for the user's username, allowing access from outside the class.
        /// </summary>
        [DisplayName("UserName")]
        public string UserID
        {
            get { return userName; }
            set
            {
                // prevent the user from changing the name of the admin
                if (userName != adminStr)
                {
                    userName = value;
                }
            }
        }
        /// <summary>
        /// Wrapper property for the user's password, allowing access outside of the class.
        /// </summary>
        [DisplayName("Password")]
        public string UserPswd
        {
            get { return passWord; }
            set { passWord = value; }
        }
        /// <summary>
        /// Wrapper property for the administrator status of the user, allowing it to be checked from outside the class.
        /// </summary>
        [DisplayName("IsAdministrator")]
        public bool IsAdmin
        {
            get { return isAdmin(); }
        }
        /// <summary>
        /// Constructor for the MPAiUser class.
        /// </summary>
        /// <param name="name">The new user's username</param>
        /// <param name="code">The new user's password</param>
        public MPAiUser(string name, string code)
        {
            userName = name;
            passWord = code;
        }
        /// <summary>
        /// Checks if the input string matches this user's password. Case sensitive.
        /// </summary>
        /// <param name="code">The string to check against the password.</param>
        /// <returns>True if the password is correct, false otherwise.</returns>
        public bool codeCorrect(string code)
        {
            return (code.Equals(passWord));
        }
        /// <summary>
        /// Checks if the username of the user matches that of the admin, returning whether or not they are the same person.
        /// </summary>
        /// <returns>True if the user is the administrator, false otherwise.</returns>
        public bool isAdmin()
        {
            return (getName() == adminStr);
        }
        /// <summary>
        /// Getter for username, Not case senstive.
        /// </summary>
        /// <returns>The lower-case username, as a string.</returns>
        public string getName()
        {
            return userName.ToLower();
        }
        /// <summary>
        /// Getter for password. Case Senstive.
        /// </summary>
        /// <returns>The password, as a string.</returns>
        public string getCode()
        {
            return passWord;
        }
        /// <summary>
        /// Override for equals().
        /// Two users with the same username are considered the same user.
        /// </summary>
        /// <param name="obj">The object to be compared to the current user.</param>
        /// <returns>True if the user and the object are the same thing, false otherwise.</returns>
        public override bool Equals(System.Object obj)
        {
            if (obj is MPAiUser)
            {
                MPAiUser otherUser = (MPAiUser)obj;
                if (userName == null || passWord == null)
                {
                    return false;
                }
                return (getName() == otherUser.getName());
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Override for GetHashCode(). Functions the same.
        /// </summary>
        /// <returns>The hashcode for this object, as an int.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Override for ToString(), returning the username - this should be unique for each user.
        /// </summary>
        /// <returns>The username, as a string.</returns>
        public override string ToString()
        {
            return userName;
        }
    }
}
