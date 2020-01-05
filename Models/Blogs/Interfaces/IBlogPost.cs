using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Blogs.Interfaces
{
    public interface IBlogPost
    {
        int Id { get; set; }
        int BlogId { get; set; }
        string Content { get; set; }
        IEnumerable<IBlogComment> Comments { get; set; }
    }
}
