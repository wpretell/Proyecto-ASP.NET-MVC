using Microsoft.AspNetCore.Mvc;
using MiTiendaVirtual.Models;

namespace MiTiendaVirtual.Controllers

{
    public class Clientescontroller : Controller
    {
        public IActionResult Index()
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            using (TiendaVirtualDbContext BD = new TiendaVirtualDbContext())
            {

                ListaClientes = (from c in BD.Cliente
                                 orderby c.Nombres, c.Apellidos
                                 select new Cliente
                                 {
                                     Id = c.Id,
                                     Nombres = c.Nombres,
                                     Apellidos = c.Apellidos,
                                     Dni = c.Dni,
                                     Telefono = c.Telefono,
                                     Correo = c.Correo,
                                     Direccion = c.Direccion
                                 }).ToList();

            }
            return View(ListaClientes);

        }
    }
}
