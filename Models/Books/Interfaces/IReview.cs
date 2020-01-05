using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Books.Interfaces
{
    public interface IReview
    {
        int Id { get; set; }
        string ISBN { get; set; }
        IUser User { get; set; }
        string Rating { get; set; }
        string Content { get; set; }
    }
}
