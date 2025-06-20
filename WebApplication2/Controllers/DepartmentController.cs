using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;


namespace WebApplication2.Controllers;

public class DepartmentController : Controller
{
    SchoolContext db = new SchoolContext();
    
    public IActionResult GetAll()
    {
        var res = db.Departments.ToList();
        
        var instructorNames = db.Instructors
            .ToDictionary(i => i.InstructorId, i => i.Name);

        ViewBag.InstructorNames = instructorNames;
        
        return View(res);
    }

    public IActionResult Details(int id)
    {
        var res = db.Departments.Find(id);
        
        var instructorNames = db.Instructors
            .ToDictionary(i => i.InstructorId, i => i.Name);

        ViewBag.InstructorNames = instructorNames;
        
        
        return View(res);
    }

    public IActionResult New()
    {
        var inst = db.Instructors.ToList();
        ViewBag.Inst = inst;
        
        return View();
    }
    
    public IActionResult Save(Department department)
    {
        if (ModelState.IsValid)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            var inst = db.Instructors.ToList();
            ViewBag.Inst = inst;
            return View("New", department);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var department = db.Departments.FirstOrDefault(i => i.DepartmentId == id);
        var inst = db.Instructors.ToList();
        ViewBag.Inst = inst;
        return View(department);
    }
    
    public IActionResult EditSave(Department department)
    {
        if (ModelState.IsValid)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            return View("Edit", department);
        }
    }
    
    public IActionResult Delete(int id)
    {
        var department = db.Departments.FirstOrDefault(i => i.DepartmentId == id);
        db.Departments.Remove(department);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}