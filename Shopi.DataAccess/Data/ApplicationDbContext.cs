﻿using Microsoft.EntityFrameworkCore;
using Shopi.Models;

namespace Shopi.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = 1, Name= "Action" , DisplayOrder = 1},
                new Category { Id =2, Name = "History" , DisplayOrder = 2}
                );
        }
    }
}
