using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.BL;

namespace TiendaOnline.WebAdmin.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesBL _ordenesBL;
        UsuariosBL _usuariosBL;

        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            _usuariosBL = new UsuariosBL();
        }

        // GET: Ordenes
        public ActionResult Index()
        {
            var listadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(listadeOrdenes);
        }

        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var usuarios = _usuariosBL.ObtenerUsuariosActivos();

            ViewBag.UsuarioId = new SelectList(usuarios, "Id", "Nombre");

            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if ( orden.UsuarioId == 0)
                {
                    ModelState.AddModelError("UsuarioId", "Seleccione un Usuario");
                    return View(orden);
                }
                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");
            }

            var usuarios = _usuariosBL.ObtenerUsuariosActivos();
            ViewBag.UsuarioId = new SelectList(usuarios, "Id ", "Nombre");

            return View(orden);
        }

        public ActionResult Editar(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            var usuarios = _usuariosBL.ObtenerUsuariosActivos();

            ViewBag.UsuarioId = new SelectList(usuarios, "Id", "Nombre", orden.UsuarioId);

            return View(orden);
        }

        [HttpPost]
        public ActionResult Editar(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.UsuarioId == 0)
                {
                    ModelState.AddModelError("UsuarioId", "Seleccione un Usuario");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");
            }

            var usuarios = _usuariosBL.ObtenerUsuariosActivos();

            ViewBag.UsuarioId = new SelectList(usuarios, "Id", "Nombre", orden.UsuarioId);

            return View(orden);
        }

        public ActionResult Detalle(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);

            return View(orden);
        }

    }
}