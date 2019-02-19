using BlueBadge.Models.CourseRatingModels;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BlueBadgeProject.WebMVC.Controllers
{
    [Authorize]
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

            var playerService = new PlayerService();
            var playerList = playerService.GetPlayers();
            ViewBag.PlayerId = new SelectList(playerList, "PlayerId", "PlayerName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseRatingCreate model)
        {
             var service = CreateRatingService();

            if (!ModelState.IsValid)
            {
                var courseService = new CourseService();
                var courseList = courseService.GetCourses();

                ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseName");
                return View(model);
            }

            if (service.CreateRating(model))
            {
                return RedirectToAction("Index", "Course");
            }

            //var courseService = new CourseService();
            //var courseList = courseService.GetCourses();
            //ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseName");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ctx = new CourseRatingService(userId);
            var model = ctx.GetRatingByID(id);

            var ratingService = new CourseRatingService(Guid.Parse(User.Identity.GetUserId()));
         

            var ratings = ratingService.GetRatingByID(id);

            ViewBag.Ratings = ratings;

            return View(model);
        }

        //GET: Course/Edit
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);
            var detail = service.GetRatingByID(id);
            var model =
                new CourseRatingEdit
                {
                    CourseRatingId = detail.CourseRatingId,
                    PlayerId = detail.PlayerId,
                    CourseRatings = detail.CourseRatings,
                    DatePlayed = detail.DatePlayed,
                    CourseId = detail.CourseId,
                    CourseName = detail.CourseName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseRatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CourseRatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);

            if (service.EditRating(model))
            {
                TempData["SaveResult"] = "Your rating was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your rating could not be updated");
                return View();
        }

        private CourseRatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);
            return service;
        }
    }
}