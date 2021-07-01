using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.BL;

namespace TiendaOnline.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;

        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var ListadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(ListadeCategorias);
        }


        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim()) //trim quita los espacio al inciio y final de lo que se escriba
                {
                    //error personalizado, agregue un error al modelo, especifico la propiedad y el mensaje
                    ModelState.AddModelError("Descripcion", "La Descripcion no debe iniciar ni finalizar con espacios ");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim()) //trim quita los espacio al inciio y final de lo que se escriba
                {
                    //error personalizado, agregue un error al modelo, especifico la propiedad y el mensaje
                    ModelState.AddModelError("Descripcion", "La Descripcion no debe iniciar ni finalizar con espacios ");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}