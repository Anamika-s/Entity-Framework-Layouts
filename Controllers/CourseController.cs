using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class CourseController : Controller
    {
        CourseDbContext db = new CourseDbContext();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.courses.ToList());
        }


        public ActionResult Details(int? id)
        {
            if(id.HasValue)
            {
                Course course = db.courses.FirstOrDefault(x => x.Id == id);
                if (course == null)
                    return View(course);
                else
                {
                    ViewBag.msg = "Course with this ID not found";
                    return View();
                }
            }
            else
            {
                ViewBag.msg = "Please Provide ID";
                return View();
            }
        }

        public ActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            db.courses.Add(course);
            db.SaveChanges();
            TempData["msg"] ="Record inserted";
            return RedirectToAction("Index");
        }
    }
}