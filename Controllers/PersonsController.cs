using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemAppNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemAppNetCore.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private readonly PersonDbContext _personDbContext;

        public PersonsController(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public IActionResult Index()
        {
            var persons = _personDbContext.Persons.ToList();
            return View(persons);
        }

        [HttpGet("Save")]
        public IActionResult Save()
        {
            var random = new Random();
            var randomNumber = random.Next(0,100);
            var person = new Person
            {
                FirstName = "FirstName" + randomNumber,
                LastName = "LastName" + randomNumber,
                Address = "Address" + randomNumber
            };
            _personDbContext.Persons.Add(person);
            _personDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //update

        [HttpGet("update/{id}")]
        public IActionResult UpdatePerson(int id)
        {
            var personInDb = _personDbContext.Persons.FirstOrDefault(x => x.Id == id);
            if (personInDb == null)
            {
                return BadRequest();
            }

            personInDb.FirstName += "Updated";
            personInDb.LastName += "Updated";
            personInDb.Address += "Updated";
            _personDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //delete

        [HttpGet("delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            var personInDb = _personDbContext.Persons.FirstOrDefault(x => x.Id == id);
            if (personInDb == null)
            {
                return BadRequest();
            }

            _personDbContext.Persons.Remove(personInDb);
            _personDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}