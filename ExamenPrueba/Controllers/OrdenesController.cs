using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenPrueba.Models;

namespace ExamenPrueba.Controllers
{
    public class OrdenesController : Controller
    {
        private TiendaContext _context;
        public OrdenesController(TiendaContext x) {
            _context = x;
        }

        public IActionResult Index()
        {
            //var lista = _context.Ordenes.Include(x => x.Categoria).ToList();
            return View();
        }

        public IActionResult Registrar()
        {
            ViewBag.Categorias = _context.Ordenes.ToList();
            return View();
        }        

        [HttpPost]
        public IActionResult Registrar(Orden x)
        {
            ViewBag.Categorias = _context.Ordenes.ToList();
            
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }
    }
}