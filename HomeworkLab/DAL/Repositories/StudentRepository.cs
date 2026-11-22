using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class StudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository()
        {
            _context = new SchoolContext();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            var existing = _context.Students.Find(student.StudentID);
            if (existing != null)
            {
                existing.StudentName = student.StudentName;
                existing.DateOfBirth = student.DateOfBirth;
                existing.City = student.City;
                existing.Age = student.Age;
                existing.YearOfEnroll = student.YearOfEnroll;
                existing.Major = student.Major;
                existing.GPA = student.GPA;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
