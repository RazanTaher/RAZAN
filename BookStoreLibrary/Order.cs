using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public class Order
    {
        public Customer Customer { get; }
        public List<IBook> Books { get; }
        public double TotalPrice => CalculateTotalPrice();
        public DateTime OrderDate { get; }
        public Order(Customer customer, List<IBook> books)
        {
            Customer = customer;
            Books = books;
            OrderDate = DateTime.Now;
        }

        private double CalculateTotalPrice()
        {
            double total = 0;
            foreach (var book in Books)
            {
                total += book.Price;
            }
            return total;
        }
    }
}
