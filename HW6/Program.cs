using HW6;

IAuthentication authentication = new Authentication();
ILibraryService libraryService = new LibraryService();

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Library System!");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");
    Console.WriteLine("3. Exit");
    Console.Write("Please choose an option: ");

    string Choice = Console.ReadLine();

    if (Choice == "1") 
    {
        Console.Write("Please enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Please enter your password: ");
        string password = Console.ReadLine();

        if (authentication.Login(username, password))
        {
            Console.WriteLine("Login successful!");

            
            if (Storage.CurrentAdmin != null)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Admin Menu:");
                    Console.WriteLine("1. View All Available books");
                    Console.WriteLine("2. View All Users");
                    Console.WriteLine("3 Add Admin");
                    Console.WriteLine("4 Add Book");
                    Console.WriteLine("5 Search Book");
                    Console.WriteLine("6 View All Borrowed books");
                    Console.WriteLine("7 View All Books");
                    Console.WriteLine("8 Logout");
                    Console.Write("Please enter your choice: ");
                    string adminChoice = Console.ReadLine();

                    switch (adminChoice)
                    {
                        case "1":
                            libraryService.GetListOfLibraryBooks();
                            break;

                        case "2":
                            Console.WriteLine("List of Users:");
                            foreach (var user in Storage.users)
                            {
                                Console.WriteLine($"ID: {user.Id}, Username: {user.UserName}, Role: {user.Role}");
                            }
                            break;

                        case "3":
                            Console.Write("Please enter your username: ");
                            string adminusername = Console.ReadLine();
                            Console.Write("Please enter your Password: ");
                            string adminpassword = Console.ReadLine();
                            Admin newadmin = new Admin() 
                            {
                                Admin_UserName = adminusername,
                                Admin_Password = adminpassword,
                                Admin_Role = EnumRole.Admin
                            };
                            if (authentication.AdminRegister(newadmin))
                            {
                                Console.WriteLine(" Admin Registration successful!");
                            }
                            else
                            {
                                Console.WriteLine("Admin Registration failed!!!");
                            }

                            break;

                        case "4":
                            libraryService.AddBook();
                            break;


                        case "5":

                            if (libraryService.SearchBook())
                            {
                                Console.WriteLine("Found");
                            }
                            else
                            {
                                Console.WriteLine("Not Found!!!");
                            }
                            break;

                        case "6":
                            libraryService.GetListOfBorrowedBooks();
                            break;

                        case "7":
                            libraryService.ShowAllBooks();
                            break;

                        case "8":
                            Console.WriteLine("Logging out of your account.");
                            Storage.CurrentAdmin = null; 
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    if (adminChoice == "3") break; 
                }
            }
            else 
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("User Menu:");
                    Console.WriteLine("1. Borrow Book");
                    Console.WriteLine("2. Return Book");
                    Console.WriteLine("3. View Borrowed Books");
                    Console.WriteLine("4. Logout");
                    Console.Write("Please enter your choice: ");
                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1": 
                            Console.WriteLine("Available Books:");
                            libraryService.GetListOfLibraryBooks();

                            Console.Write("Please enter the book ID: ");
                            int bookId = int.Parse(Console.ReadLine());
                            int userId = Storage.CurrentUser.Id; 

                            if (libraryService.BorrowBook(bookId, userId))
                            {
                                Console.WriteLine("Book successfully borrowed.");
                            }
                            else
                            {
                                Console.WriteLine("Book not available or invalid ID.");
                            }
                            break;

                        case "2": 
                            Console.Write("Please enter the book ID: ");
                            bookId = int.Parse(Console.ReadLine());
                            userId = Storage.CurrentUser.Id;

                            if (libraryService.ReturnBook(bookId, userId))
                            {
                                Console.WriteLine("Book successfully returned.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid book ID.");
                            }
                            break;

                        case "3": 
                            libraryService.GetListOfUserBooks(Storage.CurrentUser.Id);
                            break;

                        case "4": 
                            Console.WriteLine("Logging out of your account.");
                            Storage.CurrentUser = null; 
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    if (userChoice == "4") break; 
                }
            }
        }
        else
        {
            Console.WriteLine("Login failed.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    else if (Choice == "2") 
    {
        Console.Write("Please enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter your family name: ");
        string family = Console.ReadLine();
        Console.Write("Please enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Please enter your password: ");
        string password = Console.ReadLine();

        User newUser = new User
        {
            UserName = username,
            Name = name,
            Family = family,
            Email = email,
            Password = password,
            Role = EnumRole.Member 
        };

        if (authentication.Register(newUser))
        {
            Console.WriteLine("Registration successful!");
        }
        else
        {
            Console.WriteLine("Registration failed!!! Email or Username exist.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    else if (Choice == "3") 
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}