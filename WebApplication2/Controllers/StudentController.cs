using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class StudentController : Controller
{
    SchoolContext db = new SchoolContext();
    
    public IActionResult GetAll()
    {
        var res = db.Students.ToList();
        
        var departmentNames = db.Departments
            .ToDictionary(s => s.DepartmentId, s => s.Name);
        
        ViewBag.DepartmentNames = departmentNames;
        
        return View(res);
    }

    public IActionResult Details(int id)
    {
        var res = db.Students.Find(id);
        return View(res);
    }

    public IActionResult New()
    {
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        ViewBag.NumberOptions = new List<int> { 1, 2, 3, 4 };
        return View();
    }
    
    public IActionResult Save(Student student)
    {
        if (ModelState.IsValid)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            var depts = db.Departments.ToList();
            ViewBag.Depts = depts;
            ViewBag.NumberOptions = new List<int> { 1, 2, 3, 4 };
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                }
            }
            Console.WriteLine("nigga");
            return View("New", student);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var student = db.Students.FirstOrDefault(i => i.StudentId == id);
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        
        ViewBag.NumberOptions = new List<int> { 1, 2, 3, 4 };
        
        return View(student);
    }
    
    public IActionResult EditSave(Student student)
    {
        if (ModelState.IsValid)
        {
            db.Students.Update(student);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            return View("Edit", student);
        }
    }
    
    public IActionResult Delete(int id)
    {
        var student = db.Students.Find(id);
        db.Students.Remove(student);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}