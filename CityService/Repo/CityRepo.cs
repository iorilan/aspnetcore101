using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityService.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CityService.Repo
{
    public class CityDbContext : DbContext
    {
        

        public CityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>().HasData(
            //    new City(){ Id = 1,Name = "A", Country = "AA",PostalCode = "AAA"},
            //    new City() { Id = 2,Name = "B", Country = "BB", PostalCode = "BBB" },
            //    new City() {Id=3, Name = "C", Country = "CC", PostalCode = "CCC" });
        }
    }
}
