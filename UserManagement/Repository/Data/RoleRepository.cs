using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Roles, int>
    {
        public RoleRepository(MyContext conn) : base(conn)
        {

        }
    }
}
