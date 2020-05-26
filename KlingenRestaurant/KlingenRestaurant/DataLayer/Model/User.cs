using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KlingenRestaurant
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public User(){}

        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
            Role = UserRole.User;
        }

        public static string getHash(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return "Error";
            }
            else
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
