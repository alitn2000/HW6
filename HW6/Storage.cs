
namespace HW6;

public static class Storage
{

    public static Admin CurrentAdmin { get; set; }
    public static User CurrentUser { get; set; }
    public static int UserCounter = 3;

    public static List<Books> books = new List<Books>
    {
        new Books
        {
            Id = 1,
            Book_name = "b1",
            Author = "a1",
            Price = 100.99M,
            Genre = EnumGenre.Scientific,
            IsBorrowed = false
        },

        new Books
        {
            Id = 2,
            Book_name = "b2",
            Author = "a2",
            Price = 11M,
            Genre = EnumGenre.Cultural,
            IsBorrowed = false
        },

        new Books
        {
            Id = 3,
            Book_name = "b3",
            Author = "a3",
            Price = 12M,
            Genre = EnumGenre.Sports,
            IsBorrowed = false
        }

    };

    public static List<User> users = new List<User>
    {

        new User
        {
            UserName = "reza01",
            Name = "reza",
            Family = "rezaei",
            Email = "reza01@gmail.com",
            Password = "123",
            Id = 1,
            Role = EnumRole.Member
        },

        new User
        {
            UserName = "morteza02",
            Name = "morteza",
            Family = "mortezaei",
            Email = "morteza02@gmail.com",
            Password = "124",
            Id = 2,
            Role = EnumRole.Member
        }

    };

    public static List<Admin> admins = new List<Admin>
    {
        new Admin
        {
            Admin_UserName = "admin",
            Admin_Password = "admin",
            Admin_Role = EnumRole.Admin,
        },

        new Admin
        {
            Admin_UserName = "a1",
            Admin_Password = "admin",
            Admin_Role = EnumRole.Admin,
        }
    };




}
