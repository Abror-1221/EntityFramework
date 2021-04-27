using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Post(Person person)
        {
            return Ok(personRepository.Insert(person));
        }

        [HttpPost("Insert")]
        //[Route("Insert2")]
        public ActionResult Post2(Person person)
        {
            return Ok(personRepository.Insert(person));
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
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound("Error : NIK not found!!");
            }
            
        }
        [HttpGet("GetFirstName/{NIK}")]
        public ActionResult GetFirstName(string NIK)
        {
            PersonVM person = personRepository.GetFirstName(NIK);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound("Error : NIK not found!!");
            }
        }

        [HttpGet("GetListFirstName")]
        public ActionResult GetListFirstName()
        {
            IEnumerable<PersonVM> personsvm = personRepository.GetListFirstName();
            return Ok(personsvm);
        }

        //COBA2 DELETE SYNTAX
        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            var person = personRepository.Get(NIK);
            if (person != null)
            {
                return Ok(personRepository.Delete(NIK));
            }
            else
            {
                return NotFound("Error : NIK not found!!");
            }             
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            try
            {
                return Ok(personRepository.Update(person));
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.NotModified, message = "Error : Data not updated" });
            }
                                
        }       
    }
}
