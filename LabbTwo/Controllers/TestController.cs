using LabbTwo.Data;
using LabbTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbTwo.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var items = await(from emp in _context.Employees
                              join con in _context.SchoolConnections on emp.EmployeeId equals con.FK_EmployeeId
                              join cour in _context.Courses on con.FK_CourseId equals cour.CourseId
                              select new
                              {
                                  FirstName = emp.FirstName, 
                                  LastName = emp.LastName,
                                  CourseName = cour.CourseName
                              }).ToListAsync();          
                return View(items);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
