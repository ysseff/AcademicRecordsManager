using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class CrsResultController : Controller
{
    SchoolContext db = new SchoolContext();
    
    public IActionResult GetAll()
    {
        var res = db.CrsResults.ToList();

        var studentNames = db.Students
            .ToDictionary(s => s.StudentId, s => s.Name);

        var courseNames = db.Courses
            .ToDictionary(c => c.CourseId, c => c.Name);

        ViewBag.StudentNames = studentNames;
        ViewBag.CourseNames = courseNames;

        return View(res);
    }

    public IActionResult Details(int id)
    {
        var res = db.CrsResults.Find(id);
        
        var studentNames = db.Students
            .ToDictionary(s => s.StudentId, s => s.Name);

        var courseNames = db.Courses
            .ToDictionary(c => c.CourseId, c => c.Name);
        
        ViewBag.StudentNames = studentNames;
        ViewBag.CourseNames = courseNames;
        
        return View(res);
    }

    public IActionResult New()
    {
        var crs = db.Courses.ToList();
        ViewBag.Crs = crs;
        var stds = db.Students.ToList();
        ViewBag.Stds = stds;
        return View();
    }
    
    public IActionResult Save(CrsResult crsResult)
    {
        if (ModelState.IsValid)
        {
            db.CrsResults.Add(crsResult);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            var crs = db.Courses.ToList();
            ViewBag.Crs = crs;
            var stds = db.Students.ToList();
            ViewBag.Stds = stds;
            return View("New", crsResult);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var crsResult = db.CrsResults.FirstOrDefault(i => i.CrsResultId == id);
        var crs = db.Courses.ToList();
        ViewBag.Crs = crs;
        var stds = db.Students.ToList();
        ViewBag.Stds = stds;
        return View(crsResult);
    }
    
    public IActionResult EditSave(CrsResult crsResult)
    {
        if (ModelState.IsValid)
        {
            db.CrsResults.Update(crsResult);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        else
        {
            return View("Edit", crsResult);
        }
    } 
    
    public IActionResult Delete(int id)
    {
        var crsResult = db.CrsResults.Find(id);
        db.CrsResults.Remove(crsResult);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}