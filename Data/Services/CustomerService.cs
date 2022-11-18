using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new ();

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

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(long id)
        {
            var customer = _customers.FirstOrDefault(customer => customer.Id == id);

            if (customer == null)
                throw new ArgumentNullException($"Customer with id: {id} was not found");

            return customer;
        }

        public void Update(Customer customer)
        {
            var customerIndex = _customers.FindIndex(tempCustomer => tempCustomer.Id == customer.Id);
            
            if (customerIndex == -1) throw new ArgumentNullException($"No customer with id {customer.Id} was found in our database.");
            
            if (_customers.Any((tempCustomer) => tempCustomer.Email == customer.Email && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer with email {customer.Email} already exists");
            
            if (_customers.Any((tempCustomer) => tempCustomer.Cpf == customer.Cpf && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer with cpf {customer.Cpf} already exists");

            _customers[customerIndex] = customer;
        }
    }
}
