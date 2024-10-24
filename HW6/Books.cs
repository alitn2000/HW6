
namespace HW6;

public class Books
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Book_name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public EnumGenre Genre { get; set; }
    public bool IsBorrowed { get; set; }

    public DateTime BorrowDate { get; set; }
}
