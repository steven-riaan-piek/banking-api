Banking API (ASP.NET Core Web API)

Overview
I developed a RESTful ASP.NET Core Web API for a banking system that supports user authentication, account management, and financial transactions. 
The application uses Entity Framework Core with SQL Server for persistent data storage.

---

Features
- User registration and login
- Account balance management
- Deposit and withdrawal operations
- Fund transfers between users
- Transaction history
- RESTful API endpoints
- Data persistence with SQL Server
- Entity Framework Core (Code First + Migrations)

---

Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (API testing & documentation)

---

What I Learned
- Building RESTful APIs with ASP.NET Core
- Designing layered architecture (Controller → Service → Repository)
- Using Entity Framework Core for database operations
- Working with SQL Server and migrations
- Structuring scalable backend systems

---

How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/steven-riaan-piek/banking-api.git
2. Open the project in Visual Studio
3. Update the connection string in appsettings.json if needed
4. Run database migrations: dotnet ef database update
5. dotnet ef database update
6. https://localhost:xxxx/swagger/index.html (for me, I have to use index.html; otherwise, skip it )
7. Make sure to install the needed packages I used.

7.1 Microsoft.AspNetCore.OpenApi → API metadata
7.2 EFCore.SqlServer → connect to SQL Server
7.3 EFCore.Tools → migrations/database commands
7.4 Swashbuckle → Swagger UI (testing API)

8. Open the terminal and paste each one individually to install the package

8.1 dotnet add package Microsoft.AspNetCore.OpenApi
8.2 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
8.3 dotnet add package Microsoft.EntityFrameworkCore.Tools
8.4 dotnet add package Swashbuckle.AspNetCore
    
