using DomainModels.Entities;
using DomainServices.Interfaces;
using DomainServices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new ();

        public long Create(Customer customer)
        {
            CustomerServiceMethodExtensions.IsCustomerValid(_customers, customer);

            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;
            _customers.Add(customer);
            return customer.Id;
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
            var customer = _customers.FirstOrDefault(customer => customer.Id == id) 
                ?? throw new ArgumentNullException($"Customer for id: {id} was not found");

            return customer;
        }

        public void Update(Customer customer)
        {
            var customerIndex = _customers.FindIndex(tempCustomer => tempCustomer.Id == customer.Id);
            
            if (customerIndex == -1) throw new ArgumentNullException($"Customer for id: {customer.Id} could not be found");

            CustomerServiceMethodExtensions.IsCustomerValid(_customers, customer);

            _customers[customerIndex] = customer;
        }
    }
}
