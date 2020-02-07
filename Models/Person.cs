using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemAppNetCore.Models
{
    public class Person
    {
      
    }

    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options):base(options)
        {
                
        }

        public DbSet<Person> People{ get; set; }
    }
}
