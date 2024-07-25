using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;
using ECommerceAPI.Repository;
using ECommerceAPI.Repository.Interface;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _customerRepository.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (customer == null || id != customer.CustomerId)
            {
                return BadRequest();
            }
            var existingCustomer = _customerRepository.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            _customerRepository.UpdateCustomer(customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _customerRepository.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            _customerRepository.DeleteCustomer(id);
            return NoContent();
        }
    }
}
