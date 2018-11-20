using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository.Context
{
    public class ServerContext : DbContext
    {

        //Enable-Migrations - Na primeira vez, para habilitar o migration
        //Add-Migration init_db - A cada nova migration
        //Update-Database - sempre depois de rodar o add migration
        private const string ConnectionStringName = "Name=ConnectionString";

        public ServerContext() : base(ConnectionStringName)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar").HasMaxLength(250));
            
        }
    }
}
