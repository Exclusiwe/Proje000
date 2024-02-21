using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje000.Data;

namespace Proje000.Controllers
{
public class PersonelController : Controller
    {
    private readonly DataContext _context;
    public PersonelController(DataContext context)
        {
         _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.personels.ToListAsync());
        }
    public IActionResult Create()
        {
        return View();
        }
    [HttpPost]
    public async Task <IActionResult> Create(Personel model) 
        { 
         _context.personels.Add(model); 
          await  _context.SaveChangesAsync();

        return RedirectToAction("Index");
        }
        public async Task<ActionResult>Edit(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var prs = await _context.personels.FindAsync(Id);
            if (prs == null)
            {
                return NotFound();

            }
            return View(prs);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken] güvenlik önmeli başkasının senin yerine değişiklik ypamasını engeller kullanılabilir 
        public async Task<IActionResult> Edit(int id, Personel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!_context.personels.Any(p => p.Id == model.Id))
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
            if(id == null)
            {
                return NotFound();
            }
            var personel = await _context.personels.FindAsync(id);

            if(personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var personel = await _context.personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            _context.personels.Remove(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
            


    }
}

