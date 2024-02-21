using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;

namespace Proje000.Controllers
{
    public class VardiyaController : Controller
    {
        private readonly DataContext _context;
        public VardiyaController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var vardiya = await _context.vardiyas.ToListAsync();
            return View(vardiya);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vardiya model)
        {
            _context.vardiyas.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var tkm = await _context.vardiyas.FindAsync(Id);
            if (tkm == null)
            {
                return NotFound();

            }
            return View(tkm);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken] güvenlik önmeli başkasının senin yerine değişiklik ypamasını engeller kullanılabilir 
        public async Task<IActionResult> Edit(int id, Vardiya model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.vardiyas.Any(t => t.Id == model.Id))
                    {
                        return BadRequest();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vardiya = await _context.vardiyas.FindAsync(id);

            if (vardiya == null)
            {
                return NotFound();
            }
            return View(vardiya);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var vardiya = await _context.vardiyas.FindAsync(id);
            if (vardiya == null)
            {
                return NotFound();
            }
            _context.vardiyas.Remove(vardiya);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}
    

