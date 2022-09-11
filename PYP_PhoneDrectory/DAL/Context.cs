using Microsoft.EntityFrameworkCore;
using PYP_PhoneDrectory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=DESKTOP-FHK353D;Database=PhoneDirectory;Integrated Security=True; MultipleActiveResultSets=true");
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.Surname).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<Contact>().Property(x => x.Email).IsRequired();
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
