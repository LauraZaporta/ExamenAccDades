using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Models;
using Microsoft.Extensions.Configuration;


namespace EntityFrameworkExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        //DbSet representa una col·lecció de registres (taula) de la base de dades que corresponen a
        //la classe User. A través d'aquesta propietat, Entity Framework permet realitzar operacions
        //sobre la taula Users a la base de dades.
        public DbSet<User> Users { get; set; }

        //Configura la cadena de connexió i la connexió
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connString);
        }
    }
}
