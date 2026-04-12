// I transformed my console-based banking system into a RESTful ASP.NET Core Web API,
// implementing controllers, services, and repositories with Entity Framework Core and SQL
// Server for persistent data storage, user authentication, and transaction handling.

using BankingAppWebAPIV1.Data;
using Microsoft.EntityFrameworkCore;
using BankingAppWebAPIV1.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();