using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;

namespace Proje000.Controllers
{
    public class TakimKayitController : Controller
    {
        private readonly DataContext _context;
        public TakimKayitController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TakimKayit model)
        {
            _context.takimkayits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var tkm = await _context.takimkayits.FindAsync(Id);
            if (tkm == null)
            {
                return NotFound();

            }
            return View(tkm);
        }
        [HttpPost]
  
        public async Task<IActionResult> Edit(int id, TakimKayit model)
        {
            if (id != model.TakimKayitId)
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
                    if (!_context.takimkayits.Any(p => p.TakimKayitId == model.TakimKayitId))
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
            var takimkayit = await _context.takimkayits.FindAsync(id);

            if (takimkayit == null)
            {
                return NotFound();
            }
            return View(takimkayit);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var takimkayit = await _context.takimkayits.FindAsync(id);
            if (takimkayit == null)
            {
                return NotFound();
            }
            _context.takimkayits.Remove(takimkayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}






