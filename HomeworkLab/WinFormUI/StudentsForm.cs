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
    public partial class StudentsForm : Form
    {
        private readonly StudentService _studentService;
        public StudentsForm()
        {
            InitializeComponent();
            _studentService = new StudentService();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvStudents.DataSource = _studentService.GetAllStudents();
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
                var student = GetStudentFromInput();
                _studentService.AddStudent(student);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var student = GetStudentFromInput();
                student.StudentID = int.Parse(txtStudentID.Text);

                _studentService.UpdateStudent(student);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (int.TryParse(txtStudentID.Text, out int studentId))
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _studentService.DeleteStudent(studentId);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                txtStudentID.Text = row.Cells["StudentID"].Value?.ToString();
                txtStudentName.Text = row.Cells["StudentName"].Value?.ToString();
                if (row.Cells["DateOfBirth"].Value != null)
                {
                    dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                }
                txtCity.Text = row.Cells["City"].Value?.ToString();
                numAge.Value = row.Cells["Age"].Value != null ? Convert.ToDecimal(row.Cells["Age"].Value) : 18;
                numYearOfEnroll.Value = row.Cells["YearOfEnroll"].Value != null ? Convert.ToDecimal(row.Cells["YearOfEnroll"].Value) : DateTime.Now.Year;
                txtMajor.Text = row.Cells["Major"].Value?.ToString();
                txtGPA.Text = row.Cells["GPA"].Value?.ToString();
            }
        }

        private Student GetStudentFromInput()
        {
            decimal? gpaValue = null;
            if (decimal.TryParse(txtGPA.Text, out decimal parsedGpa))
            {
                gpaValue = parsedGpa;
            }

            return new Student
            {
                StudentName = txtStudentName.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value,
                City = txtCity.Text.Trim(),
                Age = (int)numAge.Value,
                YearOfEnroll = (int)numYearOfEnroll.Value,
                Major = txtMajor.Text.Trim(),
                GPA = gpaValue
            };
        }

        private void ClearInputs()
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtCity.Clear();
            txtMajor.Clear();
            txtGPA.Clear();
            numAge.Value = 18;
            numYearOfEnroll.Value = DateTime.Now.Year;
            dtpDateOfBirth.Value = DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
        }
    }
}
