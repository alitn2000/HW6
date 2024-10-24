
namespace HW6;
public class Authentication : IAuthentication
{
    public bool Login(string username, string password)
    {
        foreach (var admin in Storage.admins)
        {
            if (admin.Admin_UserName == username && admin.Admin_Password == password)
            {
                Storage.CurrentAdmin = admin;
                return true;
            }
        }

        foreach (var user in Storage.users)
        {
            if (user.UserName == username && user.Password == password)
            {
                Storage.CurrentUser = user;
                return true;
            }
        }

        return false;
    }

    public bool Register(User user)
    {
        foreach (var item in Storage.users)
        {
            if (item.Email == user.Email || item.UserName == user.UserName)
            {
                return false;
            }
        }
        user.Id = Storage.UserCounter++;
        Storage.users.Add(user);
        return true;
    }

    public bool AdminRegister(Admin admin)
    {
        foreach (var a in Storage.admins)
        {
            if (a.Admin_UserName == admin.Admin_UserName)
            {
                return false;
            }

        }
        Storage.admins.Add(admin);
        return true;
    }
}