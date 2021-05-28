using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using WebApplication1.Base;
using WebApplication1.Repository.Data;

namespace WebApplication1.Controllers
{
    public class AccountsController : BaseController<Accounts, AccountRepository, string>
    {
        private readonly AccountRepository repository;

        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUserData()
        {
            var result = await repository.GetUserData();
            return Json(result);
        }
    }
}
