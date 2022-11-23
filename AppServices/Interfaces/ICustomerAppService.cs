using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        long Create(Customer customer);
        void Update(Customer customer);
        void Delete(long id);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
    }
}
