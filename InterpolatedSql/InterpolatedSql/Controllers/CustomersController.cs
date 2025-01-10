using InterpolatedSqlDemo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InterpolatedSqlDemo.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDapperCustomerRepository _dapperRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="dapperRepo">The Dapper repository for customer data access.</param>
        public CustomersController(IDapperCustomerRepository dapperRepo)
        {
            _dapperRepo = dapperRepo;
        }

        /// <summary>
        /// Retrieves a single customer by their ID using Dapper.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer with the specified ID, or a 404 status if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _dapperRepo.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound("Customer not found.");
            return Ok(customer);
        }

        /// <summary>
        /// Retrieves all customers using Dapper.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _dapperRepo.GetAllCustomersAsync();
            return Ok(customers);
        }

        /// <summary>
        /// Retrieves customers dynamically based on optional filters.
        /// </summary>
        /// <param name="name">Optional name filter for customers.</param>
        /// <param name="email">Optional email filter for customers.</param>
        /// <returns>A list of customers matching the filters.</returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetCustomersByDynamicFilters([FromQuery] string? name, [FromQuery] string? email)
        {
            var customers = await _dapperRepo.GetCustomersByDynamicFiltersAsync(name, email);
            return Ok(customers);
        }

        /// <summary>
        /// Retrieves customers with advanced filters.
        /// </summary>
        /// <param name="minId">The minimum customer ID to include.</param>
        /// <param name="emailDomain">The email domain filter (e.g., %example.com).</param>
        /// <returns>A list of customers matching the advanced filters.</returns>
        [HttpGet("advanced-filter")]
        public async Task<IActionResult> GetCustomersByAdvancedFilters([FromQuery] int minId, [FromQuery] string? emailDomain)
        {
            var customers = await _dapperRepo.GetCustomersByAdvancedFiltersAsync(minId, emailDomain);
            return Ok(customers);
        }
    }
}
