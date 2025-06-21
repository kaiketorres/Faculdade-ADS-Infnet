using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Models; 

namespace AgenciaTurismo.Data
{
    public class AgenciaTurismoContext : DbContext
    {
        public AgenciaTurismoContext(DbContextOptions<AgenciaTurismoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PaisDestino> PaisesDestino { get; set; }
        public DbSet<CidadeDestino> CidadesDestino { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristico { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.CidadesDestino)
                .WithMany(c => c.PacotesTuristicos);

           
            base.OnModelCreating(modelBuilder);
        }
    }
}