using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;


namespace WebApplication2.Controllers;

public class CourseController : Controller
{
    SchoolContext db = new SchoolContext();
    
    public IActionResult GetAll()
    {
        var res = db.Courses.ToList();
        
        var departmentNames = db.Departments
            .ToDictionary(s => s.DepartmentId, s => s.Name);
        
        ViewBag.DepartmentNames = departmentNames;
        
        return View(res);
    }

    public IActionResult Details(int id)
    {
        var res = db.Courses.Find(id);
        return View(res);
    }

    public IActionResult New()
    {
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        return View();
    }
    
    public IActionResult Save(Course course)
    {
        if (ModelState.IsValid)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            var depts = db.Departments.ToList();
            ViewBag.Depts = depts;
            return View("New", course);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var course = db.Courses.FirstOrDefault(i => i.CourseId == id);
        var depts = db.Departments.ToList();
        ViewBag.Depts = depts;
        return View(course);
    }
    
    public IActionResult EditSave(Course course)
    {
        if (ModelState.IsValid)
        {
            db.Courses.Update(course);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            return View("Edit", course);
        }
    }
    
    public IActionResult Delete(int id)
    {
        var course = db.Courses.FirstOrDefault(i => i.CourseId == id);
        db.Courses.Remove(course);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}