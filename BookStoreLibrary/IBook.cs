using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        double Price { get; }
        string ISBN { get; }
    }
}
