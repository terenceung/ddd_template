using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd_template.API.Requests.Accounts;
using ddd_template.API.Responses;
using ddd_template.API.Responses.Accounts;
using ddd_template.Domain.Accounts;
using ddd_template.Domain.Exceptions;
using ddd_template.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ddd_template.API.Controllers
{
    [Route("api/v1/accounts")]
    public class AccountController : Controller
    {
        private IAccountDomainService _service;

        public AccountController(IAccountDomainService service)
        {
            _service = service;
        }
       
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAccount(AccountTransferRequest request)
        {
            var response = new BaseResponse<AccountTransferResponse>();
            var data = new AccountTransferResponse();

            try
            {
                var accRepo = new AccountRepository();
                var accountFrom = accRepo.GetAccountById(request.fromAccountId);
                var accountTo = accRepo.GetAccountById(request.toAccountId);

                if(accountFrom == null)
                {
                    throw new AccountNotFoundException($"{request.fromAccountId}");
                }

                if (accountTo == null)
                {
                    throw new AccountNotFoundException($"{request.toAccountId}");
                }

                _service.TransferTo(accountFrom, accountTo, request.amount);

                accRepo.UpdateAccount(accountFrom);
                accRepo.UpdateAccount(accountTo);

                //consider using mapper such as automapper lib
                data.fromAccountAmount = accountFrom.Amount;
                data.toAccountAmount = accountTo.Amount;

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
