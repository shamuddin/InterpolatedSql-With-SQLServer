using InterpolatedSqlDemo.Models;

namespace InterpolatedSqlDemo.Repositories.Interface
{
    public interface IDapperCustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
        Task<int> DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersByAdvancedFiltersAsync(int minId, string? emailDomain);
        Task<IEnumerable<Customer>> GetCustomersByDynamicFiltersAsync(string? name, string? email);
        Task<int> UpdateCustomerAsync(Customer customer);
    }
}
