using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }
        //Get_Create
        public IActionResult Create()
        {
            return View();
        }
        //Post_Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();            
            return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj != null)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return NotFound();
        }
        
        public IActionResult Delete(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj != null)
            {
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return NotFound();
        }
    }
}
