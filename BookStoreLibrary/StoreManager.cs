using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public class StoreManager : IStoreManager
    {
        private List<IBook> _books = new List<IBook>();
        private List<Customer> _customers = new List<Customer>();
        private List<Order> _orders = new List<Order>();

        public void AddBook(IBook book)
        {
            _books.Add(book);
        }
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<IBook> GetAllBooks()
        {
            return _books;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
        public void PlaceOrder(Customer customer, List<IBook> books)
        {
            Order order = new Order(customer, books);
            _orders.Add(order);
        }
    }
}
