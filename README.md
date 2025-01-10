# InterpolatedSql-With-SQLServer 🚀

This repository demonstrates how to simplify SQL queries using **Dapper** and **InterpolatedSql.Dapper** with SQL Server. It provides clean, secure, and efficient examples of performing CRUD operations and dynamic queries in a .NET application.

---

## Features ✨

- **Secure SQL Queries** 🔒: Automatically parameterized to prevent SQL injection.  
- **Dynamic Query Building** 🔄: Seamlessly build flexible queries.  
- **Simplified Code** 🧹: Use string interpolation to write clean and readable SQL.  

---

## Prerequisites 🛠️

- **.NET 6.0 or later**  
- **SQL Server**  
- **Visual Studio** or any C# IDE  

---

## Getting Started 🚦

1. **Clone the repository**:  
   ```bash
   git clone https://github.com/shamuddin/InterpolatedSql-With-SQLServer.git
   ```

2. **Navigate to the project directory**:  
   ```bash
   cd InterpolatedSql
   ```

3. **Update the `appsettings.json`** with your SQL Server connection string:  
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Customers;Trusted_Connection=True;"
     }
   }
   ```

4. **Run the application**:  
   ```bash
   dotnet run
   ```

---

## Usage 📖

This project includes the following CRUD operations:

- **Get Customer by ID** 🔍: Fetch a single customer by their ID.  
- **Get All Customers** 👥: Retrieve all customers.  
- **Add a Customer** ➕: Insert a new customer.  
- **Update a Customer** ✏️: Modify an existing customer's details.  
- **Delete a Customer** 🗑️: Remove a customer by their ID.  
- **Dynamic Filters** 🛠️: Build queries dynamically based on optional parameters.  

---

## Example API Endpoints 🌐

- `GET /api/customers/{id}` 🔍: Fetch a customer by ID.  
- `GET /api/customers` 👥: Retrieve all customers.  
- `POST /api/customers` ➕: Add a new customer.  
- `PUT /api/customers/{id}` ✏️: Update an existing customer.  
- `DELETE /api/customers/{id}` 🗑️: Delete a customer by ID.  

---

## Reference Articles 📚

- [Simplify Your SQL Queries with Dapper and InterpolatedSql.Dapper](https://medium.com/@shamuddin/simplify-your-sql-queries-with-dapper-and-interpolatedsql-dapper-ad0977d4688e)  

---
