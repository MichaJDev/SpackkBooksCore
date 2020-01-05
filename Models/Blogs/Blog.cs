using Models.Blogs.Interfaces;
using Models.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs
{
    public class Blog
    {
        public int Id { get; set; }
        public IUser User { get; set; }
        public IEnumerable<IBlogPost> BlogPosts { get; set; }
    }
}
