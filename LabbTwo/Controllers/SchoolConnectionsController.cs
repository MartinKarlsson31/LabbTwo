using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabbTwo.Data;
using LabbTwo.Models;

namespace LabbTwo.Controllers
{
    public class SchoolConnectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolConnectionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetCourses()
        {
            var items = await (from emp in _context.Employees
                               join con in _context.SchoolConnections on emp.EmployeeId equals con.FK_EmployeeId
                               join cour in _context.Courses on con.FK_CourseId equals cour.CourseId
                               where cour.CourseId == 1
                               select new
                               {
                                   CourseName = cour.CourseName,
                                   FirstName = emp.FirstName, 
                                   LastName = emp.LastName
                               }).ToListAsync();          
            return View();
                

        }
        // GET: SchoolConnections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SchoolConnections.Include(s => s.Courses).Include(s => s.Employees).Include(s => s.SchoolClasses).Include(s => s.Students);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SchoolConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Courses)
                .Include(s => s.Employees)
                .Include(s => s.SchoolClasses)
                .Include(s => s.Students)
                .FirstOrDefaultAsync(m => m.SchoolConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // GET: SchoolConnections/Create
        public IActionResult Create()
        {
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            ViewData["FK_SchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName");
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: SchoolConnections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolConnectionId,FK_CourseId,FK_EmployeeId,FK_StudentId,FK_SchoolClassId")] SchoolConnection schoolConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", schoolConnection.FK_CourseId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", schoolConnection.FK_EmployeeId);
            ViewData["FK_SchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", schoolConnection.FK_SchoolClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", schoolConnection.FK_StudentId);
            return View(schoolConnection);
        }

        // GET: SchoolConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection == null)
            {
                return NotFound();
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", schoolConnection.FK_CourseId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", schoolConnection.FK_EmployeeId);
            ViewData["FK_SchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", schoolConnection.FK_SchoolClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", schoolConnection.FK_StudentId);
            return View(schoolConnection);
        }

        // POST: SchoolConnections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolConnectionId,FK_CourseId,FK_EmployeeId,FK_StudentId,FK_SchoolClassId")] SchoolConnection schoolConnection)
        {
            if (id != schoolConnection.SchoolConnectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolConnectionExists(schoolConnection.SchoolConnectionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", schoolConnection.FK_CourseId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", schoolConnection.FK_EmployeeId);
            ViewData["FK_SchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", schoolConnection.FK_SchoolClassId);
            ViewData["FK_StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", schoolConnection.FK_StudentId);
            return View(schoolConnection);
        }

        // GET: SchoolConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Courses)
                .Include(s => s.Employees)
                .Include(s => s.SchoolClasses)
                .Include(s => s.Students)
                .FirstOrDefaultAsync(m => m.SchoolConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // POST: SchoolConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolConnections == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SchoolConnections'  is null.");
            }
            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection != null)
            {
                _context.SchoolConnections.Remove(schoolConnection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolConnectionExists(int id)
        {
          return (_context.SchoolConnections?.Any(e => e.SchoolConnectionId == id)).GetValueOrDefault();
        }
    }
}
