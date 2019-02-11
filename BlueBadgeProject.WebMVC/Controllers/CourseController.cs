using BlueBadge.Models.CourseModels;
using BlueBadge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.WebMVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            var model = service.GetCourses();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCourseService();

            if (service.CreateCourse(model))
            {
                ViewBag.SaveResult = "Your course was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Course could not be created.");

            return View(model);
        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }
    }
}