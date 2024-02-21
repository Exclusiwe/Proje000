using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Create()
        {
            ViewBag.yoneticis = new SelectList(await _context.yoneticis.ToListAsync(), "Id", "Adi");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Takim model)
        {
            if (ModelState.IsValid)
            {
                // Yeni bir Takim nesnesi oluşturulurken, TakimId özelliği atanır
                var newTakim = new Takim
                {
                    TakimAdi = model.TakimAdi,
                    Id = model.Id // Burada TakimId özelliğinin doğru değeri atanmalıdır
                };

                _context.takims.Add(newTakim);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.yoneticis = new SelectList(await _context.yoneticis.ToListAsync(), "Id", "Adi");
            return View(model);
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
