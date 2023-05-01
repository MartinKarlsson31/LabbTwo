using LabbTwo.Data;
using LabbTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbTwo.Controllers
{
    public class StudentController : Controller
    {   
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index()
        {
            List<SearchViewModel> list = new List<SearchViewModel>();
            var items = await (from s in _context.Students
                               join sc in _context.SchoolConnections on s.StudentId equals sc.FK_StudentId
                               join c in _context.Courses on sc.FK_CourseId equals c.CourseId
                               where c.CourseName == "Programmering 1"
                               //group e by e.EmployeeId into g
                               select new
                               {
                                   //EmployeeId = g.Key,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   CourseName = c.CourseName


                               }).ToListAsync();
            foreach (var item in items)
            {
                SearchViewModel listItem = new SearchViewModel();
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.CourseName = item.CourseName;

                list.Add(listItem);
            }
            return View(list);
            
        }
    }
}
