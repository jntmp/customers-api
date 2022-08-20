using AutoMapper;
using Customers.Api.Models;
using Customers.Api.Models.Request;
using Customers.Api.Services.Interface;
using Customers.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        // <snippet_Create>
        /// <summary>
        /// Query all the customers using optional filters
        /// </summary>
        /// <param name="filters">eg. ?filters=name+cust,statusId+0</param>
        [HttpGet("/customers")]
        public ActionResult<IEnumerable<CustomerModel>> Customers([FromQuery] string filters)
        {
            var customers = _customerService.GetCustomersWhere(filters);
            return Ok(customers);
        }
        // </snippet_Create>

        [HttpGet("{id}")]
        public ActionResult<CustomerModel> Customer([FromRoute] int id)
        {
            var model = _customerService.Get(id);
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Customer([FromBody] CustomerRequest request)
        {
            var model = _mapper.Map<CustomerRequest, CustomerModel>(request);
            _customerService.Update(model);
            return Ok();
        }

        [HttpGet("{id}/notes")]
        public ActionResult<CustomerModel> Notes([FromRoute] int id)
        {
            var model = _customerService.Get(id);
            return Ok(model);
        }

        // POST api/<CustomerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
