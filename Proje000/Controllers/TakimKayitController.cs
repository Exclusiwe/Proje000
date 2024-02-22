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
        public async Task<IActionResult> Index()
        {
            var takimK = await _context.takimkayits
                .Include(x => x.Personel)
                .Include(x => x.Takim)
                .Include (x => x.Vardiya)
                .Include(x => x.Yonetici)
                .ToListAsync();
            return View(takimK);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var personList = await _context.personels
                .Select(p => new SelectListItem
                {
                    Text = p.Adi, // veya diğer bir isim alanı
                    Value = p.Id.ToString() // veya diğer bir benzersiz kimlik alanı
                })
                .ToListAsync();

            var takimList = await _context.takims
                .Select(t => new SelectListItem
                {
                    Text = t.TakimAdi, 
                    Value = t.Id.ToString() 
                })
                .ToListAsync();
            var vardiyaList = await _context.vardiyas
                .Select(v => new SelectListItem
                {
                    Text = v.VardiyaName, // veya diğer bir isim alanı
                    Value = v.Id.ToString() // veya diğer bir benzersiz kimlik alanı
                })
                .ToListAsync();
            var yoneticiList = await _context.yoneticis
                .Select(v => new SelectListItem
                {
                    Text = v.Adi, // veya diğer bir isim alanı
                    Value = v.Id.ToString() // veya diğer bir benzersiz kimlik alanı
                })
                .ToListAsync();

            ViewBag.personels = new SelectList(personList, "Value", "Text");
            ViewBag.takims = new SelectList(takimList, "Value", "Text");
            ViewBag.vardiyas = new SelectList(vardiyaList, "Value", "Text");
            ViewBag.yoneticis = new SelectList(yoneticiList, "Value", "Text");



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (TakimKayit model)
        {
            _context.takimkayits.Add(model);   
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? Id)
        {
            var personList = await _context.personels
               .Select(p => new SelectListItem
               {
                   Text = p.Adi, // veya diğer bir isim alanı
                   Value = p.Id.ToString() // veya diğer bir benzersiz kimlik alanı
               })
               .ToListAsync();

            var takimList = await _context.takims
                .Select(t => new SelectListItem
                {
                    Text = t.TakimAdi,
                    Value = t.Id.ToString()
                })
                .ToListAsync();
            var vardiyaList = await _context.vardiyas
                .Select(v => new SelectListItem
                {
                    Text = v.VardiyaName, // veya diğer bir isim alanı
                    Value = v.Id.ToString() // veya diğer bir benzersiz kimlik alanı
                })
                .ToListAsync();
            var yoneticiList = await _context.yoneticis
                .Select(v => new SelectListItem
                {
                    Text = v.Adi, // veya diğer bir isim alanı
                    Value = v.Id.ToString() // veya diğer bir benzersiz kimlik alanı
                })
                .ToListAsync();

            ViewBag.personels = new SelectList(personList, "Value", "Text");
            ViewBag.takims = new SelectList(takimList, "Value", "Text");
            ViewBag.vardiyas = new SelectList(vardiyaList, "Value", "Text");
            ViewBag.yoneticis = new SelectList(yoneticiList, "Value", "Text");



            //return View();
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken] güvenlik önmeli başkasının senin yerine değişiklik ypamasını engeller kullanılabilir 
        public async Task<IActionResult> Edit(int id, TakimKayit model)
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
                    if (!_context.takimkayits.Any(p => p.Id == model.Id))
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
            var takimKayit = await _context.takimkayits.FindAsync(id);

            if (takimKayit == null)
            {
                return NotFound();
            }
            return View(takimKayit);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var takimKayit = await _context.takimkayits.FindAsync(id);
            if (takimKayit == null)
            {
                return NotFound();
            }
            _context.takimkayits.Remove(takimKayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
      


