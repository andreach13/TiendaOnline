using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class UsuariosBL
    {
        Contexto _contexto;
        public List<Usuario> ListadeUsuarios { get; set; }

        public UsuariosBL()
        {
            _contexto = new Contexto();
            ListadeUsuarios = new List<Usuario>();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            ListadeUsuarios = _contexto.Usuarios
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListadeUsuarios;
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            ListadeUsuarios = _contexto.Usuarios
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListadeUsuarios;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                _contexto.Usuarios.Add(usuario);
            }
            else
            {
                var usuarioExistente = _contexto.Usuarios.Find(usuario.Id);
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Telefono= usuario.Telefono;
                usuarioExistente.Direccion = usuario.Direccion ;
                usuarioExistente.Activo = usuario.Activo;
            }
            _contexto.SaveChanges();
        }

        public Usuario ObtenerUsuario(int id)
        {
            var usuario = _contexto.Usuarios.Find(id);
            return usuario;
        }
        

        public void EliminarUsuario(int id)
        {
            var usuario = _contexto.Usuarios.Find(id);

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }
    }
}
