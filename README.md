
# Authentication and authorization API (in progress)

An authentication and authorization project built with ASP.NET Core Web API using .NET 7, MS SQL, Entity Framework, and JWT involves implementing a secure and reliable mechanism for user authentication and authorization.

## Technologies
- .NET 7
- ASP.NET Core Web API
- MSSQL
- Entity Framework
- JWT

## API Reference

#### AUTH
*Register user and save to the db
```http
  POST /api/auth/register
```
*Login user and generate JWT token
```http
  POST /api/auth/authenticate
```
