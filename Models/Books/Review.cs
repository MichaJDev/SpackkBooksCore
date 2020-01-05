using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Books
{
    class Review
    {
        public int Id { get; set; }
        public IUser User { get; set; }
        public string ISBN { get; set; }
        public string Content { get; set; }
        public string Rating { get; set; }
    }
}
