﻿using Models.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public IEnumerable<IReview> Reviews { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
