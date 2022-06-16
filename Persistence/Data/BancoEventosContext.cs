using Domain;
using Domain.Modesl;
using Microsoft.EntityFrameworkCore;


namespace Repositorio.Data
{
    public class BancoEventosContext : DbContext
    {
        public BancoEventosContext(DbContextOptions<BancoEventosContext> options) : base(options)
        {

        }

        public DbSet<EventoModel> Eventos { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<RedeSocial> RedesSociais { get; set; }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<EventoModel>().HasMany(e => e.RedeSociais)
                .WithOne(r => r.Evento)
                .HasForeignKey(r => r.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>().HasMany(e => e.RedeSociais)
                .WithOne(r => r.Palestrante)
                // 
                .HasForeignKey(r => r.PalestranteId)
                .OnDelete(DeleteBehavior.Cascade);    
        }
    }
}
