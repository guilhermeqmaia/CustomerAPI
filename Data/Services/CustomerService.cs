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
        private List<Customer> customers = new List<Customer>();
        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetById(long id)
        {
            var customer = customers.Where(customer=> customer.Id == id).FirstOrDefault();
            if (customer == null) throw new ArgumentException($"Customer with id {id} was not found");
            return customer;
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
