using System;
using ddd_template.Application.Requests.Customers;
using ddd_template.Application.Responses;
using ddd_template.Application.Responses.Customers;
using ddd_template.Domain.Customers;
using ddd_template.Domain.Customers.Services;
using ddd_template.Domain.Exceptions;

namespace ddd_template.Application.Servicecs
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private ICustomerDomainService _customerDomainService;

        public CustomerApplicationService(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        public BaseResponse<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            var response = new BaseResponse<CreateCustomerResponse>();
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException("missing request");
                }

                var responseData = new CreateCustomerResponse();

                var address = new Address(request.city, request.street, request.building);

                var customerBuilder = new Customer.Builder();
                var customer = customerBuilder
                    .SetLogin(request.username, request.password)
                    .SetName(request.firstname, request.surname)
                    .Locate(address)
                    .Build();

                _customerDomainService.CreateCustomer(customer);

                response.SetData(responseData);
            }
            catch(Exception e)
            {
                response.SetError(e);
            }
            return response;
        }

        public BaseResponse<CustomerResponse> GetCustomerById(long id)
        {
            var response = new BaseResponse<CustomerResponse>();
            try
            {
                if (id == 0)
                {
                    throw new BaseException(ErrorCode.CustomerNotFound);
                }

                var data = new CustomerResponse();

                var customer = _customerDomainService.GetCustomerById(id);

                data.id = customer.Id;
                data.username = customer.Username;
                data.firstname = customer.Firstname;
                data.surname = customer.Surname;

                response.SetData(data);

            }
            catch (Exception e)
            {
                response.SetError(e);
            }
            return response;
        }

        public BaseResponse<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
