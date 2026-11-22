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
    public partial class InstructorsForm : Form
    {
        private readonly InstructorService _instructorService;
        public InstructorsForm()
        {
            InitializeComponent();
            _instructorService = new InstructorService();
        }

        private void InstructorsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvInstructors.DataSource = _instructorService.GetAllInstructors();
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
                var instructor = GetInstructorFromInput();
                _instructorService.AddInstructor(instructor);
                MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm giảng viên: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInstructorID.Text))
                {
                    MessageBox.Show("Vui lòng chọn giảng viên cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var instructor = GetInstructorFromInput();
                instructor.InstructorID = int.Parse(txtInstructorID.Text);

                _instructorService.UpdateInstructor(instructor);
                MessageBox.Show("Cập nhật giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (int.TryParse(txtInstructorID.Text, out int instructorId))
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _instructorService.DeleteInstructor(instructorId);
                        MessageBox.Show("Xóa giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn giảng viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataGridViewRow row = dgvInstructors.Rows[e.RowIndex];

                txtInstructorID.Text = row.Cells["InstructorID"].Value?.ToString();
                txtInstructorName.Text = row.Cells["InstructorName"].Value?.ToString();
                txtDepartmentID.Text = row.Cells["DepartmentID"].Value?.ToString();
            }
        }

        private Instructor GetInstructorFromInput()
        {
            return new Instructor
            {
                InstructorName = txtInstructorName.Text.Trim(),
                DepartmentID = int.Parse(txtDepartmentID.Text.Trim())
            };
        }

        private void ClearInputs()
        {
            txtInstructorID.Clear();
            txtInstructorName.Clear();
            txtDepartmentID.Clear();
        }
    }
}
