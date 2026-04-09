using Microsoft.EntityFrameworkCore;
using BankingAppWebAPIV1.Models;

namespace BankingAppWebAPIV1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
}
