using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Utilities
{
    internal class CustomerServiceMethodExtensions
    {
        public static bool IsCustomerValid(List<Customer> customers, Customer customer)
        {
            if (customers.Any((tempCustomer) => tempCustomer.Email == customer.Email && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer for email {customer.Email} already exists");

            if (customers.Any((tempCustomer) => tempCustomer.Cpf == customer.Cpf && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer for cpf {customer.Cpf} already exists");

            return true;
        }
    }
}
