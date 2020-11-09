using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd_template.Application.Requests.Customers;
using ddd_template.Application.Servicecs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ddd_template.API.Controllers
{
    [Route("api/v1/customers")]
    public class CustomerController : Controller
    {
        private ICustomerApplicationService _customerAppService;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerAppService = customerApplicationService;
        }

        /// <summary>
        /// get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            return Ok(_customerAppService.GetCustomerById(id));
        }

        /// <summary>
        /// create customer
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            return Ok(_customerAppService.CreateCustomer(request));
        }

        /// <summary>
        /// assume we have logic username and email cannot be change
        /// therefore, we have different class CreateCustomerRequest and UpdateCustomerRequest
        /// consider using PUT for updating rather than POST
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            return Ok(_customerAppService.UpdateCustomer(request));
        }
    }
}
