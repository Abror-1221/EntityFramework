using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Accounts, string>
    {
        public AccountRepository(MyContext conn) : base(conn)
        {

        }
    }
}
