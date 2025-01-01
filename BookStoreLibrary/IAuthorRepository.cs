using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        Author GetAuthorById(int id);
        List<Author> GetAllAuthors();
    }
}