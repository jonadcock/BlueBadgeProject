﻿using BlueBadge.Models.CourseRatingModels;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BlueBadgeProject.WebMVC.Controllers
{
    public class CourseRatingController : Controller
    {
        // GET: CourseRating
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);
            var model = service.GetRatings();
            return View(model);
        }

        public ActionResult Create()
        {

            var courseService = new CourseService();
            var courseList = courseService.GetCourses();

            ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseRatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRatingService();

            if (service.CreateRating(model))
            {
                TempData["SaveResult"] = "Your rating has been added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Rating could not be added at this time.");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var ctx = CreateRatingService();
            var model = ctx.GetRatingsByID(id);

            return View(model);
        }

        private CourseRatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);
            return service;
        }
    }
}