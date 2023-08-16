using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopiWebRazor_Temp.Models;


namespace ShopiWebRazor_Temp.Data
{
    public class ApplicationDbContext_Razor :DbContext
    {
        public ApplicationDbContext_Razor(DbContextOptions<ApplicationDbContext_Razor> options) : base(options)
        {

        }
         
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "New", DisplayOrder = 10 }
                );
        }

    }
}
