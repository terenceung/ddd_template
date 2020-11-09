using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd_template.Application.Requests.Accounts;
using ddd_template.Application.Servicecs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ddd_template.API.Controllers
{
    [Route("api/v1/accounts")]
    public class AccountController : Controller
    {
        private IAccountApplicationService _accountAppService;

        public AccountController(IAccountApplicationService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(long id)
        {
            return Ok(_accountAppService.GetAccount(id));
        }

       
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAccount([FromBody]TransferAccountRequest request)
        {
            return Ok(_accountAppService.TransferAccount(request));
        }
    }
}
