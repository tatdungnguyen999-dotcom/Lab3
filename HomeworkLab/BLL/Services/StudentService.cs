using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repo;

        public StudentService()
        {
            _repo = new StudentRepository();
        }

        public List<Student> GetAllStudents()
        {
            return _repo.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                throw new Exception("Tên sinh viên không được để trống!");
            }
            if (student.GPA < 0 || student.GPA > 4)
            {
                throw new Exception("GPA phải nằm trong khoảng từ 0.0 đến 4.0!");
            }

            _repo.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            if (student.StudentID <= 0)
            {
                throw new Exception("Mã sinh viên không hợp lệ!");
            }
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                throw new Exception("Tên sinh viên không được để trống!");
            }

            _repo.Update(student);
        }

        public void DeleteStudent(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Mã sinh viên không hợp lệ!");
            }

            _repo.Delete(id);
        }
    }
}
