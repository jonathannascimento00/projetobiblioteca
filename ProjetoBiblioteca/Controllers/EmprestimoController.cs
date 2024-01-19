using BibliotecaJoia2.Data;
using BibliotecaJoia2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaJoia2.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id is null){
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x =>  x.Id == id);
            
            if(emprestimo is null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        public IActionResult Excluir(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            
            if(emprestimo is null)
            {
                return NotFound();
            }

            return View(emprestimo);

        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Remove(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
