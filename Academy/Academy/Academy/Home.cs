using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academy.Models;

namespace Academy
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            FillInfo();
        }


        private void FillInfo()
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<AcademyInfo> infoList = db.AcademyInfo.ToList();

                foreach (var a in infoList)
                {
                    academyName.Text = a.Name;
                    academyAddress.Text = a.Address;
                    academyPhone.Text = a.Phone;
                }
            }
        }

        private void EmployeeCRUD(object sender, EventArgs e)
        {
            EmployeeCRUD CRUDForm = new EmployeeCRUD();
            CRUDForm.ShowDialog();
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCRUD CRUDForm = new EmployeeCRUD();
            CRUDForm.ShowDialog();
        }

        private void TeacherLink_Click(object sender, EventArgs e)
        {
            TeacherCRUD CRUDForm = new TeacherCRUD();
            CRUDForm.ShowDialog();
        }

        private void TeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherCRUD CRUDForm = new TeacherCRUD();
            CRUDForm.ShowDialog();
        }

        private void GroupLink_Click(object sender, EventArgs e)
        {
            GroupCRUD CRUDForm = new GroupCRUD();
            CRUDForm.ShowDialog();
        }

        private void GroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupCRUD CRUDForm = new GroupCRUD();
            CRUDForm.ShowDialog();
        }

        private void StudentLink_Click(object sender, EventArgs e)
        {
            StudentCRUD CRUDForm = new StudentCRUD();
            CRUDForm.ShowDialog();
        }

        private void StudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentCRUD CRUDForm = new StudentCRUD();
            CRUDForm.ShowDialog();
        }

        private void ClassroomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassroomCRUD CRUDForm = new ClassroomCRUD();
            CRUDForm.ShowDialog();
        }

        private void EducationProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EducationCRUD CRUDForm = new EducationCRUD();
            CRUDForm.ShowDialog();
        }

        private void PositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionCRUD CRUDForm = new PositionCRUD();
            CRUDForm.ShowDialog();
        }

        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskCRUD CRUDForm = new TaskCRUD();
            CRUDForm.ShowDialog();
        }

        private void EmployeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeeTable TableForm = new EmployeeTable();
            TableForm.ShowDialog();
        }

        private void TeacherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TeacherTable TableForm = new TeacherTable();
            TableForm.ShowDialog();
        }

        private void GroupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GroupTable TableForm = new GroupTable();
            TableForm.ShowDialog();
        }

        private void StudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentTable TableForm = new StudentTable();
            TableForm.ShowDialog();
        }

        private void TaskToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaskTable TableForm = new TaskTable();
            TableForm.ShowDialog();
        }
    }
}
