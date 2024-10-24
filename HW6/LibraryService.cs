
using System.Reflection.Metadata;

namespace HW6;

public class LibraryService : ILibraryService
{
    public bool BorrowBook(int bookid, int userid)
    {
        foreach (var item in Storage.books)
        {
            if (bookid == item.Id && item.IsBorrowed == false)
            {
                item.IsBorrowed = true;
                item.UserId = userid;
                item.BorrowDate = DateTime.Now;
                foreach (var user in Storage.users)
                {
                    if (user.Id == userid)
                    {
                        user.book.Add(item);
                        Console.WriteLine($"Book '{item.Book_name}' borrowed by {user.UserName}.");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool ReturnBook(int bookid, int userid)
    {
        foreach (var item in Storage.books)
        {
            if (bookid == item.Id)
            {
                item.IsBorrowed = false;
                item.UserId = 0;
                break;
            }
            else
            {
                return false;
            }
        }

        foreach (var u in Storage.users)
        {
            if (u.Id == userid)
            {
                for (int i = 0; i < u.book.Count; i++)
                {
                    if (u.book[i].Id == bookid)
                    {
                        u.book.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        return true;
    }

    public void GetListOfLibraryBooks()
    {
        foreach (var item in Storage.books)
        {
            if (!item.IsBorrowed)
            {
                Console.WriteLine($"{item.Id} = {item.Book_name}, Author = {item.Author}, Price = {item.Price}");
            }
        }
    }

    public void GetListOfUserBooks(int userid)
    {
        foreach (var u in Storage.users)
        {
            if (userid == u.Id)
            {
                foreach (var b in u.book)
                {
                    Console.WriteLine($"{b.Id} = {b.Book_name}, Author = {b.Author}, Price = {b.Price}, Borrowed on: {b.BorrowDate}");
                }
            }
        }
    }
    public void AddBook ()
    {
        Console.Write("Enter Book Name : ");
        string name = Console.ReadLine();
        Console.Write("Enter Author : ");
        string author = Console.ReadLine();
        Console.Write("Enter Book Price : ");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Select book genre: 0.Scientific 1.Cultural 2.Sports 3.Specialized");
        int genrech = int.Parse(Console.ReadLine());
        EnumGenre genre = (EnumGenre)genrech;

        Books newBook = new Books
        {
            Id = Storage.books.Count + 1,
            Book_name = name,
            Author = author,
            Price = price,
            IsBorrowed = false,
            Genre = genre
        };

        Storage.books.Add(newBook);
        Console.WriteLine("Book added!.");
    }

    public bool SearchBook()
    {
        Console.Write("Enter Book Name : ");
        string search = Console.ReadLine();
        foreach (var s in Storage.books)
        {
            if (s.Book_name.Contains(search))
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Book_name}, Author: {s.Author}, Price: {s.Price}, Genre: {s.Genre}");
                return true;
            }
        }
        return false;
       
    }

    public void GetListOfBorrowedBooks()
    {
        bool borrow = false;
        foreach (var item in Storage.users)
        {
            if (item.book is null)
            {
                continue;
            }

            else
            {
                borrow = true;
                foreach (var b in item.book)
                {
                    Console.WriteLine($"User ({item.UserName}) Borrowed Book {b.Book_name}");
                }
            }

        }
        if (borrow == false)
        {
            Console.WriteLine("Dont have borrowed books!!!");
        }
    }

    public void ShowAllBooks()
    {
        foreach (var item in Storage.books)
        { 
                Console.WriteLine($"{item.Id} = {item.Book_name}, Author = {item.Author}, Price = {item.Price}");
        }
    }

}
