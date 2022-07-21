using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spice_shelf.Models;
using spice_shelf.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace spice_shelf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}