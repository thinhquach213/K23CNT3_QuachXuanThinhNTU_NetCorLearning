using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuachXuanThinh_2310900100_de05.Models;

namespace QuachXuanThinh_2310900100_de05.Controllers
{
    public class QxtTasksController : Controller
    {
        private readonly QuachXuanThinh2310900100De05Context _context;

        public QxtTasksController(QuachXuanThinh2310900100De05Context context)
        {
            _context = context;
        }

        // GET: QxtTasks
        public async Task<IActionResult> QxtIndex()
        {
            return View(await _context.QxtTasks.ToListAsync());
        }

        // GET: QxtTasks/Details/5
        public async Task<IActionResult> QxtDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _context.QxtTasks.FirstOrDefaultAsync(m => m.QxtTaskId == id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // GET: QxtTasks/Create
        public IActionResult QxtCreate()
        {
            return View();
        }

        // POST: QxtTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtCreate([Bind("QxtTaskId,QxtTaskName,QxtTaskLevel,QxtStartDate,QxtTaskStatus")] QxtTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(QxtIndex));
            }
            return View(task);
        }

        // GET: QxtTasks/Edit/5
        public async Task<IActionResult> QxtEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _context.QxtTasks.FindAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // POST: QxtTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtEdit(int id, [Bind("QxtTaskId,QxtTaskName,QxtTaskLevel,QxtStartDate,QxtTaskStatus")] QxtTask task)
        {
            if (id != task.QxtTaskId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QxtTaskExists(task.QxtTaskId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(QxtIndex));
            }
            return View(task);
        }

        // GET: QxtTasks/Delete/5
        public async Task<IActionResult> QxtDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _context.QxtTasks.FirstOrDefaultAsync(m => m.QxtTaskId == id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // POST: QxtTasks/Delete/5
        [HttpPost, ActionName("QxtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtDeleteConfirmed(int id)
        {
            var task = await _context.QxtTasks.FindAsync(id);
            if (task != null)
            {
                _context.QxtTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(QxtIndex));
        }

        private bool QxtTaskExists(int id)
        {
            return _context.QxtTasks.Any(e => e.QxtTaskId == id);
        }
    }
}
