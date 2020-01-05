using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Books.Interfaces
{
    public interface IBook
    {
        int Id { get; set; }
        string Title { get; set; }
        string ISBN { get; set; }
        string Author { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        IEnumerable<IReview> Reviews { get; set; }
    }
}
