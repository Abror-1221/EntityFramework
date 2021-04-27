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
        int Insert(Person person);
        int Update(Person person);
        int Delete(string NIK);
        PersonVM GetFirstName(string NIK);
    }
}
