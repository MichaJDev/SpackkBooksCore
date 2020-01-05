using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs.Interfaces
{
    class IBlog
    {
        int Id { get; set; }
        IUser User { get; set; }
        IEnumerable<IBlogPost> BlogPosts { get; set; }
    }
}
