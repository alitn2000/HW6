
namespace HW6;

public interface ILibraryService
{
    public bool BorrowBook(int bookid, int userid);
    public bool ReturnBook(int bookid, int userid);
    public void GetListOfLibraryBooks();
    public void GetListOfUserBooks(int userid);
    public void AddBook();
    public bool SearchBook();
    public void GetListOfBorrowedBooks();
    public void ShowAllBooks();
}
