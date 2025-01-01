
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreLibrary
{
    public class Book : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }
        public string ISBN { get; }

        public Book(string title, string author, double price, string isbn)
        {
            Title = title;
            Author = author;
            Price = price;
            ISBN = isbn;
        }
    }
}
