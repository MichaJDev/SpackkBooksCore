
using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace spackkBooksCore.Models.Users
{
    public class UserViewModel : IUser
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
