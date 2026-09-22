using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BookDataAccess dataAccess = new BookDataAccess();

        while (true)
        {
            Console.WriteLine("\n===== BOOK MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Find Book by ID");
            Console.WriteLine("4. Create Backup");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter Book ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(id, title, author, price);

                dataAccess.AddBook(book);

                Console.WriteLine("Book added successfully.");
            }

            else if (choice == 2)
            {
                List<Book> books = dataAccess.GetAllBooks();

                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                }
                else
                {
                    foreach (Book book in books)
                    {
                        book.DisplayInfo();
                    }
                }
            }

            else if (choice == 3)
            {
                Console.Write("Enter Book ID: ");
                int id = int.Parse(Console.ReadLine());

                Book book = dataAccess.FindBook(id);

                if (book != null)
                {
                    book.DisplayInfo();
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            else if (choice == 4)
            {
                dataAccess.CreateBackup();
            }

            else if (choice == 5)
            {
                Console.WriteLine("Program ended.");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}