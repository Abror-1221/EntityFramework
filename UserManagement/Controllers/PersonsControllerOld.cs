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
    public class PersonsControllerOld : ControllerBase
    {
        private readonly PersonRepository personRepository;
        public PersonsControllerOld(PersonRepository person)
        {
            this.personRepository = person;
        }

        [HttpPost]
        public ActionResult Post(Persons person)
        {
            try
            {
                return Ok(personRepository.Insert(person));
            }
            catch (Exception)
            {
                return StatusCode(400, new {status = HttpStatusCode.Forbidden, message = "Error : Column name doesn't match and NIK column is null!!" });
            }
        }

        [HttpPost("Insert")]
        //[Route("Insert2")]
        public ActionResult Post2(Persons person)
        {
            try
            {
                return Ok(personRepository.Insert(person));
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Column name doesn't match and NIK column is null!!" });
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Persons> persons = personRepository.Get();
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
                return NotFound("Error : The NIK that wanted to delete was not found!!");
            }             
        }

        [HttpPut]
        public ActionResult Update(Persons person)
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
