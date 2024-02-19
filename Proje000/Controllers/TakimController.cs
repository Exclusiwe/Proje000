using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;

namespace Proje000.Controllers
{
    public class TakimController : Controller
    {
        private readonly DataContext _context;
        public TakimController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var takims = await _context.takims.ToListAsync();
            return View(takims);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Takim model)
        {
            _context.takims.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var tkm = await _context.takims.FindAsync(Id);
            if (tkm == null)
            {
                return NotFound();

            }
            return View(tkm);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken] güvenlik önmeli başkasının senin yerine değişiklik ypamasını engeller kullanılabilir 
        public async Task<IActionResult> Edit(int id, Takim model)
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
                    if (!_context.takims.Any(t => t.Id == model.Id))
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
    }
}
