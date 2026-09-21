using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {
                listaPedidos = (from p in BD.Pedido
                                orderby p.FechaHora
                                select new Pedido
                                {
                                    Id = p.Id,
                                    FechaHora = p.FechaHora,
                                    Total = p.Total,
                                    Estado = p.Estado
                                }).ToList();
            }

            return View(listaPedidos);
        }
    }
}
