using System;
using ddd_template.Application.Requests.Customers;
using ddd_template.Application.Responses;
using ddd_template.Application.Responses.Customers;

namespace ddd_template.Application.Servicecs
{
    /// <summary>
    /// this acts as an interface / public function / abstraction of the core application
    /// it call different domain function and try to solve a overall problems for public user
    /// any clients such as api, web mvc or CLI
    /// </summary>
    public interface ICustomerApplicationService
    {
        BaseResponse<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request);
        BaseResponse<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request);
        BaseResponse<CustomerResponse> GetCustomerById(long id);
    }
}
