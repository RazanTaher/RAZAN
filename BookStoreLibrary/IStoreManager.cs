using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public interface IStoreManager
    {
        void AddBook(IBook book);
        void AddCustomer(Customer customer);
        List<IBook> GetAllBooks();
        List<Customer> GetAllCustomers();
        void PlaceOrder(Customer customer, List<IBook> books);
    }
}
