using WebLab2024.Models;
using WebLab2024.Interfaces;
using WebLab2024.Entities;
namespace WebLab2024.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;

        }
        public string CreateUser(UserViewModel uvm)
        {
            //Check if username already exist

            if(IsUsernameTaken(uvm.UserName))
            {
                return "0";
            }

            //TO:DO: User login logic
            User usr = new User();
            usr.UserName = uvm.UserName;
            usr.Email = uvm.Email;
            usr.Password = uvm.Password;
            usr.FullName = uvm.FullName;
            usr.PhoneNumber = uvm.PhoneNumber.ToString();

            _context.Users.Add(usr);
            _context.SaveChanges();
            return "1";


            
        }
        public User LoginUser(string username, string password)
        
        {
            var user = _context.Users.Where(x => x.UserName == username && x.Password ==password).FirstOrDefault();

            return user;
        }

        private bool IsUsernameTaken(string username)
        {
            return _context.Users.Any(x => x.UserName == username);

        }


    }
}
