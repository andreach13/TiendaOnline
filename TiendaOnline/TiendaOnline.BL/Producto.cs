using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Ingrese descripcion del producto")]
        [MinLength (3,ErrorMessage = "Ingrese minimo 3 caracteres" )]
        [MaxLength(80, ErrorMessage = "Ingrese un maximo de 80 caracteres")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0,10000000, ErrorMessage ="Ingrese un precio mayor a 0")]
        public double Precio { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
