using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class InstructorService
    {
        private readonly InstructorRepository _repo;

        public InstructorService()
        {
            _repo = new InstructorRepository();
        }

        public List<Instructor> GetAllInstructors()
        {
            return _repo.GetAll();
        }

        public Instructor GetInstructorById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddInstructor(Instructor instructor)
        {
            if (string.IsNullOrWhiteSpace(instructor.InstructorName))
            {
                throw new Exception("Instructor name cannot be empty.");
            }

            _repo.Add(instructor);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            if (instructor.InstructorID <= 0)
            {
                throw new Exception("Invalid instructor id.");
            }
            if (string.IsNullOrWhiteSpace(instructor.InstructorName))
            {
                throw new Exception("Instructor name cannot be empty.");
            }

            _repo.Update(instructor);
        }

        public void DeleteInstructor(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid instructor id.");

            _repo.Delete(id);
        }
    }
}
