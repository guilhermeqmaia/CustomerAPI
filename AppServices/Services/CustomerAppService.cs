using AppServices.Interfaces;
using DomainModels.Entities;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public long Create(Customer customer)
        {
            _customerService.Create(customer);
            return customer.Id;
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerService.GetAll();
        }

        public Customer GetById(long id)
        {
            return _customerService.GetById(id);   
        }

        public void Update(Customer customer)
        {
            _customerService.Update(customer);
        }
    }
}
