using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemAppNetCore.Models
{
    public class Person
    {
        //id, firstName,LastName, Address
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

    }

    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options):base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        //constructor, dbset
    }
}
