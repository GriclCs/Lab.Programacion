using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenPrueba.Models;

namespace ExamenPrueba.Controllers
{
    public class ClientesController : Controller
    {
        private TiendaContext _context;
        public ClientesController(TiendaContext x) {
            _context = x;
        }

        public IActionResult Index()
        {
            //var lista = _context.Clientes.Include(x => x.Clientes).ToList();
            return View();
        }

        public IActionResult Registrar()
        {
            ViewBag.Categorias = _context.Clientes.ToList();
            return View();
        }        

        [HttpPost]
        public IActionResult Registrar(Cliente x)
        {
            ViewBag.Categorias = _context.Clientes.ToList();
            
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }
    }
}