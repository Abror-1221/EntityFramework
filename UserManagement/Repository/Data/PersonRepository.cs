using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Persons, string>
    {
        public PersonRepository(MyContext conn) : base (conn)
        {

        }
    }
}
