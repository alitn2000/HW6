
namespace HW6;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Email { get; set; }
    public EnumRole Role { get; set; }
    public List<Books> book = new();


}