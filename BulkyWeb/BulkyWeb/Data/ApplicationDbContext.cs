using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Buffers.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    // DbContext is the base class in EF Core used to interact with the database.
    // ApplicationDbContext is your custom context that tells EF Core what entities (tables) to track and how to configure them.

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
            //This constructor accepts DbContextOptions and passes it to the base class. These options (like connection strings, provider info, etc.)
            //are configured in Program.cs or Startup.cs.This is Dependency Injection in action — the framework injects the required options when the app starts.
        {
                
        }

        public DbSet<Category> Categories{ get; set; }
        // DbSet<Category> tells EF Core to create or map a table called Categories in the database.
       // The Category class (from BulkyWeb.Models) defines the schema for this table(properties like Id, Name, DisplayOrder).



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
        // OnModelCreating is where you can configure your entity models.
        //  HasData() is used to seed initial data into the Categories table when you run Update-Database via EF Core Migrations.
        //  These entries are inserted only once when the migration is applied, and EF checks whether they exist based on primary key



    }
}
