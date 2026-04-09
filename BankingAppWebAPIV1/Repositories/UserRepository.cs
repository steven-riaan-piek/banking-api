using BankingAppWebAPIV1.Data;
using BankingAppWebAPIV1.Models;
namespace BankingAppWebAPIV1.Services;


public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}