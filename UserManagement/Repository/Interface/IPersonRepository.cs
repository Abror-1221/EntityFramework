using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get();
        IEnumerable<PersonVM> GetListFirstName();
        Person Get(string NIK);
        Person Insert(Person person);
        Person Update(Person person);
        Person Delete(string NIK);
        PersonVM GetFirstName(string NIK);
    }
}
