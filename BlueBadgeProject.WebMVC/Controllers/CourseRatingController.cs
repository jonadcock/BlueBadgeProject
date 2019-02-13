using BlueBadge.Models.CourseRatingModels;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

//namespace BlueBadgeProject.WebMVC.Controllers
//{
    //public class CourseRatingController : Controller
    //{
    //    // GET: CourseRating
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    public ActionResult Create()
    //    {
    //        var courseService = new CourseService();
    //        var courseList = courseService.GetCourses();

    //        ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseName");

    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult Create(CourseRatingCreate model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        var service = GetRatingService();

    //        if (service.CreateRating(model))
    //        {
    //            return RedirectToAction("Index", "Courses");
    //        }

    //        var courseService = new CourseService();
    //        var courseList = courseService.GetCourses();

    //        ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseName");

    //        return View(model);
    //    }

//        private CourseRatingService GetRatingService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new CourseRatingService(userId);
//            return service;
//        }
//    }
//}