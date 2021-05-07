using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<MyContext, Profilings, string>
    {
        public ProfilingRepository(MyContext conn) : base(conn)
        {

        }
    }
}
