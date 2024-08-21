using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecomendaLivro.Domain.Account.Models;

namespace RecomendaLivro.Shared.Data.DataBase
{
    public class AppDbContext : IdentityDbContext<UserAuthorized, Profile, int>
    {
        public AppDbContext()
        {
        }
        public DbSet<AccountModel> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, como chaves, relações, etc.
        }
    }

}
