using Dapper;
using InterpolatedSql.Dapper;
using InterpolatedSqlDemo.Models;
using InterpolatedSqlDemo.Repositories.Interface;
using Microsoft.Data.SqlClient;

namespace InterpolatedSqlDemo.Repositories
{
    public class DapperCustomerRepository : IDapperCustomerRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperCustomerRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public DapperCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets a single customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer with the specified ID, or null if not found.</returns>
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = connection.SqlBuilder($"SELECT * FROM Customers WHERE CustomerId = {id}");
            // Executes the query and retrieves the first matching customer or null.
            return await query.QueryFirstOrDefaultAsync<Customer>();
        }

        /// <summary>
        /// Gets all customers from the database.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            // Executes a simple query to retrieve all customers.
            return await connection.QueryAsync<Customer>("SELECT * FROM [dbo].[Customers]");
        }

        /// <summary>
        /// Inserts a new customer into the database.
        /// </summary>
        /// <param name="customer">The customer to be added.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = connection.SqlBuilder($@"
                INSERT INTO Customers (Name, Email) 
                VALUES ({customer.Name}, {customer.Email})");
            // Executes the insert command and returns the number of rows affected.
            return await command.ExecuteAsync();
        }

        /// <summary>
        /// Updates an existing customer's details.
        /// </summary>
        /// <param name="customer">The customer with updated details.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = connection.SqlBuilder($@"
                UPDATE Customers 
                SET Name = {customer.Name}, Email = {customer.Email} 
                WHERE CustomerId = {customer.CustomerId}");
            // Executes the update command and returns the number of rows affected.
            return await command.ExecuteAsync();
        }

        /// <summary>
        /// Deletes a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> DeleteCustomerAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = connection.SqlBuilder($"DELETE FROM Customers WHERE CustomerId = {id}");
            // Executes the delete command and returns the number of rows affected.
            return await command.ExecuteAsync();
        }

        /// <summary>
        /// Gets customers based on dynamic filters.
        /// </summary>
        /// <param name="name">The name filter (optional).</param>
        /// <param name="email">The email filter (optional).</param>
        /// <returns>A list of customers matching the filters.</returns>
        public async Task<IEnumerable<Customer>> GetCustomersByDynamicFiltersAsync(string? name, string? email)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = connection.SqlBuilder($"SELECT * FROM Customers WHERE 1=1");

            // Dynamically append filters to the query.
            if (!string.IsNullOrEmpty(name))
                query += $"AND Name LIKE {name}";

            if (!string.IsNullOrEmpty(email))
                query += $"AND Email LIKE {email}";

            // Executes the dynamic query and retrieves the matching customers.
            return await query.QueryAsync<Customer>();
        }

        /// <summary>
        /// Gets customers using advanced filters with a multiline query.
        /// </summary>
        /// <param name="minId">The minimum customer ID.</param>
        /// <param name="emailDomain">The email domain filter.</param>
        /// <returns>A list of customers matching the filters.</returns>
        public async Task<IEnumerable<Customer>> GetCustomersByAdvancedFiltersAsync(int minId, string? emailDomain)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = connection.SqlBuilder($@"
                SELECT * FROM Customers
                WHERE CustomerId >= {minId}
                AND Email LIKE {emailDomain}");
            // Executes the advanced query and retrieves the matching customers.
            return await query.QueryAsync<Customer>();
        }
    }
}