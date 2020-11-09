using System;
using ddd_template.Application.Requests.Accounts;
using ddd_template.Application.Responses;
using ddd_template.Application.Responses.Accounts;
using ddd_template.Domain.Accounts.Services;
using ddd_template.Domain.Exceptions;

namespace ddd_template.Application.Servicecs
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private IAccountDomainService accountDomainService;

        public AccountApplicationService(IAccountDomainService accountDomainService)
        {
            this.accountDomainService = accountDomainService;
        }

        public BaseResponse<AccountResponse> GetAccount(long id)
        {
            var response = new BaseResponse<AccountResponse>();
            try
            {
                if (id == 0)
                {
                    throw new BaseException(ErrorCode.CustomerNotFound);
                }

                var data = new AccountResponse();

                var account = accountDomainService.GetAccountById(id);

                data.id = account.Id;
                data.amount = account.Amount;

                response.SetData(data);

            }
            catch (Exception e)
            {
                response.SetError(e);
            }
            return response;
        }

        public BaseResponse<TransferAccountResponse> TransferAccount(TransferAccountRequest request)
        {
            var response = new BaseResponse<TransferAccountResponse>();
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException("missing body");
                }

                var data = new TransferAccountResponse();

                var source = accountDomainService.GetAccountById(request.sourceId);
                var target = accountDomainService.GetAccountById(request.targetId);

                accountDomainService.TransferTo(source, target, request.amount);

                source = accountDomainService.GetAccountById(request.sourceId);

                data.id = source.Id;
                data.sourceAmount = source.Amount;

                response.SetData(data);

            }
            catch (Exception e)
            {
                response.SetError(e);
            }
            return response;
        }
    }
}
