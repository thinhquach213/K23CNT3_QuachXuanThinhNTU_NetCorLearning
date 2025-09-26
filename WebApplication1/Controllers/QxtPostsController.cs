using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QxtPostsController : Controller
    {
        private readonly Qxtk23cnttLesson12Context _context;

        public QxtPostsController(Qxtk23cnttLesson12Context context)
        {
            _context = context;
        }

        // GET: QxtPosts
        public async Task<IActionResult> QxtIndex()
        {
            return View(await _context.QxtPosts.ToListAsync());
        }

        // GET: QxtPosts/Details/5
        public async Task<IActionResult> QxtDetails(int? QxtId)
        {
            if (QxtId == null)
            {
                return NotFound();
            }

            var qxtPost = await _context.QxtPosts
                .FirstOrDefaultAsync(m => m.QxtId == QxtId);
            if (qxtPost == null)
            {
                return NotFound();
            }

            return View(qxtPost);
        }

        // GET: QxtPosts/Create
        public IActionResult QxtCreate()
        {
            return View();
        }

        // POST: QxtPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtCreate([Bind("QxtId,QxtTitle,QxtImage,QxtContent,QxtStatus")] QxtPost qxtPost, IFormFile QxtImage)
        {
            if (ModelState.IsValid)
            {
                if (QxtImage != null && QxtImage.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(QxtImage.FileName);
                    var extension = Path.GetExtension(QxtImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await QxtImage.CopyToAsync(stream);
                    }

                    qxtPost.QxtImage = "images/" + newFileName;
                }

                _context.Add(qxtPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(QxtIndex));
            }
            return View(qxtPost);
        }

        // GET: QxtPosts/Edit/5
        public async Task<IActionResult> QxtEdit(int? QxtId)
        {
            if (QxtId == null)
            {
                return NotFound();
            }

            var qxtPost = await _context.QxtPosts.FindAsync(QxtId);
            if (qxtPost == null)
            {
                return NotFound();
            }
            return View(qxtPost);
        }

        // POST: QxtPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtEdit(int QxtId, [Bind("QxtId,QxtTitle,QxtImage,QxtContent,QxtStatus")] QxtPost qxtPost, IFormFile QxtImage)
        {
            if (QxtId != qxtPost.QxtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (QxtImage != null && QxtImage.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(QxtImage.FileName);
                        var extension = Path.GetExtension(QxtImage.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);
                        var path = Path.Combine(folderPath, newFileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await QxtImage.CopyToAsync(stream);
                        }

                        qxtPost.QxtImage = "images/" + newFileName;
                    }

                    _context.Update(qxtPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QxtPostExists(qxtPost.QxtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(QxtIndex));
            }
            return View(qxtPost);
        }

        // GET: QxtPosts/Delete/5
        public async Task<IActionResult> QxtDelete(int? QxtId)
        {
            if (QxtId == null)
            {
                return NotFound();
            }

            var qxtPost = await _context.QxtPosts
                .FirstOrDefaultAsync(m => m.QxtId == QxtId);
            if (qxtPost == null)
            {
                return NotFound();
            }

            return View(qxtPost);
        }

        // POST: QxtPosts/Delete/5
        [HttpPost, ActionName("QxtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtDeleteConfirmed(int QxtId)
        {
            var qxtPost = await _context.QxtPosts.FindAsync(QxtId);
            if (qxtPost != null)
            {
                _context.QxtPosts.Remove(qxtPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(QxtIndex));
        }

        private bool QxtPostExists(int QxtId)
        {
            return _context.QxtPosts.Any(e => e.QxtId == QxtId);
        }
    }
}
