using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academy.Models;

namespace Academy
{
    public partial class GradeTable : Form
    {
        private readonly int _taskId, _groupId;
        public GradeTable(int taskId, int groupId)
        {
            _taskId = taskId;
            _groupId = groupId;
            InitializeComponent();
            FillGrades();
            deleteBtn.Enabled = false;
            gradeBox.ReadOnly = true;
        }

        private void GradesTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            fullName.Text = gradesTable.SelectedRows[0].Cells[1].Value.ToString();
            gradeBox.Text = gradesTable.SelectedRows[0].Cells[2].Value.ToString();
            if (gradeBox.Text == " ")
            {
                saveBtn.Enabled = true;
                deleteBtn.Enabled = false;
            }
            else
            {
                saveBtn.Enabled = false;
                deleteBtn.Enabled = true;
            }
            gradeBox.ReadOnly = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gradeBox.Text))
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Grades> passiveList = db.Grades.Where(g => g.Status == false).ToList();
                    Models.Grades passiveGrade = db.Grades.Where(g => g.Students.Name + " " + g.Students.Surname == fullName.Text).FirstOrDefault();

                    if (passiveList.Contains(passiveGrade))
                    {
                        passiveGrade.Status = true;
                        db.SaveChanges();
                        FillGrades();
                        Reset();
                    }
                    else
                    {
                        Regex numbers = new Regex(@"^[0-9]+$");
                        Match gradeMatch = numbers.Match(gradeBox.Text.Trim());

                        if (!gradeMatch.Success)
                        {
                            MessageBox.Show("Grade contains olny numbers");
                        }
                        else
                        {
                            int studentId = Convert.ToInt32(gradesTable.SelectedRows[0].Cells[0].Value);


                            Models.Grades newGrade = new Models.Grades();

                            int grade = Convert.ToInt32(gradeBox.Text.Trim());
                            if (grade > 100)
                            {
                                MessageBox.Show("Grade must be less or equal to 100");
                            }
                            else
                            {
                                newGrade.Grade = grade;
                            }

                            newGrade.StudentId = studentId;
                            newGrade.TaskId = _taskId;
                            newGrade.Status = true;
                            db.Grades.Add(newGrade);
                            db.SaveChanges();
                            FillGrades();
                            Reset();
                        }
                    }
                   
                }

            }
            else
            {
                MessageBox.Show("Choose a student");
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            gradeBox.Clear();
            fullName.Text = "";
            gradeBox.ReadOnly = true;
            saveBtn.Enabled = true;
            deleteBtn.Enabled = false;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(gradesTable.SelectedRows[0].Cells[0].Value);

            using (AcademyEntities db = new AcademyEntities())
            {
                Models.Grades g1 = db.Grades.Where(g => g.StudentId == studentId && g.TaskId == _taskId).FirstOrDefault();
                db.Grades.Remove(g1);
                db.SaveChanges();
                FillGrades();
                Reset();
            }
        }

        private void FillGrades()
        {
            gradesTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Students> studentsList = db.Students.Where(s => s.GroupId == _groupId).ToList();

                foreach (var s in studentsList)
                {
                    if (s.Status == true)
                    {   
                        if (s.Grades.Where(g => g.StudentId == s.Id && g.TaskId == _taskId).FirstOrDefault() != null)
                        {
                            gradesTable.Rows.Add(s.Id,
                                   s.Name + " " + s.Surname,
                                   (s.Grades.Where(g => g.StudentId == s.Id && g.TaskId == _taskId && g.Status == true).FirstOrDefault()).Grade);
                        }
                        else
                        {
                            gradesTable.Rows.Add(s.Id,
                                                 s.Name + " " + s.Surname,
                                                 " ");
                        }

                    }
                }
            }
        }
    }
}
