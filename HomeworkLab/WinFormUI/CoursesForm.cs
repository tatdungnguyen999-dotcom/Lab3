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
    public partial class CoursesForm : Form
    {
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;
        private readonly InstructorService _instructorService;
        public CoursesForm()
        {
            InitializeComponent();
            _courseService = new CourseService();
            _departmentService = new DepartmentService();
            _instructorService = new InstructorService();
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboDepartment.DataSource = _departmentService.GetAllDepartments();
                cboDepartment.DisplayMember = "DepartmentName";
                cboDepartment.ValueMember = "DepartmentID";

                cboInstructor.DataSource = _instructorService.GetAllInstructors();
                cboInstructor.DisplayMember = "InstructorName";
                cboInstructor.ValueMember = "InstructorID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvCourses.DataSource = _courseService.GetAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khóa học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var course = new Course
                {
                    CourseName = txtCourseName.Text.Trim(),
                    Credits = (int)numCredits.Value,
                    DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue),
                    InstructorID = Convert.ToInt32(cboInstructor.SelectedValue)
                };

                _courseService.AddCourse(course);
                MessageBox.Show("Thêm khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khóa học: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCourseID.Text, out int courseId))
                {
                    var course = new Course
                    {
                        CourseID = courseId,
                        CourseName = txtCourseName.Text.Trim(),
                        Credits = (int)numCredits.Value,
                        DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue),
                        InstructorID = Convert.ToInt32(cboInstructor.SelectedValue)
                    };

                    _courseService.UpdateCourse(course);
                    MessageBox.Show("Cập nhật khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khóa học cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                if (int.TryParse(txtCourseID.Text, out int courseId))
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khóa học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _courseService.DeleteCourse(courseId);
                        MessageBox.Show("Xóa khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khóa học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                txtCourseID.Text = row.Cells["CourseID"].Value?.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value?.ToString();
                numCredits.Value = row.Cells["Credits"].Value != null ? Convert.ToDecimal(row.Cells["Credits"].Value) : 3;

                if (row.Cells["DepartmentID"].Value != null)
                    cboDepartment.SelectedValue = row.Cells["DepartmentID"].Value;
                if (row.Cells["InstructorID"].Value != null)
                    cboInstructor.SelectedValue = row.Cells["InstructorID"].Value;
            }
        }

        private void ClearInputs()
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            numCredits.Value = 3;
            if (cboDepartment.Items.Count > 0) cboDepartment.SelectedIndex = 0;
            if (cboInstructor.Items.Count > 0) cboInstructor.SelectedIndex = 0;
        }
    }
}
