using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataStore.EF
{
    // DbContext represents our database in memory
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions options) : base(options)
        {

        }

        // each DbSet represents a database table
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // in this method we define the database schema/relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(prj => prj.Tickets)
                .WithOne(tkt => tkt.Project)
                .HasForeignKey(tkt => tkt.ProjectId);

            // seeding data
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Project 1" },
                new Project { ProjectId = 2, Name = "Project 2" }
            );
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Title = "Bug #1", ProjectId = 1 },
                new Ticket { TicketId = 2, Title = "Bug #2", ProjectId = 1 },
                new Ticket { TicketId = 3, Title = "Bug #3", ProjectId = 2 }
            );

        }
    }
}
