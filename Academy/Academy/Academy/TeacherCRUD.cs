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
    public partial class TeacherCRUD : Form
    {
        Models.Teachers teacherFound = new Models.Teachers();
        public TeacherCRUD()
        {
            InitializeComponent();
            deleteBtn.Enabled = false;
            FillTeachers();
            FillSpecDrop();
        }

        private void FillTeachers()
        {
            teachersTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Teachers> teachersList = db.Teachers.ToList();

                foreach (var t in teachersList)
                {
                    if (t.Status == true)
                    {
                        teachersTable.Rows.Add(t.Id,
                                           t.Name,
                                           t.Surname,
                                           t.Phone,
                                           t.Email);
                    }
                }
            }
        }

        private void FillSpecDrop()
        {
            specialityDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Specialities> specialitiesList = db.Specialities.ToList();

                foreach (var s in specialitiesList)
                {   
                    specialityDrop.Items.Add(s.Name);
                }
            }
        }

        private void Reset()
        {
            nameBox.Clear();
            surnameBox.Clear();
            emailBox.Clear();
            phoneBox.Clear();
            specialityDrop.SelectedIndex = -1;
            deleteBtn.Enabled = false;
            saveBtn.Text = "Save";
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void AddTeacher(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Teachers> passiveList = db.Teachers.Where(t => t.Status == false).ToList();
                    Models.Teachers passiveTeacher = db.Teachers.Where(t => t.Email == emailBox.Text.Trim()).FirstOrDefault();

                    if (passiveList.Contains(passiveTeacher))
                    {
                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());
                        Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match emailMatch = email.Match(emailBox.Text.Trim());

                        Regex phone = new Regex(@"^[+0-9]*$");
                        Match phoneMatch = phone.Match(phoneBox.Text.Trim());

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
                        else
                        {
                            passiveTeacher.Status = true;
                            db.SaveChanges();
                            FillTeachers();
                            Reset();
                        }
                    }
                    else
                    {
                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());
                        Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match emailMatch = email.Match(emailBox.Text.Trim());

                        Regex phone = new Regex(@"^[+0-9]*$");
                        Match phoneMatch = phone.Match(phoneBox.Text.Trim());

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
                        else
                        {
                            int specialityId = (db.Specialities.Where(s => s.Name == specialityDrop.SelectedItem.ToString()).FirstOrDefault()).Id;

                            Models.Teachers t1 = new Models.Teachers
                            {
                                Name = nameBox.Text.Trim(),
                                Surname = surnameBox.Text.Trim(),
                                SpecialityId = specialityId,
                                Email = emailBox.Text.Trim(),
                                Phone = phoneBox.Text.Trim(),
                                Status = true
                            };
                            db.Teachers.Add(t1);
                            db.SaveChanges();
                            FillTeachers();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int specialityId = (db.Specialities.Where(s => s.Name == specialityDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                    int teacherId = Convert.ToInt32(teachersTable.SelectedRows[0].Cells[0].Value);

                    Models.Teachers newTeacher = db.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();

                    Regex letters = new Regex(@"^[A-Za-z ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());
                    Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                    Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match emailMatch = email.Match(emailBox.Text);

                    Regex phone = new Regex(@"^[+0-9]*$");
                    Match phoneMatch = phone.Match(phoneBox.Text.Trim());

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
                    else
                    {
                        newTeacher.Name = nameBox.Text.Trim();
                        newTeacher.Surname = surnameBox.Text.Trim();
                        newTeacher.Email = emailBox.Text.Trim();
                        newTeacher.Phone = phoneBox.Text.Trim();
                        newTeacher.SpecialityId = specialityId;
                        db.SaveChanges();
                        FillTeachers();
                        Reset();
                    }
                   
                }
            }
        }

        private void TeachersTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int teacherId = Convert.ToInt32(teachersTable.Rows[e.RowIndex].Cells[0].Value);

            using (AcademyEntities db = new AcademyEntities())
            {
                teacherFound = db.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();

                if (teacherFound != null)
                {
                    nameBox.Text = teacherFound.Name;
                    surnameBox.Text = teacherFound.Surname;
                    emailBox.Text = teacherFound.Email;
                    phoneBox.Text = teacherFound.Phone;
                    specialityDrop.SelectedItem = teacherFound.Specialities.Name;
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeleteTeacher(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int teacherId = Convert.ToInt32(teachersTable.SelectedRows[0].Cells[0].Value);

                Models.Teachers t1 = db.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();
                t1.Status = false;
                db.SaveChanges();
            }
            FillTeachers();
            Reset();
        }
    }
}
