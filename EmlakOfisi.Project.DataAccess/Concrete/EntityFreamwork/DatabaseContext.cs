using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmlakOfisi.Project.DataAccess.Concrete.EntityFreamwork
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=00P51198\SQLEXPRESS;Database=EmlakOfisi;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure());
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Room> Rooms { get; set; }



    }
}
