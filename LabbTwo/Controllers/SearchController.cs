using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabbTwo.Data;
using LabbTwo.Models;

namespace LabbTwo.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<SearchViewModel> list = new List<SearchViewModel>();
                       var items = await (from e in _context.Employees
                                          join sc in _context.SchoolConnections on e.EmployeeId equals sc.FK_EmployeeId
                                          join c in _context.Courses on sc.FK_CourseId equals c.CourseId
                                          where c.CourseName == "Programmering 1"
                                          //group e by e.EmployeeId into g
                                          select new 
                                          {
                                              //EmployeeId = g.Key,
                                              FirstName = e.FirstName,
                                              LastName = e.LastName,
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
