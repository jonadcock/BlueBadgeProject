using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBadge.Models.CourseRatingModels;

namespace BlueBadge.Services
{
    public class CourseRatingService
    {
        private readonly Guid _userId;

        public CourseRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(CourseRatingCreate model)
        {
            var rating = new CourseRating
            {
                CourseId = model.CourseId,
                CourseName = model.CourseName,
                CourseRatings = model.CourseRatings,
                DatePlayed = model.DatePlayed,
                OwnerID = _userId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(rating);
             if (ctx.SaveChanges() == 1)
                {
                    CalculateRating(rating.CourseId);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<RatingListItem> GetRatingsByCourseId(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Where(p => p.CourseId == courseId)
                    .Select(
                        p =>
                        new RatingListItem
                        {
                            CourseRatingId = p.CourseRatingId,
                            CourseName = p.CourseName,
                            CourseRatings = p.CourseRatings,
                            DatePlayed = p.DatePlayed,
                        });
                return query;
            }
        }

        public CourseRatingDetail GetRatingsByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(p => p.CourseRatingId == id);
                

                var model = new CourseRatingDetail
                {
                    CourseRatingId = entity.CourseRatingId,
                    CourseName = entity.CourseName,
                    CourseRatings = entity.CourseRatings,
                    DatePlayed = entity.DatePlayed,
                    CourseId = entity.CourseId,

                };
                return model;

            }
        }
        private bool CalculateRating(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(r => r.CourseId == courseId).ToList();

                float averageRating = 0;
                foreach (var rating in query)
                {
                    averageRating += rating.CourseRatings;
                }
                averageRating /= query.Count;

                var course = ctx.Courses.Single(p => p.CourseId == courseId);
                course.CourseRatings = averageRating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
