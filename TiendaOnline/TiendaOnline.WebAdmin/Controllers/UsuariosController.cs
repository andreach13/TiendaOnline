using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.BL;

namespace TiendaOnline.WebAdmin.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosBL _usuariosBL;

        public UsuariosController()
        {
            _usuariosBL = new UsuariosBL();
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var listadeUsuarios = _usuariosBL.ObtenerUsuarios();

            return View(listadeUsuarios);
        }
        public ActionResult Crear()
        {
            var nuevoUsuario = new Usuario();

            return View(nuevoUsuario);
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuariosBL.GuardarUsuario(usuario);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuario(id);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuariosBL.GuardarUsuario(usuario);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //****
        public ActionResult Detalle(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuario(id);

            return View(usuario);
        }

        public ActionResult Eliminar(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuario(id);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Eliminar(Usuario usuario)
        {
            _usuariosBL.EliminarUsuario(usuario.Id);

            return RedirectToAction("Index");
        }
    }
}