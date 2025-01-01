using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary
{
    public class Customer
    {
        public string Name { get; }
        public string Email { get; }
        public string Address { get; }

        public Customer(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
        }
    }
}
