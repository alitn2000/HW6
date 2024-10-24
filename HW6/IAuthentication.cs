
namespace HW6;

public interface IAuthentication
{
    public bool Login(string username, string password);
    public bool Register(User user);
    public bool AdminRegister(Admin admin);
}
