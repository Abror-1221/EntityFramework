using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;
using UserManagement.ViewModels;

namespace UserManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        public  PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }

        //COBA2 DELETE SYNTAX
        public Persons Delete(string NIK)
        {
            var delPerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(delPerson);
            var result = conn.SaveChanges();
            return delPerson;
        }

        public IEnumerable<Persons> Get()
        {
            IEnumerable<Persons> persons = new List<Persons>();
            persons = conn.Persons.ToList();
            return persons;
        }

        public Persons Get(string NIK)
        {
            var person = conn.Persons.Find(NIK);
            return person;
        }

        public PersonVM GetFirstName(string NIK)
        {
            var cek = conn.Persons.Find(NIK);
            PersonVM personvm = new PersonVM();
            personvm.FirstName = cek.FirstName;
            personvm.NIK = cek.NIK;
            return personvm;
        }

        public IEnumerable<PersonVM> GetListFirstName()
        {
            IEnumerable<Persons> persons = conn.Persons.ToList();
            List<PersonVM> personsvm = new List<PersonVM>();
            foreach (var item in persons)
            {
                PersonVM personList = new PersonVM();
                personList.FirstName = item.FirstName;
                personList.NIK = item.NIK;
                personsvm.Add(personList);
            }
            return personsvm;
        }

        public Persons Insert(Persons person)
        {
            conn.Persons.Add(person);
            var result = conn.SaveChanges();
            return person;
        }

        //public int Update(Person person)
        //{
        //    conn.Persons.Update(person);
        //    var result = conn.SaveChanges();
        //    return result;
        //}

        //entitystate.modified
        public Persons Update(Persons person)
        {
            conn.Entry(person).State = EntityState.Modified;
            var result = conn.SaveChanges();
            return person;
        }

    }
}
