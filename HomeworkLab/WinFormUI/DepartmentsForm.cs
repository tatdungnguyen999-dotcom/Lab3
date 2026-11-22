using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using DAL.Models;

namespace WinFormUI
{
    public partial class DepartmentsForm : Form
    {
        private readonly DepartmentService _departmentService;
        public DepartmentsForm()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvDepartments.DataSource = _departmentService.GetAllDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var dept = GetDepartmentFromInput();
                _departmentService.AddDepartment(dept);
                MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khoa: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDepartmentID.Text))
                {
                    MessageBox.Show("Vui lòng chọn khoa cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dept = GetDepartmentFromInput();
                dept.DepartmentID = int.Parse(txtDepartmentID.Text);

                _departmentService.UpdateDepartment(dept);
                MessageBox.Show("Cập nhật thông tin khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDepartmentID.Text, out int deptId))
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _departmentService.DeleteDepartment(deptId);
                        MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDepartments.Rows[e.RowIndex];

                txtDepartmentID.Text = row.Cells["DepartmentID"].Value?.ToString();
                txtDepartmentName.Text = row.Cells["DepartmentName"].Value?.ToString();
            }
        }

        private Department GetDepartmentFromInput()
        {
            return new Department
            {
                DepartmentName = txtDepartmentName.Text.Trim()
            };
        }

        private void ClearInputs()
        {
            txtDepartmentID.Clear();
            txtDepartmentName.Clear();
        }
    }
}
