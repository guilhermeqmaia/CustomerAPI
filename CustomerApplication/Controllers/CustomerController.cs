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
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _customerAppService.GetAll();
                return Ok(response);
            } 
            catch (Exception exception)
            {
                var exceptionMessage = exception.InnerException?.Message ?? exception.Message;
                return Problem(exceptionMessage);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var response = _customerAppService.GetById(id);
                return Ok(response);
            } 
            catch (ArgumentNullException exception) {
                return NotFound(exception.Message);
            } 
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try 
            {
                var createdCustomerId = _customerAppService.Create(customer);
                return Created("Id: ", createdCustomerId);
            } 
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody]Customer customer, long id)
        {
            try
            {
                _customerAppService.Update(customer, id);
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
                _customerAppService.Delete(id);
                return NoContent();
            } 
            catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }  
        }
    }
}
