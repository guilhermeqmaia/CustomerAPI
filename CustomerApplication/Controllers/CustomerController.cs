using AppServices.Interfaces;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerService;

        public CustomerController(ICustomerAppService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _customerService.GetAll();
                return Ok(response);
            } 
            catch
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var response = _customerService.GetById(id);
                return Ok(response);
            } 
            catch (ArgumentNullException exception) {
                return NotFound(exception.Message);
            } 
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try {
                var createdCustomer = _customerService.Create(customer);
                return Created("", createdCustomer);
            } 
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _customerService.Update(customer);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                _customerService.Delete(id);
                return NoContent();
            } 
            catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }  
        }
    }
}
