using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "Mabel";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");
            nuevoUsuario.Direccion = "Server";
            nuevoUsuario.Telefono = "000000001";

            nuevoUsuario.Nombre = "Andrea";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");
            nuevoUsuario.Direccion = "Server";
            nuevoUsuario.Telefono = "000000002";

            nuevoUsuario.Nombre = "Dany";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");
            nuevoUsuario.Direccion = "Server";
            nuevoUsuario.Telefono = "00000003";

            contexto.Usuarios.Add(nuevoUsuario);

            base.Seed(contexto);
        }

        //protected override void Seed(Contexto contexto)
        //{
        //    var nuevoUser = new User();
        //    nuevoUser.Name = "admin";
        //    nuevoUser.Password = Encriptar.CodificarContrasena("123");

        //    contexto.Users.Add(nuevoUser);

        //    base.Seed(contexto);
        //}
    }
}
