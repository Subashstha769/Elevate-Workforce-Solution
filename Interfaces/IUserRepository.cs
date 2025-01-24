using WebLab2024.Models;
using WebLab2024.Entities;

namespace WebLab2024.Interfaces
{
    public interface IUserRepository
    {
        string CreateUser(UserViewModel uvm);
        User LoginUser(string username, string password);

    }
    

}