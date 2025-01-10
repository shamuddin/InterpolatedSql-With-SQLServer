InterpolatedSql-With-SQLServer 🚀
This repository demonstrates how to simplify SQL queries using Dapper and InterpolatedSql.Dapper with SQL Server. It provides clean, secure, and efficient examples of performing CRUD operations and dynamic queries in a .NET application.

Features ✨
Secure SQL Queries: Automatically parameterized to prevent SQL injection.
Dynamic Query Building: Seamlessly build flexible queries.
Simplified Code: Use string interpolation to write clean and readable SQL.
Prerequisites 🛠️
.NET 6.0 or later
SQL Server
Visual Studio or any C# IDE
Getting Started 🚦
Clone the repository:

bash
Copy code
git clone https://github.com/shamuddin/InterpolatedSql-With-SQLServer.git
Navigate to the project directory:

bash
Copy code
cd InterpolatedSql
Update the appsettings.json with your SQL Server connection string:

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Customers;Trusted_Connection=True;"
  }
}
Run the application:

bash
Copy code
dotnet run
Usage 📖
This project includes the following CRUD operations:

Get Customer by ID: Fetch a single customer by their ID.
Get All Customers: Retrieve all customers.
Add a Customer: Insert a new customer.
Update a Customer: Modify an existing customer's details.
Delete a Customer: Remove a customer by their ID.
Dynamic Filters: Build queries dynamically based on optional parameters.
Example API Endpoints 🌐
GET /api/customers/{id}: Fetch a customer by ID.
GET /api/customers: Retrieve all customers.
POST /api/customers: Add a new customer.
PUT /api/customers/{id}: Update an existing customer.
DELETE /api/customers/{id}: Delete a customer by ID.
Reference Articles 📚
To get the most out of this project, check out these essential articles:

Simplify Your SQL Queries with Dapper and InterpolatedSql.Dapper
