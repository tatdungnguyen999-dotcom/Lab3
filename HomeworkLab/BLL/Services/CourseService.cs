using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class CourseService
    {
        private readonly CourseRepository _repo;

        public CourseService()
        {
            _repo = new CourseRepository();
        }

        public List<Course> GetAllCourses()
        {
            return _repo.GetAll();
        }

        public Course GetCourseById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
            {
                throw new Exception("Course name cannot be empty.");
            }

            _repo.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            if (course.CourseID <= 0)
            {
                throw new Exception("Invalid course id.");
            }
            if (string.IsNullOrWhiteSpace(course.CourseName))
            {
                throw new Exception("Course name cannot be empty.");
            }

            _repo.Update(course);
        }

        public void DeleteCourse(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid course id.");

            _repo.Delete(id);
        }
    }
}
