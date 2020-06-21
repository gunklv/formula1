using BLL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Formula1Team> Formula1Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var formula1 = modelBuilder.Entity<Formula1Team>();
            formula1.HasIndex(p => p.Id).IsUnique();

            var user = modelBuilder.Entity<User>();
            user.HasData(
                new User
                { 
                    Id = new System.Guid("5f048b89-2a6d-4c8c-87d6-36af392a0b22"),
                    UserName = "admin",
                    Password = "C3UHzqkH+okmnWowSkCMG1IlR595O5RabswweZpEhSw=",
                    Salt = new byte[] { 89, 85, 85, 51, 253, 91, 26, 26, 167, 189, 72, 116, 17, 165, 33, 168 }
                });

            user.HasIndex(p => p.Id).IsUnique();
        }
    }
}
