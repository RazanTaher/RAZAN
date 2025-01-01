using BookStoreLibrary;
using System;
using System.Collections.Generic;

namespace BookStoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStoreManager storeManager = new StoreManager();

            //Add some initial data
            storeManager.AddBook(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 10.99, "978-0345391803"));
            storeManager.AddBook(new Book("Pride and Prejudice", "Jane Austen", 8.50, "978-0141439518"));
            storeManager.AddCustomer(new Customer("Alice", "alice@example.com", "123 Main St"));


            while (true)
            {
                Console.WriteLine("\nBook Store Menu:");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. List Customers");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Add Customer");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListBooks(storeManager);
                        break;
                    case "2":
                        ListCustomers(storeManager);
                        break;
                    case "3":
                        PlaceOrder(storeManager);
                        break;
                    case "4":
                        AddBook(storeManager);
                        break;
                    case "5":
                        AddCustomer(storeManager);
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ListBooks(IStoreManager storeManager)
        {
            List<IBook> books = storeManager.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the store.");
            }
            else
            {
                Console.WriteLine("\nAvailable Books:");
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author} - ${books[i].Price}");
                }
            }
        }

        static void ListCustomers(IStoreManager storeManager)
        {
            List<Customer> customers = storeManager.GetAllCustomers();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers yet.");
            }
            else
            {
                Console.WriteLine("\nCustomers:");
                for (int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {customers[i].Name} ({customers[i].Email})");
                }
            }
        }

        static void PlaceOrder(IStoreManager storeManager)
        {
            ListCustomers(storeManager);
            Console.Write("Enter the number of the customer for this order: ");
            if (!int.TryParse(Console.ReadLine(), out int customerIndex) || customerIndex <= 0)
            {
                Console.WriteLine("Invalid customer number.");
                return;
            }
            List<Customer> customers = storeManager.GetAllCustomers();
            if (customerIndex > customers.Count)
            {
                Console.WriteLine("Invalid customer number.");
                return;
            }
            Customer selectedCustomer = customers[customerIndex - 1];

            ListBooks(storeManager);
            Console.Write("Enter the numbers of the books to order (comma separated): ");
            string bookIndicesInput = Console.ReadLine();
            List<int> bookIndices = new List<int>();
            if (!string.IsNullOrEmpty(bookIndicesInput))
            {
                string[] parts = bookIndicesInput.Split(',');
                foreach (var part in parts)
                {
                    if (int.TryParse(part.Trim(), out int index))
                    {
                        bookIndices.Add(index - 1);
                    }
                }
            }
            List<IBook> books = storeManager.GetAllBooks();
            List<IBook> selectedBooks = new List<IBook>();
            foreach (int index in bookIndices)
            {
                if (index >= 0 && index < books.Count)
                {
                    selectedBooks.Add(books[index]);
                }
                else
                {
                    Console.WriteLine($"Invalid book index: {index + 1}. Skipping.");
                }
            }

            if (selectedBooks.Count > 0)
            {
                storeManager.PlaceOrder(selectedCustomer, selectedBooks);
                Console.WriteLine("Order placed successfully.");
            }
            else
            {
                Console.WriteLine("No valid books selected for the order.");
            }
        }

        static void AddBook(IStoreManager storeManager)
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter book author: ");
            string author = Console.ReadLine();
            Console.Write("Enter book price: ");
             if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Invalid price format");
                return;
            }
            Console.Write("Enter book ISBN: ");
            string isbn = Console.ReadLine();
            storeManager.AddBook(new Book(title, author, price, isbn));
            Console.WriteLine("Book added successfully.");
        }

        static void AddCustomer(IStoreManager storeManager)
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter customer email: ");
            string email = Console.ReadLine();
            Console.Write("Enter customer address: ");
            string address = Console.ReadLine();
            storeManager.AddCustomer(new Customer(name, email, address));
            Console.WriteLine("Customer added successfully.");
        }
    }
}