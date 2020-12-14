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

        public BaseResponse<CustomerCheckSameAddressResponse> CheckIfCustomerHasSameAddress(CustomerCheckSameAddressRequest request)
        {
            var response = new BaseResponse<CustomerCheckSameAddressResponse>();
            var data = new CustomerCheckSameAddressResponse();

            var customerA = _customerDomainService.GetCustomerById(request.customerAId);
            var customerB = _customerDomainService.GetCustomerById(request.customerBId);

            data.isSame = customerA.IsLiveTogether(customerB);
            data.customerACity = customerA.Address.City;
            data.customerABuilding = customerA.Address.Building;
            data.customerAStreet = customerA.Address.Street;
            data.customerBCity = customerB.Address.City;
            data.customerBBuilding = customerB.Address.Building;
            data.customerBStreet = customerB.Address.Street;

            response.SetData(data);

            return response;
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

                var customerBuilder = new Customer(request.username, request.password, request.firstname, request.surname, request.email, address);

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
