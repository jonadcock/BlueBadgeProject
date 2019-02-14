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

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Select(
                        p =>
                        new RatingListItem
                        {
                            CourseRatingId = p.CourseRatingId,
                            CourseName = p.CourseName,
                            CourseRatings = p.CourseRatings,
                            DatePlayed = p.DatePlayed,
                        });
                return query.ToArray();
            }
        }

        public CourseRating GetRatingsByID(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .FirstOrDefault(p => p.CourseId == courseId);
                return

                new CourseRating
                {
                    CourseRatingId = entity.CourseRatingId,
                    CourseName = entity.CourseName,
                    CourseRatings = entity.CourseRatings,
                    DatePlayed = entity.DatePlayed,
                    CourseId = entity.CourseId,

                };
            }
        }
        private bool CalculateRating(float ratingLevel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(r => r.CourseRatings == ratingLevel).ToList();

                float averageRating = 0;
                foreach (var rating in query)
                {
                    averageRating += rating.CourseRatings;
                }
                averageRating /= query.Count;

                var course = ctx.Courses.Single(p => p.CourseRatings == ratingLevel);
                course.CourseRatings = averageRating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
