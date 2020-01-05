using Models.Blogs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs
{
    public class BlogPost
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public IEnumerable<IBlogComment> Comments { get; set; }
    }
}
