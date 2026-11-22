using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _repo;

        public DepartmentService()
        {
            _repo = new DepartmentRepository();
        }

        public List<Department> GetAllDepartments()
        {
            return _repo.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddDepartment(Department department)
        {
            if (string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                throw new Exception("Department name cannot be empty.");
            }

            _repo.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            if (department.DepartmentID <= 0)
            {
                throw new Exception("Invalid department id.");
            }
            if (string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                throw new Exception("Department name cannot be empty.");
            }

            _repo.Update(department);
        }

        public void DeleteDepartment(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid department id.");

            _repo.Delete(id);
        }
    }
}
