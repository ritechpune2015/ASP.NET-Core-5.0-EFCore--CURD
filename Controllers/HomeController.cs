using EFCore2.Context;
using EFCore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EFCore2.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext cc;
        public HomeController(CompanyContext cc)
        {
            this.cc = cc;
        }
        public IActionResult Index()
        {
              var res = this.cc.Emps.ToList();
            //var res = from t in this.cc.Emps
            //          where t.Salary > 25000
            //          select t;
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Depts = new SelectList(this.cc.Depts.ToList(),"DID","DeptName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Emp rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Emps.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
    }
}
