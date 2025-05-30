# ASP.NET Core 8 - JWT Authentication API with Roles & Refresh Tokens

This is a backend-only RESTful API built with **ASP.NET Core 8**, implementing user authentication and authorization using **JWT** tokens with **role-based access control** and **refresh token mechanism**.

---

## ✅ Features

- ✅ User registration with password hashing (BCrypt)
- ✅ Login with JWT generation (access + refresh tokens)
- ✅ Role-based authentication (User, Admin)
- ✅ Token refresh endpoint
- ✅ Secure password storage
- ✅ WhoAmI endpoint (returns currently logged-in user info)
- ✅ Clean DTO structure
- ✅ SQL Server + EF Core integration

---

## 🛠️ Technologies

- .NET 8
- Entity Framework Core
- SQL Server
- JWT Bearer Auth
- ASP.NET Identity (Custom lightweight version)
- BCrypt.NET

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Postman or Swagger UI

---

## 🔧 Configuration

### 1. Clone the repository
```bash
git clone https://github.com/Muratonen45/AuthDemo.git
cd AuthDemo.git


---


### 2. Update appsettings.json

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=MyDb;Integrated Security=True;"
  },
  "Jwt": {
    "Key": "Your_Secret_Key_At_Least_32_Chars_Long!",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "AccessTokenExpirationMinutes": 30,
    "RefreshTokenExpirationDays": 7
  }
}

3. Apply Migrations & Create DB
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run


🧪 API Endpoints
Method	Route	Auth Required	Description
POST	/api/auth/register	❌	Register a new user
POST	/api/auth/login	❌	Login and receive tokens
POST	/api/auth/refresh-token	❌	Refresh JWT token
GET	/api/auth/whoami	✅	Get logged-in user info


📦 DTO Examples
RegisterRequest
{
  "userName": "john_doe",
  "email": "john@example.com",
  "password": "P@ssw0rd123"
}

LoginRequest
{
  "email": "john@example.com",
  "password": "P@ssw0rd123"
}

TokenResponse
{
  "token": "eyJhbGciOiJIUzI1...",
  "refreshToken": "4f08b8c0-..."
}


🔐 Role Support
Users can have a Role of:

"User"

"Admin"

These can be used with [Authorize(Roles = "Admin")] or [Authorize(Roles = "User")] in any controller.

👤 WhoAmI Endpoint
Returns information about the currently logged-in user based on the JWT token.

GET /api/auth/whoami
Sample Response:
{
  "userName": "john_doe",
  "email": "john@example.com",
  "role": "User"
}

📌 Notes
Tokens are signed using HMAC SHA256

BCrypt is used for password hashing

Refresh tokens are stored and validated with expiration time


📁 Project Structure (Simplified)

/AuthDemo
│
├── Controllers
│   └── AuthController.cs
├── Models
│   ├── User.cs
│   └── DTOs (RegisterRequest, LoginRequest, TokenResponse, etc.)
├── Services
│   └── TokenService.cs
├── Data
│   └── AppDbContext.cs
├── Program.cs
├── appsettings.json
└── README.md
