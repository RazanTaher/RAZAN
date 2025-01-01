using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Interfaces
{
    
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBookById(int id);
        List<Book> GetAllBooks();
    }
}