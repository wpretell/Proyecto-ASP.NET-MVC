using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                listaProductos = (from p in BD.Producto select p).ToList();
            }

            return View(listaProductos);

        }
    }
}
