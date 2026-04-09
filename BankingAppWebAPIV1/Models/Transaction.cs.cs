namespace BankingAppWebAPIV1.Models;

public class Transaction
{
    public int Id { get; set; }

    public string Type { get; set; } // Deposit, Withdraw, Transfer

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }
}