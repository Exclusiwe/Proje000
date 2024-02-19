using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;

namespace Proje000.Controllers
{
    public class YoneticiController : Controller
    {
        private readonly DataContext _context;
        public YoneticiController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.yoneticils.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Yonetici model)
        {
            _context.yoneticils.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var prs = await _context.yoneticils.FindAsync(Id);
            if (prs == null)
            {
                return NotFound();

            }
            return View(prs);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken] güvenlik önmeli başkasının senin yerine değişiklik ypamasını engeller kullanılabilir 
        public async Task<IActionResult> Edit(int id, Yonetici model)
        {
            if (id != model.YoneticiId)
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
                    if (!_context.yoneticils.Any(y => y.YoneticiId == model.YoneticiId))
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
            var yonetic = await _context.yoneticils.FindAsync(id);

            if (yonetic == null)
            {
                return NotFound();
            }
            return View(yonetic);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var yonetici = await _context.yoneticils.FindAsync(id);
            if (yonetici == null)
            {
                return NotFound();
            }
            _context.yoneticils.Remove(yonetici);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}


