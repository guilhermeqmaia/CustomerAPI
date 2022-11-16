using CustomerAPI.Validators;
using Data.Entities;
using Data.Interfaces;


namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private CustomerValidator _validator= new CustomerValidator ();
        public void Create(Customer customer)
        {
            var validate = _validator.Validate(customer);
            if(!validate.IsValid) throw new ArgumentException(validate.Errors.ToString());
            
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
            var customer = _customers.Where(customer => customer.Id == id).FirstOrDefault();
            if (customer == null) throw new ArgumentException($"Customer with id {id} was not found");
            return customer;
        }

        public void Update(Customer customer)
        {
            var customerIndex = _customers.FindIndex(tempCustomer => tempCustomer.Cpf == customer.Cpf);
            if (customerIndex == -1) throw new ArgumentException($"No customer with id {customer.Id} was found in our database.");
            
            if (_customers.Any((tempCustomer) => tempCustomer.Email == customer.Email && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer with email {customer.Email} already exists");
            if (_customers.Any((tempCustomer) => tempCustomer.Cpf == customer.Cpf && tempCustomer.Id != customer.Id))
                throw new ArgumentException($"Customer with cpf {customer.Cpf} already exists");

            _customers[customerIndex] = customer;
        }
    }
}
