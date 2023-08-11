using Microsoft.EntityFrameworkCore;
using ShopiWeb.Models.Models;

namespace ShopiWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
