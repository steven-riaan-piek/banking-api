using BankingAppWebAPIV1.Models;
using BankingAppWebAPIV1.Services;

namespace BankingAppWebAPIV1.Services;

public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    // 🔍 GET USER
    public User GetByUsername(string username)
    {
        return _repo.GetByUsername(username);
    }

    // 🆕 REGISTER
    public bool Register(string username, string password)
    {
        if (_repo.GetByUsername(username) != null)
            return false;

        var user = new User
        {
            Username = username,
            Password = password,
            Balance = 0
        };

        _repo.Add(user);
        _repo.Save();

        return true;
    }

    // 🔐 LOGIN
    public User Login(string username, string password)
    {
        var user = _repo.GetByUsername(username);

        if (user == null || user.Password != password)
            return null;

        return user;
    }

    // 💰 DEPOSIT
    public bool Deposit(string username, decimal amount)
    {
        var user = _repo.GetByUsername(username);

        if (user == null || amount <= 0)
            return false;

        user.Balance += amount;

        _repo.Save();
        return true;
    }

    // 💸 WITHDRAW
    public bool Withdraw(string username, decimal amount)
    {
        var user = _repo.GetByUsername(username);

        if (user == null || amount <= 0 || amount > user.Balance)
            return false;

        user.Balance -= amount;

        _repo.Save();
        return true;
    }

    // 🔄 TRANSFER
    public bool Transfer(string sender, string receiver, decimal amount)
    {
        // ❌ Prevent self-transfer
        if (sender.ToLower() == receiver.ToLower())
            return false;

        var from = _repo.GetByUsername(sender);
        var to = _repo.GetByUsername(receiver);

        if (from == null || to == null)
            return false;

        if (amount <= 0 || amount > from.Balance)
            return false;

        from.Balance -= amount;
        to.Balance += amount;

        _repo.Save();
        return true;
    }

    // 📜 HISTORY (basic for now)
    public List<string> GetHistory(string username)
    {
        var user = _repo.GetByUsername(username);

        if (user == null)
            return null;

        // Placeholder until we wire Transactions table properly
        return new List<string>
        {
            $"User: {username}",
            $"Balance: {user.Balance:C2}",
            "Transaction history coming soon..."
        };
    }
}