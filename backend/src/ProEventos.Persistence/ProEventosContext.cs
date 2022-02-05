using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence{

    public class ProEventosContext : DbContext {

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //configurando chaves da entidade composta
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(x => new { x.EventoId, x.PalestranteId});
        }
    }
}