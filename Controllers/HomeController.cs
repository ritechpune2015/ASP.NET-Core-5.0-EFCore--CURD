using EFCore2.Context;
using EFCore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {

            var rec=this.cc.Emps.Find(id);
            ViewBag.Depts = new SelectList(this.cc.Depts.ToList(), "DID", "DeptName", rec.DeptID);
            return View(rec);

        }

        [HttpPost]
        public IActionResult Edit(Emp rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Emps.Update(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Emps.Find(id);
            this.cc.Emps.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
