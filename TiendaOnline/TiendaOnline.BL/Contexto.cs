using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDBFilename = "  +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop ) +  @"\TiendaOnlineDB.mdf ")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio()); // Agrega los datos de inincio al momento de la creacion de la base de datos
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> OrdenDetalle { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
