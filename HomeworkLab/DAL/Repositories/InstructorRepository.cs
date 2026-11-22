using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class InstructorRepository
    {
        private readonly SchoolContext _context;

        public InstructorRepository()
        {
            _context = new SchoolContext();
        }

        public List<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void Update(Instructor instructor)
        {
            var existing = _context.Instructors.Find(instructor.InstructorID);
            if (existing != null)
            {
                existing.InstructorName = instructor.InstructorName;
                existing.DepartmentID = instructor.DepartmentID;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}
