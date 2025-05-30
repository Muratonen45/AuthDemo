# ASP.NET Core 8 JWT Authentication API with Roles and Refresh Tokens

This project is a simple but secure backend API for user authentication built with ASP.NET Core 8. It supports:

- User registration and login
- Password hashing with BCrypt
- JWT token generation with User/Admin roles
- Refresh token mechanism
- Role-based authorization
- SQL Server database with Entity Framework Core
- Endpoint to get current user info (`whoami`)

---

## Features

- **Register**: Users can register with a username, email, and password.
- **Login**: Users login and receive JWT access tokens and refresh tokens.
- **Refresh Token**: Allows refreshing the JWT token without logging in again.
- **Role-based Access Control**: Roles like `User` and `Admin` are implemented.
- **WhoAmI Endpoint**: Returns the current logged-in user information.
  
---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [EF Core CLI Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

---

## Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/AuthDemo.git
   cd AuthDemo
2.**Configure your database:**

Open appsettings.json and update the connection string:

json
Kopyala
Düzenle
"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER_NAME;Initial Catalog=AuthDemoDb;Integrated Security=True"
}

3.**Run migrations to create the database schema:**


dotnet ef migrations add InitialCreate
dotnet ef database update
Run the application:


4.**Test the API endpoints using Postman or any API client:**

POST /api/auth/register to register a new user

POST /api/auth/login to login and receive tokens

POST /api/auth/refresh-token to refresh tokens

GET /api/auth/whoami to get current user info (requires Authorization header)

**API Endpoints**
Method	Endpoint	Description	Auth Required	Roles
POST	/api/auth/register	Register a new user	No	N/A
POST	/api/auth/login	User login	No	N/A
POST	/api/auth/refresh-token	Refresh access token	No	N/A
GET	/api/auth/whoami	Get current user info	Yes	User, Admin

**Technologies Used**
ASP.NET Core 8

Entity Framework Core

SQL Server

JWT Authentication

BCrypt password hashing

**Sample Request/Response**
Register Request

{
  "userName": "john_doe",
  "email": "john@example.com",
  "password": "StrongPassword123"
}
**Login Request**
{
  "email": "john@example.com",
  "password": "StrongPassword123"
}
**Login Response**

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "9f8b1c3a4..."
}
