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
        IEnumerable<Persons> Get();
        IEnumerable<PersonVM> GetListFirstName();
        Persons Get(string NIK);
        Persons Insert(Persons person);
        Persons Update(Persons person);
        Persons Delete(string NIK);
        PersonVM GetFirstName(string NIK);
    }
}
