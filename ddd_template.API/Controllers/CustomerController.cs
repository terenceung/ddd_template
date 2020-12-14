using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd_template.API.Requests.Customers;
using ddd_template.API.Responses;
using ddd_template.API.Responses.Customers;
using ddd_template.Domain.Exceptions;
using ddd_template.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ddd_template.API.Controllers
{
    [Route("api/v1/customers")]
    public class CustomerController : Controller
    {

        public CustomerController()
        {
            
        }

        /// <summary>
        /// get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var response = new BaseResponse<CustomerGetResponse>();
            var data = new CustomerGetResponse();

            try
            {
                var custRepo = new CustomerRepository();
                var customer = custRepo.GetCustomerById(id);

                //consider using mapper such as automapper lib
                data.id = customer.Id;
                data.username = customer.Username;
                data.firstname = customer.Firstname;
                data.surname = customer.Surname;
                data.email = customer.Email;
                data.city = customer.Address?.City;
                data.street = customer.Address?.Street;
                data.building = customer.Address?.Building;

                response.SetData(data);

            }catch(Exception e)
            {
                response.SetError(e);
            }

            return Ok(response);
        }


        [HttpPost("check_address")]
        public async Task<IActionResult> CheckIfTwoCustomersHasSameAddress(CustomerCheckSameAddressRequest request)
        {
            var response = new BaseResponse<CustomerCheckSameAddressResponse>();
            var data = new CustomerCheckSameAddressResponse();

            try
            {
                if(request == null)
                {
                    throw new ArgumentNullException("missing body");
                }

                request.Validate();

                var custRepo = new CustomerRepository();
                var customerA = custRepo.GetCustomerById(request.customerAId);
                var customerB = custRepo.GetCustomerById(request.customerBId);

                if(customerA == null)
                {
                    throw new CustomerNotFoundException($"{request.customerAId}");
                }

                if (customerB == null)
                {
                    throw new CustomerNotFoundException($"{request.customerBId}");
                }

                //consider using mapper such as automapper lib
                data.isSame = customerA.IsLiveTogether(customerB);
                data.customerACity = customerA.Address?.City;
                data.customerAStreet = customerA.Address?.Street;
                data.customerABuilding = customerA.Address?.Building;
                data.customerBBuilding = customerB.Address?.City;
                data.customerBBuilding = customerB.Address?.Street;
                data.customerBBuilding = customerB.Address?.Building;

                response.SetData(data);

            }
            catch (Exception e)
            {
                response.SetError(e);
            }

            return Ok(response);
        }
    }
}
