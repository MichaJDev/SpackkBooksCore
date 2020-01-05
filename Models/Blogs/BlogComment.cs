using Models.Blogs.Interfaces;
using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs
{
    public class BlogComment
    {
        public int Id { get; set; }
        public IUser User { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public IEnumerable<IUser> LikedBy { get; set; }
        public IBlogPost BlogPost { get; set; }
    }
}
