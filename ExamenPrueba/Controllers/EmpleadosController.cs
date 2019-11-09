using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenPrueba.Models;

namespace ExamenPrueba.Controllers
{
    public class EmpleadosController : Controller
    {
        private TiendaContext _context;
        public EmpleadosController(TiendaContext x) {
            _context = x;
        }

        public IActionResult Index()
        {
            //var lista = _context.Empleados.Include(x => x.Categoria).ToList();
            return View();
        }

        public IActionResult Registrar()
        {
            ViewBag.Categorias = _context.Empleados.ToList();
            return View();
        }        

        [HttpPost]
        public IActionResult Registrar(Empleado x)
        {
            ViewBag.Categorias = _context.Empleados.ToList();
            
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }
    }
}