using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs.Interfaces
{
    public interface IBlogComment
    {
        int Id { get; set; }
        IBlogPost BlogPost { get; set; }
        IUser User { get; set; }
        String Content { get; set; }
        int Likes { get; set; }
        IEnumerable<IUser> LikedBy { get; set; }
    }
}
