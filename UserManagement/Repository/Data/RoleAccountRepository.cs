using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class RoleAccountRepository : GeneralRepository<MyContext, RoleAccounts, string>
    {
        public RoleAccountRepository(MyContext conn) : base(conn)
        {

        }
    }
}
