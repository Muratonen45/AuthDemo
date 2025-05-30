# ASP.NET Core 8 JWT Authentication API with Roles and Refresh Tokens

This project is a secure and scalable authentication system built with ASP.NET Core 8 and Entity Framework Core, featuring:

- User registration and login
- Password hashing with BCrypt
- JWT access token generation including user roles (User/Admin)
- Refresh token mechanism for renewing access tokens
- Role-based authorization on endpoints
- SQL Server database integration
- Endpoints for token refresh and current user info (`whoami`)
- Clean DTO (Data Transfer Object) pattern for request/response models

---

## Prerequisites

- .NET 8 SDK installed on your machine
- SQL Server instance available (local or remote)
- An API client tool like Postman for testing

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Muratonen45/AuthDemo.git
cd AuthDemo.git
2. Configure your database connection
Edit the appsettings.json file and update the DefaultConnection string with your SQL Server instance details:


"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;Integrated Security=True;"
}
3. Apply database migrations
Make sure you have the EF Core tools installed. Then run:

dotnet ef migrations add InitialCreate
dotnet ef database update
This will create the database and necessary tables.

4. Run the application

dotnet run
Your API will start running at https://localhost:5001 (or similar).

API Endpoints
Method	Endpoint	Description	Authorization
POST	/api/auth/register	Register a new user	None
POST	/api/auth/login	Login and get tokens	None
POST	/api/auth/refresh-token	Refresh access token	None
GET	/api/auth/whoami	Get current user information	Bearer Token (User or Admin)

Authentication Flow
User registers with username, email, and password.

On login, user receives an access token (JWT) and a refresh token.

Access token contains user role information.

When access token expires, the client can request a new one using the refresh token.

whoami endpoint lets authenticated users retrieve their own info including role.

Role-based Authorization
Two roles are supported:

User: Default role for normal users.

Admin: Elevated privileges.

You can protect API endpoints based on roles using [Authorize(Roles = "Admin")] or [Authorize(Roles = "User,Admin")].

Technologies Used
ASP.NET Core 8

Entity Framework Core 8

SQL Server

JWT (System.IdentityModel.Tokens.Jwt)

BCrypt.Net for password hashing

Notes
Update your JWT settings in appsettings.json (Key, Issuer, Audience, expiration times).

Protect your JWT secret key carefully.

Use HTTPS in production for security.

This project uses clean DTOs for clear API contracts.

Thank you for using this project!
