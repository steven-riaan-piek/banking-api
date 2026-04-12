using System;
using System.Collections.Generic;
using System.IO;

public class BankAccount
{
    public decimal Balance { get; private set; }
    public List<string> History { get; private set; }

    private string filePath;
    private string password;

    public BankAccount(string userName, string passwordInput)
    {
        filePath = userName.ToLower() + "_data.txt";
        History = new List<string>();

        if (File.Exists(filePath))
        {
            LoadData();
        }
        else
        {
            password = passwordInput;
        }
    }

    public bool CheckPassword(string input)
    {
        return password == input;
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0) return false;

        Balance += amount;
        History.Add($"Deposited {amount:C2} at {DateTime.Now}");
        SaveData();
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance) return false;

        Balance -= amount;
        History.Add($"Withdrew {amount:C2} at {DateTime.Now}");
        SaveData();
        return true;
    }

    public bool TransferTo(BankAccount recipient, decimal amount)
    {
        if (amount <= 0 || amount > Balance || recipient == null)
            return false;

        Balance -= amount;
        recipient.Balance += amount;

        History.Add($"Transferred {amount:C2} to {recipient.GetName()} at {DateTime.Now}");
        recipient.History.Add($"Received {amount:C2} from {GetName()} at {DateTime.Now}");

        SaveData();
        recipient.SaveData();

        return true;
    }

    public string GetName()
    {
        return filePath.Replace("_data.txt", "");
    }

    public void SaveData()
    {
        var lines = new List<string>
        {
            password,              
            Balance.ToString()     
        };

        lines.AddRange(History);
        File.WriteAllLines(filePath, lines);
    }

    public void LoadData()
    {
        var lines = File.ReadAllLines(filePath);

        if (lines.Length > 0)
            password = lines[0];

        if (lines.Length > 1)
            Balance = Convert.ToDecimal(lines[1]);

        for (int i = 2; i < lines.Length; i++)
            History.Add(lines[i]);
    }
}