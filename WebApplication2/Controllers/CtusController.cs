using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CtusController : Controller
    {
        private readonly NctusContext _context;

        public CtusController(NctusContext context)
        {
            _context = context;
        }

        // GET: Ctus
        public async Task<IActionResult> CtusIndex()
        {
            return View(await _context.Ctus.ToListAsync());
        }

        // GET: Ctus/Details/5
        public async Task<IActionResult> CtusDetails(int? Ctusid)
        {
            if (Ctusid == null) return NotFound();

            var ctu = await _context.Ctus.FirstOrDefaultAsync(m => m.CtuId == Ctusid);
            if (ctu == null) return NotFound();

            return View(ctu);
        }

        // GET: Ctus/Create
        public IActionResult CtusCreate()
        {
            return View();
        }

        // POST: Ctus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CtusCreate([Bind("CtuId,CtuTitle,CtuImage,CtuContent,CtuStatus")] Ctu ctu, IFormFile CtuImage)
        {
            if (ModelState.IsValid)
            {
                if (CtuImage != null && CtuImage.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(CtuImage.FileName);
                    var extension = Path.GetExtension(CtuImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await CtuImage.CopyToAsync(stream);
                    }

                    ctu.CtuImage = "images/" + newFileName;
                }

                _context.Add(ctu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ctu);
        }

        // GET: Ctus/Edit/5
        public async Task<IActionResult> CtusEdit(int? Ctusid)
        {
            if (Ctusid == null) return NotFound();

            var ctu = await _context.Ctus.FindAsync(Ctusid);
            if (ctu == null) return NotFound();

            return View(ctu);
        }

        // POST: Ctus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CtusEdit(int Ctusid, [Bind("CtuId,CtuTitle,CtuImage,CtuContent,CtuStatus")] Ctu ctu, IFormFile CtuImage)
        {
            if (Ctusid != ctu.CtuId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (CtuImage != null && CtuImage.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(CtuImage.FileName);
                        var extension = Path.GetExtension(CtuImage.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        var path = Path.Combine(folderPath, newFileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await CtuImage.CopyToAsync(stream);
                        }

                        ctu.CtuImage = "images/" + newFileName;
                    }

                    _context.Update(ctu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtuExists(ctu.CtuId)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(CtusIndex));
            }

            return View(ctu);
        }

        // GET: Ctus/Delete/5
        public async Task<IActionResult> CtusDelete(int? Ctusid)
        {
            if (Ctusid == null) return NotFound();

            var ctu = await _context.Ctus.FirstOrDefaultAsync(m => m.CtuId == Ctusid);
            if (ctu == null) return NotFound();

            return View(ctu);
        }

        // POST: Ctus/Delete/5
        [HttpPost, ActionName("CtusDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Ctusid)
        {
            var ctu = await _context.Ctus.FindAsync(Ctusid);
            if (ctu != null)
            {
                _context.Ctus.Remove(ctu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtuExists(int Ctusid)
        {
            return _context.Ctus.Any(e => e.CtuId == Ctusid);
        }
    }
}
