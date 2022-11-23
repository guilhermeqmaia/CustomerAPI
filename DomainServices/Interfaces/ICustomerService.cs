using DomainModels.Entities;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface ICustomerService
    {
        long Create(Customer customer);
        void Update(Customer customer);
        void Delete(long id);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
    }
}
