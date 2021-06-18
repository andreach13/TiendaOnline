using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    class Contexto: DbContext
    {
        public Contexto(): base("TiendaOnlineBD")
        {

        }

        public DbSet<Producto> Producto { get; set; }
    }
}
