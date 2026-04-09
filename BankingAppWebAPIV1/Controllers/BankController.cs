using Microsoft.AspNetCore.Mvc;
using BankingAppWebAPIV1.Services;
using BankingAppWebAPIV1.Models;

namespace BankingAppWebAPIV1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly UserService _service;

    public BankController(UserService service)
    {
        _service = service;
    }

    // 🔐 REGISTER
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (!_service.Register(request.Username, request.Password))
            return BadRequest("User already exists");

        return Ok("User registered successfully");
    }

    // 🔐 LOGIN
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _service.Login(request.Username, request.Password);

        if (user == null)
            return BadRequest("Invalid username or password");

        return Ok("Login successful");
    }

    // 💰 GET BALANCE
    [HttpGet("{username}/balance")]
    public IActionResult GetBalance(string username)
    {
        var user = _service.GetByUsername(username);

        if (user == null)
            return BadRequest("User not found");

        return Ok(user.Balance);
    }

    // 💵 DEPOSIT
    [HttpPost("{username}/deposit")]
    public IActionResult Deposit(string username, [FromBody] decimal amount)
    {
        var result = _service.Deposit(username, amount);

        if (!result)
            return BadRequest("Deposit failed");

        return Ok("Deposit successful");
    }

    // 💸 WITHDRAW
    [HttpPost("{username}/withdraw")]
    public IActionResult Withdraw(string username, [FromBody] decimal amount)
    {
        var result = _service.Withdraw(username, amount);

        if (!result)
            return BadRequest("Withdraw failed");

        return Ok("Withdraw successful");
    }

    // 📜 HISTORY
    [HttpGet("{username}/history")]
    public IActionResult History(string username)
    {
        var history = _service.GetHistory(username);

        if (history == null)
            return BadRequest("User not found");

        return Ok(history);
    }

    // 🔄 TRANSFER
    [HttpPost("{sender}/transfer/{receiver}")]
    public IActionResult Transfer(string sender, string receiver, [FromBody] decimal amount)
    {
        if (sender.ToLower() == receiver.ToLower())
            return BadRequest("You cannot transfer money to yourself");

        var result = _service.Transfer(sender, receiver, amount);

        if (!result)
            return BadRequest("Transfer failed");

        return Ok("Transfer successful");
    }
}