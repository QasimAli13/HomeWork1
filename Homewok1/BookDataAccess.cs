using System;
using System.Collections.Generic;
using System.IO;

class BookDataAccess
{
    string fileName = "books.txt";

    public void AddBook(Book book)
    {
        FileStream fs = new FileStream(fileName, FileMode.Append);
        StreamWriter writer = new StreamWriter(fs);

        writer.WriteLine(
            book.Id + ", " +
            book.Title + ", " +
            book.Author + ", " +
            book.Price
        );

        writer.Close();
        fs.Close();
    }

    public List<Book> GetAllBooks()
    {
        List<Book> books = new List<Book>();

        if (!File.Exists(fileName))
        {
            return books;
        }

        FileStream fs = new FileStream(fileName, FileMode.Open);
        StreamReader reader = new StreamReader(fs);

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] data = line.Split(',');

            int id = int.Parse(data[0].Trim());
            string title = data[1].Trim();
            string author = data[2].Trim();
            double price = double.Parse(data[3].Trim());

            Book book = new Book(id, title, author, price);

            books.Add(book);
        }

        reader.Close();
        fs.Close();

        return books;
    }

    public Book FindBook(int id)
    {
        List<Book> books = GetAllBooks();

        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }

        return null;
    }

    public void CreateBackup()
    {
        FileStream source = new FileStream(
            fileName,
            FileMode.Open
        );

        FileStream destination = new FileStream(
            "books_backup.txt",
            FileMode.Create
        );

        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = source.Read(
            buffer,
            0,
            buffer.Length
        )) > 0)
        {
            destination.Write(
                buffer,
                0,
                bytesRead
            );
        }

        source.Close();
        destination.Close();

        Console.WriteLine("Backup created successfully.");
    }
}