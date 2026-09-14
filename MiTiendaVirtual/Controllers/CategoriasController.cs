using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class CategoriasController : Controller
    {
        public String Index()
        {
            String mensaje = "Responde el metodo 'Index()' del Controlador 'Categorias'";
            return mensaje;
        }

        public IActionResult MostrarCategoria(int Id)
        {
            Categoria categoria = new Categoria();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                var listaCategorias = (from c in BD.Categoria
                                       where c.Id == Id
                                       select new Categoria
                                       {
                                           Id = c.Id,
                                           Nombre = c.Nombre,
                                           Activo = c.Activo

                                       }).ToList();

                if (listaCategorias.Count > 0)
                {
                    categoria = listaCategorias.First();
                    ViewData["activo"] = categoria.Activo.GetValueOrDefault() ? "Si" : "No";
                }
            }

            return View(categoria);
        }
    }
}
