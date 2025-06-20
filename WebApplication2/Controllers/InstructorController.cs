using WebApplication2.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class InstructorController : Controller
{
    SchoolContext db = new SchoolContext();
    
    public IActionResult GetAll()
    {
        var res = db.Instructors.ToList();
        
        var departmentNames = db.Departments
            .ToDictionary(s => s.DepartmentId, s => s.Name);
        
        ViewBag.DepartmentNames = departmentNames;
        
        return View(res);
    }

    public IActionResult Details(int id)
    {
        var res = db.Instructors.Find(id);
        return View(res);
    }

    public IActionResult New()
    {
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        return View();
    }
    
    public IActionResult Save(Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            var depts = db.Departments.ToList();
            ViewBag.Depts = depts;
            return View("New", instructor);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var instructor = db.Instructors.FirstOrDefault(i => i.InstructorId == id);
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        return View(instructor);
    }
    
    public IActionResult EditSave(Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            db.Instructors.Update(instructor);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            return View("Edit", instructor);
        }
    }
    
    public IActionResult Delete(int id)
    {
        var instructor = db.Instructors.FirstOrDefault(i => i.InstructorId == id);
        db.Instructors.Remove(instructor);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}