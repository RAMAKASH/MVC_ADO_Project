using Microsoft.AspNetCore.Mvc;
using MVC_ADO_Project.Models.data;

namespace MVC_ADO_Project.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccess dataAccess;
        public EmployeeController()
        {
            dataAccess = new EmployeeDataAccess();
        }
        public IActionResult Index()
        {
            var emp=dataAccess.GetEmployeeList();
            return View(emp);
        }
    }
}
