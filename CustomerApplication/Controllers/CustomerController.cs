using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _service.GetAll();
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
                var response = _service.GetById(id);
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
                var createdCustomer = _service.Create(customer);
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
                _service.Update(customer);
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
                _service.Delete(id);
                return NoContent();
            } 
            catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }  
        }
    }
}
