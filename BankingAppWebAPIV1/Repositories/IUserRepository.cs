using BankingAppWebAPIV1.Models;

public interface IUserRepository
{
    User GetByUsername(string username);
    void Add(User user);
    void Save();
}
