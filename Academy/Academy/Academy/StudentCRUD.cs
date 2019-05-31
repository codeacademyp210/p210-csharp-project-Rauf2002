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
    public partial class StudentCRUD : Form
    {
        Models.Students studentFound = new Models.Students();
        public StudentCRUD()
        {
            InitializeComponent();
            FillStudent();
            FillGroupDrop();
            deleteBtn.Enabled = false;
        }

        private void FillStudent()
        {
            studentsTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Students> studentsList = db.Students.ToList();

                foreach (var s in studentsList)
                {
                    if (s.Status == true)
                    {
                        studentsTable.Rows.Add(s.Id,
                                               s.Name,
                                               s.Surname,
                                               s.Groups.Name,
                                               s.Phone);
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

        private void Reset()
        {
            nameBox.Clear();
            surnameBox.Clear();
            emailBox.Clear();
            phoneBox.Clear();
            feeBox.Clear();
            groupDrop.SelectedIndex = -1;
            saveBtn.Text = "Save";
            deleteBtn.Enabled = false;
            feeBox.Enabled = true;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void AddStudent(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Students> passiveList = db.Students.Where(s => s.Status == false).ToList();
                    Models.Students passiveStudent = db.Students.Where(s => s.Email == emailBox.Text.Trim()).FirstOrDefault();

                    if (passiveList.Contains(passiveStudent))
                    {
                        passiveStudent.Status = true;
                        db.SaveChanges();
                        FillStudent();
                        Reset();
                    }
                    else
                    {
                        int groupId = (db.Groups.Where(g => g.Name == groupDrop.SelectedItem.ToString()).FirstOrDefault()).Id;

                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());
                        Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match emailMatch = email.Match(emailBox.Text.Trim());

                        Regex phone = new Regex(@"^[+0-9]*$");
                        Match phoneMatch = phone.Match(phoneBox.Text.Trim());

                        Regex numbers = new Regex(@"^[0-9]*$");
                        Match feeMatch = numbers.Match(feeBox.Text.Trim());

                        if (!nameMatch.Success || !surnameMatch.Success)
                        {
                            MessageBox.Show("Name and surname contain only letters");
                        }
                        else if (!emailMatch.Success)
                        {
                            MessageBox.Show("Please enter a valid email");
                        }
                        else if (!phoneMatch.Success)
                        {
                            MessageBox.Show("Please enter a valid phone number");
                        }
                        else if (!feeMatch.Success)
                        {
                            MessageBox.Show("The paid amount contains only  numbers");
                        }
                        else
                        {
                            Models.Students s1 = new Models.Students
                            {
                                Name = nameBox.Text.Trim(),
                                Surname = surnameBox.Text.Trim(),
                                Email = emailBox.Text.Trim(),
                                Phone = phoneBox.Text.Trim(),
                                Fee = Convert.ToInt32(feeBox.Text.Trim()),
                                GroupId = groupId,
                                Status = true
                            };
                            db.Students.Add(s1);
                            db.SaveChanges();
                            FillStudent();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int studentId = Convert.ToInt32(studentsTable.SelectedRows[0].Cells[0].Value);
                    int groupId = (db.Groups.Where(g => g.Name == groupDrop.SelectedItem.ToString()).FirstOrDefault()).Id;


                    Regex letters = new Regex(@"^[A-Za-z ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());
                    Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                    Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match emailMatch = email.Match(emailBox.Text.Trim());

                    Regex phone = new Regex(@"^[+0-9]*$");
                    Match phoneMatch = phone.Match(phoneBox.Text.Trim());

                    Regex numbers = new Regex(@"^[0-9]*$");
                    Match feeMatch = numbers.Match(feeBox.Text.Trim());

                    if (!nameMatch.Success || !surnameMatch.Success)
                    {
                        MessageBox.Show("Name and surname contain only letters");
                    }
                    else if (!emailMatch.Success)
                    {
                        MessageBox.Show("Please enter a valid email");
                    }
                    else if (!phoneMatch.Success)
                    {
                        MessageBox.Show("Please enter a valid phone number");
                    }
                    else if (!feeMatch.Success)
                    {
                        MessageBox.Show("The paid amount contains only  numbers");
                    }
                    else
                    {

                        Models.Students newStudent = db.Students.Where(s => s.Id == studentId).FirstOrDefault();

                        newStudent.Name = nameBox.Text.Trim();
                        newStudent.Surname = surnameBox.Text.Trim();
                        newStudent.Email = emailBox.Text.Trim();
                        newStudent.Phone = phoneBox.Text.Trim();
                        newStudent.Fee += Convert.ToInt32(feeBox.Text.Trim());
                        newStudent.GroupId = groupId;

                        db.SaveChanges();
                        FillStudent();
                        Reset();
                    }
                }
            }
        }

        private void StudentsTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int studentId = Convert.ToInt32(studentsTable.Rows[e.RowIndex].Cells[0].Value);

            using (AcademyEntities db = new AcademyEntities())
            {
                studentFound = db.Students.Where(s => s.Id == studentId).FirstOrDefault();

                if (studentFound != null )
                {   
                    if (studentFound.Fee < studentFound.Groups.Education_Programs.Price)
                    {
                        nameBox.Text = studentFound.Name;
                        surnameBox.Text = studentFound.Surname;
                        emailBox.Text = studentFound.Email;
                        phoneBox.Text = studentFound.Phone;
                        feeBox.Enabled = true;
                        feeBox.Text = studentFound.Fee.ToString();
                        groupDrop.SelectedItem = studentFound.Groups.Name;
                    }
                    else
                    {
                        feeBox.Text = studentFound.Fee.ToString();
                        feeBox.Enabled = false;
                        nameBox.Text = studentFound.Name;
                        surnameBox.Text = studentFound.Surname;
                        emailBox.Text = studentFound.Email;
                        phoneBox.Text = studentFound.Phone;
                        groupDrop.SelectedItem = studentFound.Groups.Name;

                    }

                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeleteStudent(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int studentId = Convert.ToInt32(studentsTable.SelectedRows[0].Cells[0].Value);

                Models.Students s1 = db.Students.Where(s => s.Id == studentId).FirstOrDefault();
                s1.Status = false;
                db.SaveChanges();
            }
            FillStudent();
            Reset();
        }
    }
}
