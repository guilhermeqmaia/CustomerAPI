using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers = new List<Customer>();
        public void Create(Customer customer)
        {
            if (_customers.Any((tempCustomer) => tempCustomer.Email == customer.Email))
                throw new ArgumentException($"Customer with email {customer.Email} already exists");
            if (_customers.Any((tempCustomer) => tempCustomer.Cpf == customer.Cpf))
                throw new ArgumentException($"Customer with cpf {customer.Cpf} already exists");
            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            _customers.Add(customer);
        }

        public void Delete(long id)
        {
            var customer = GetById(id);
            _customers.Remove(customer);    
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(long id)
        {
            var customer = _customers.Where(customer=> customer.Id == id).FirstOrDefault();
            if (customer == null) throw new ArgumentException($"Customer with id {id} was not found");
            return customer;
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
