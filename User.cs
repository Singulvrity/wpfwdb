using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfwdb
{
    public class User
    {
        //any cols you want in the db
   
        public int UserId { get; set; }
        public  string Username { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }

        // default ctor
        

        public User(int userId, string username, string password, string email)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
        }
        //For the profile
        public string toString()
        {
            return $"{UserId},{Username},{Password}";
        }
    }
}
