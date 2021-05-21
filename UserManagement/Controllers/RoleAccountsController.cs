using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Models;
using UserManagement.Repository.Data;

namespace UserManagement.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAccountsController : BaseController<RoleAccounts, RoleAccountRepository, string>
    {
        public RoleAccountsController(RoleAccountRepository roleAccountRepository) : base(roleAccountRepository)
        {

        }
    }
}
