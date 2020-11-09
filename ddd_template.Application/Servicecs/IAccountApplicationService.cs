using System;
using ddd_template.Application.Requests.Accounts;
using ddd_template.Application.Responses;
using ddd_template.Application.Responses.Accounts;

namespace ddd_template.Application.Servicecs
{
    public interface IAccountApplicationService
    {
        BaseResponse<AccountResponse> GetAccount(long id);
        BaseResponse<TransferAccountResponse> TransferAccount(TransferAccountRequest request);
    }
}
