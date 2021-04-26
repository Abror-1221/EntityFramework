using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;

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
        public int delete(string NIK)
        {
            var delPerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(delPerson);
            var result = conn.SaveChanges();
            return result;
        }

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();
            return persons;
        }

        public Person Get(string NIK)
        {
            var person = conn.Persons.Find(NIK);
            return person;
        }

        public int insert(Person person)
        {
            conn.Persons.Add(person);
            var result = conn.SaveChanges();
            return result;
        }

        public int update(Person person)
        {
            conn.Persons.Update(person);
            var result = conn.SaveChanges();
            return result;
        }
    }
}
