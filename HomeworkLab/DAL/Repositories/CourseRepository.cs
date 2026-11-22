using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class CourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository()
        {
            _context = new SchoolContext();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            var existing = _context.Courses.Find(course.CourseID);
            if (existing != null)
            {
                existing.CourseName = course.CourseName;
                existing.Credits = course.Credits;
                existing.DepartmentID = course.DepartmentID;
                existing.InstructorID = course.InstructorID;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
