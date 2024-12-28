using diary_webapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace diary_webapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(new DiaryEntry
            {
                Id = 1,
                Title = "Coding 24/7",
                Content = "I have been coding since 2022",
                Created = DateTime.Now
            },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "Gaming 24/7",
                    Content = "I have been playing games since 2012",
                    Created = DateTime.Now
                }
            );
        }
    }
}