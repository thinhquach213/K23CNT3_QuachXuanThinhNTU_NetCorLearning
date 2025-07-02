using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QxtLesson11.Models;

namespace QxtLesson11.Controllers
{
    public class QxtEmployeesController : Controller
    {
        private readonly QuachXuanThinh2210900088Context _context;

        public QxtEmployeesController(QuachXuanThinh2210900088Context context)
        {
            _context = context;
        }

        // GET: QxtEmployees
        public async Task<IActionResult> QxtIndex()
        {
            return View(await _context.QxtEmployees.ToListAsync());
        }

        // GET: QxtEmployees/Details/5
        public async Task<IActionResult> QxtDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qxtEmployee = await _context.QxtEmployees
                .FirstOrDefaultAsync(m => m.QxtEmpId == id);
            if (qxtEmployee == null)
            {
                return NotFound();
            }

            return View(qxtEmployee);
        }

        // GET: QxtEmployees/Create
        public IActionResult QxtCreate()
        {
            return View();
        }

        // POST: QxtEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtCreate([Bind("QxtEmpId,QxtEmpName,QxtEmpLevel,QxtEmpStartDate,QxtEmpStatus")] QxtEmployee qxtEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qxtEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(QxtIndex));
            }
            return View(qxtEmployee);
        }

        // GET: QxtEmployees/Edit/5
        public async Task<IActionResult> QxtEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qxtEmployee = await _context.QxtEmployees.FindAsync(id);
            if (qxtEmployee == null)
            {
                return NotFound();
            }
            return View(qxtEmployee);
        }

        // POST: QxtEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QxtEdit(int id, [Bind("QxtEmpId,QxtEmpName,QxtEmpLevel,QxtEmpStartDate,QxtEmpStatus")] QxtEmployee qxtEmployee)
        {
            if (id != qxtEmployee.QxtEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qxtEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QxtEmployeeExists(qxtEmployee.QxtEmpId))
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
            return View(qxtEmployee);
        }

        // GET: QxtEmployees/Delete/5
        public async Task<IActionResult> QxtDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qxtEmployee = await _context.QxtEmployees
                .FirstOrDefaultAsync(m => m.QxtEmpId == id);
            if (qxtEmployee == null)
            {
                return NotFound();
            }

            return View(qxtEmployee);
        }

        // POST: QxtEmployees/Delete/5
        [HttpPost, ActionName("QxtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qxtEmployee = await _context.QxtEmployees.FindAsync(id);
            if (qxtEmployee != null)
            {
                _context.QxtEmployees.Remove(qxtEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(QxtIndex));
        }

        private bool QxtEmployeeExists(int id)
        {
            return _context.QxtEmployees.Any(e => e.QxtEmpId == id);
        }
    }
}
