using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class TarjetasController : Controller
    {
        public IActionResult Index()
        {
            List<Tarjeta> listaTarjetas = new List<Tarjeta>();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                listaTarjetas = (from t in BD.Tarjeta
                                 orderby t.Marca
                                 select new Tarjeta
                                 {
                                     Id = t.Id,
                                     Marca = t.Marca,
                                     Numero = t.Numero,
                                 }).ToList();
            }

            return View(listaTarjetas);
        }
    }
}
