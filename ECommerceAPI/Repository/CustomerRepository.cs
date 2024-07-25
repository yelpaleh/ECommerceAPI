using ECommerceAPI.DataContext;
using ECommerceAPI.Models;
using ECommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.CustomerId == id);
        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
