using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Repository.Interface;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonRepository personRepository;
        public PersonsController(PersonRepository person)
        {
            this.personRepository = person;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            personRepository.insert(person);
            return Ok();
        }

        ////[HttpGet]
        //public ActionResult Get()
        //{
        //    IEnumerable<Person> persons = personRepository.Get();
        //    return Ok(persons);
        //}
        [HttpGet]
        public ActionResult Get(string NIK)
        {
            var person = personRepository.Get(NIK);
            return Ok(person);
        }

        //COBA2 DELETE SYNTAX
        [HttpDelete]
        public ActionResult GetActionResult(string NIK)
        {
            personRepository.delete(NIK);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            personRepository.update(person);
            return Ok();
        }
    }
}
