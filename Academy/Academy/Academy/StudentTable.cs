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
    public partial class StudentTable : Form
    {
        int minSalary = 0, maxSalary = 0;

        public StudentTable()
        {
            InitializeComponent();
            FillStudent();
            FillGroupDrop();
            ColorRow();
        }

        private void FillStudent()
        {
            studentsTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Students> studentsList = db.Students.ToList();


                foreach (var s in studentsList)
                {
                    int leftAmount = s.Groups.Education_Programs.Price - s.Fee;
                    List<Models.Grades> gradesList = db.Grades.Where(g => g.StudentId == s.Id).ToList();
                    int sum = 0;
                    double average;
                    foreach (var g in gradesList)
                    {
                        sum += Convert.ToInt32(g.Grade);
                    }

                    if (gradesList.Count() == 0)
                    {
                        average = 0;
                    }
                    else
                    {
                        average = sum / gradesList.Count();
                    }




                    if (s.Status == true)
                    {
                        if (leftAmount >= 0)
                        {
                            studentsTable.Rows.Add(s.Id,
                                   s.Name,
                                   s.Surname,
                                   s.Email,
                                   s.Phone,
                                   s.Groups.Name,
                                   leftAmount,
                                   average);
                        }
                        else
                        {
                            studentsTable.Rows.Add(s.Id,
                                 s.Name,
                                 s.Surname,
                                 s.Email,
                                 s.Phone,
                                 s.Groups.Name,
                                 0,
                                 average);
                        }
                    }
                }
            }
        }

        private void FillGroupDrop()
        {
            groupDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList = db.Groups.ToList();

                foreach (var g in groupsList)
                {
                    if (g.Status == true)
                    {
                        groupDrop.Items.Add(g.Name);
                    }
                }
            }
        }

        private void ColorRow()
        {
            for (int r = 0; r < (studentsTable.Rows.Count - 1); r++)
            {
                for (int c = 0; c < studentsTable.Rows[r].Cells.Count; c++)
                {
                    if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) > 0)
                    {
                        studentsTable.Rows[r].Cells[c].Style.BackColor = Color.Red;
                        studentsTable.Rows[r].Cells[c].Style.ForeColor = Color.White;
                    }
                }
            }
        }


        private void Reset()
        {
            minimumBox.Clear();
            maximumBox.Clear();
            searchBox.Clear();
            groupDrop.SelectedIndex = -1;
            ColorRow();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void GroupSelected(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Students> studentsList;

                if (groupDrop.SelectedIndex >= 0)
                {
                    studentsList = db.Students.Where(s => s.Groups.Name == groupDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    studentsList = db.Students.ToList();
                }


                studentsTable.Rows.Clear();
                foreach (var s in studentsList)
                {
                    int leftAmount = s.Groups.Education_Programs.Price - s.Fee;

                    if (s.Status == true)
                    {
                        if (leftAmount >= 0)
                        {
                            studentsTable.Rows.Add(s.Id,
                                   s.Name,
                                   s.Surname,
                                   s.Email,
                                   s.Phone,
                                   s.Groups.Name,
                                   leftAmount);
                        }
                        else
                        {
                            studentsTable.Rows.Add(s.Id,
                                 s.Name,
                                 s.Surname,
                                 s.Email,
                                 s.Phone,
                                 s.Groups.Name,
                                 0);
                        }
                    }
                }
            }
            ColorRow();
        }

        private void MinimumBox_TextChanged(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(minimumBox.Text))
            {
                if (string.IsNullOrEmpty(maximumBox.Text))
                {
                    int minLeft = 0;
                    FillStudent();
                    ColorRow();
                }
                else
                {
                    int maxLeft = Convert.ToInt32(maximumBox.Text);
                    for (int r = 0; r < studentsTable.Rows.Count; r++)
                    {
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) > maxLeft)
                        {
                            studentsTable.Rows[r].Visible = false;
                            ColorRow();
                        }
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) < maxLeft)
                        {
                            studentsTable.Rows[r].Visible = true;
                            ColorRow();
                        }
                    }
                }
            }
            else
            {
                Regex numbers = new Regex(@"^[0-9]+$");
                Match amountMatch = numbers.Match(minimumBox.Text);

                if (!amountMatch.Success)
                {
                    MessageBox.Show("Amount contains only numbers");
                    minimumBox.Clear();
                    ColorRow();
                }
                else
                {
                    int minLeft = Convert.ToInt32(minimumBox.Text);
                    for (int r = 0; r < (studentsTable.Rows.Count - 1); r++)
                    {
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) < minLeft)
                        {
                            studentsTable.Rows[r].Visible = false;
                            ColorRow();
                        }
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) >= minLeft)
                        {
                            studentsTable.Rows[r].Visible = true;
                            ColorRow();
                        }
                    }
                }

            }

        }

        private void MaximumBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maximumBox.Text))
            {
                if (string.IsNullOrEmpty(minimumBox.Text))
                {
                    int minLeft = 0;
                    FillStudent();
                    ColorRow();
                }
                else
                {
                    int minLeft = Convert.ToInt32(minimumBox.Text);
                    for (int r = 0; r < (studentsTable.Rows.Count - 1); r++)
                    {
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) < minLeft)
                        {
                            studentsTable.Rows[r].Visible = false;
                            ColorRow();
                        }
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) >= minLeft)
                        {
                            studentsTable.Rows[r].Visible = true;
                            ColorRow();
                        }
                    }
                }
            }
            else
            {
                Regex numbers = new Regex(@"^[0-9]+$");
                Match amountMatch = numbers.Match(maximumBox.Text);

                if (!amountMatch.Success)
                {
                    MessageBox.Show("Amount contains only numbers");
                    maximumBox.Clear();
                    ColorRow();
                }
                else
                {
                    int maxLeft = Convert.ToInt32(maximumBox.Text);
                    for (int r = 0; r < studentsTable.Rows.Count; r++)
                    {
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) > maxLeft)
                        {
                            studentsTable.Rows[r].Visible = false;
                            ColorRow();
                        }
                        if (Convert.ToInt32(studentsTable.Rows[r].Cells[6].Value) <= maxLeft)
                        {
                            studentsTable.Rows[r].Visible = true;
                            ColorRow();
                        }
                    }
                }
            }
        }
       

        private void SearchStudent(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.ToLower().Trim();
            List<Models.Students> studentsList;

            using (AcademyEntities db = new AcademyEntities())
            {
                if (groupDrop.SelectedIndex >= 0)
                {
                    studentsList = db.Students.Where(s => s.Groups.Name == groupDrop.SelectedItem.ToString() &&
                                                           (s.Name.ToLower().Contains(searchText) ||
                                                           s.Surname.ToLower().Contains(searchText) ||
                                                           s.Email.ToLower().Contains(searchText) ||
                                                           s.Phone.ToLower().Contains(searchText) ||
                                                           s.Groups.Name.ToLower().Contains(searchText))).ToList();
                }
                else
                {
                    studentsList = db.Students.Where(s => s.Name.ToLower().Contains(searchText) ||
                                                           s.Surname.ToLower().Contains(searchText) ||
                                                           s.Email.ToLower().Contains(searchText) ||
                                                           s.Phone.ToLower().Contains(searchText) ||
                                                           s.Groups.Name.ToLower().Contains(searchText)).ToList();
                }

                studentsTable.Rows.Clear();
                foreach (var s in studentsList)
                {
                    int leftAmount = s.Groups.Education_Programs.Price - s.Fee;

                    if (s.Status == true)
                    {
                        if (leftAmount >= 0)
                        {
                            studentsTable.Rows.Add(s.Id,
                                   s.Name,
                                   s.Surname,
                                   s.Email,
                                   s.Phone,
                                   s.Groups.Name,
                                   leftAmount);
                        }
                        else
                        {
                            studentsTable.Rows.Add(s.Id,
                                 s.Name,
                                 s.Surname,
                                 s.Email,
                                 s.Phone,
                                 s.Groups.Name,
                                 0);
                        }
                    }
                }
            }
            ColorRow();
        }
    }
}
