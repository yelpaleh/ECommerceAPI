using ECommerceAPI.Models;

namespace ECommerceAPI.Repository.Interface
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
    }
}
