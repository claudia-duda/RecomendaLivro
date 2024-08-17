using Microsoft.EntityFrameworkCore;
using RecomendaLivroApi.Domain.Interface;

namespace RecomendaLivro.Shared.Data.DataBase
{

    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Book> Book { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }
    }
}
