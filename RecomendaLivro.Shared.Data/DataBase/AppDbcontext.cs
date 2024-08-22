using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecomendaLivro.Domain.Account.Models;

namespace RecomendaLivro.Shared.Data.DataBase
{
    public class AppDbContext : IdentityDbContext<UserAuthorized, Profile, int>
    {
        public DbSet<Account> Account { get; set; }
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=RecomendaLivro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>();
        }
    }

}
