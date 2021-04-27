using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Repository.Interface;
using UserManagement.ViewModels;

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
        [Route("Insert")]
        public ActionResult Insert(Person person)
        {
            personRepository.Insert(person);
            return Ok();
        }

        [HttpPost("Insert2")]
        //[Route("Insert2")]
        public ActionResult Insert2(Person person)
        {
            personRepository.Insert(person);
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Person> persons = personRepository.Get();
            return Ok(persons);
        }
        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            var person = personRepository.Get(NIK);
            return Ok(person);
        }
        [HttpGet("GetFirstName/{NIK}")]
        public ActionResult GetFirstName(string NIK)
        {
            PersonVM person = personRepository.GetFirstName(NIK);
            return Ok(person);
        }

        [HttpGet("GetListFirstName")]
        public ActionResult GetListFirstName()
        {
            IEnumerable<PersonVM> personsvm = personRepository.GetListFirstName();
            return Ok(personsvm);
        }

        //COBA2 DELETE SYNTAX
        //[HttpDelete]
        public ActionResult Delete(string NIK)
        {
            personRepository.Delete(NIK);
            return Ok();
        }

        //[HttpPut]
        public ActionResult Update(Person person)
        {
            personRepository.Update(person);
            return Ok();
        }
        
    }
}
