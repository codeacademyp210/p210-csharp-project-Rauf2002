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
    public partial class GroupCRUD : Form
    {
        Models.Groups groupFound = new Models.Groups();
        public GroupCRUD()
        {
            InitializeComponent();
            FillGroups();
            FillClassroomDrop();
            FillTeacherDrop();
            FillMentorDrop();
            FillEducationDrop();
            deleteBtn.Enabled = false;
        }

        private void FillGroups()
        {
            groupsTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList = db.Groups.ToList();

                foreach (var g in groupsList)
                {
                    if (g.Status == true)
                    {
                        groupsTable.Rows.Add(g.Id,
                                             g.Name,
                                             g.Classrooms.Name,
                                             g.Teachers.Name + " " + g.Teachers.Surname,
                                             g.Education_Programs.Name);
                    }
                }
            }
        }

        private void FillClassroomDrop()
        {
            classroomDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Classrooms> clasroomsList = db.Classrooms.ToList();

                foreach (var c in clasroomsList)
                {
                    if (c.Status == true)
                    {
                        classroomDrop.Items.Add(c.Name);
                    }
                }
            }
        }

        private void FillTeacherDrop()
        {
            teacherDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Teachers> teachersList = db.Teachers.ToList();

                foreach (var t in teachersList)
                {
                    if (t.Status == true)
                    {
                        teacherDrop.Items.Add(t.Name + " " + t.Surname);
                    }
                }
            }
        }


        private void FillMentorDrop()
        {
            mentorDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Employees> mentorsList = db.Employees.Where(e => e.Positions.Name == "Mentor").ToList();

                foreach (var m in mentorsList)
                {
                    if (m.Status == true)
                    {
                        mentorDrop.Items.Add(m.Name + " " + m.Surname);
                    }
                }
            }
        }

        private void FillEducationDrop()
        {
            educationDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Education_Programs> educationList = db.Education_Programs.ToList();

                foreach (var e in educationList)
                {
                    if (e.Status == true)
                    {
                        educationDrop.Items.Add(e.Name);
                    }
                }
            }
        }

        private void Reset()
        {
            nameBox.Clear();
            classroomDrop.SelectedIndex = -1;
            teacherDrop.SelectedIndex = -1;
            mentorDrop.SelectedIndex = -1;
            educationDrop.SelectedIndex = -1;
            capacityBox.Clear();
            saveBtn.Text = "Save";
            deleteBtn.Enabled = false;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void AddGroup(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Groups> passiveList = db.Groups.Where(g => g.Status == false).ToList();
                    Models.Groups passiveGroup = db.Groups.Where(g => g.Name == nameBox.Text.Trim()).FirstOrDefault();

                    if (passiveList.Contains(passiveGroup))
                    {
                        Regex letters = new Regex(@"^[A-Za-z0-9]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());

                        Regex numbers = new Regex(@"^[0-9]*$");
                        Match capacityMatch = numbers.Match(capacityBox.Text.Trim());

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name contains only letters");
                        }
                        else if (!capacityMatch.Success)
                        {
                            MessageBox.Show("Capacity contains only numbers");
                        }
                        else
                        {
                            passiveGroup.Status = true;
                            db.SaveChanges();
                            FillGroups();
                            Reset();
                        }
                    }
                    else
                    {
                        Regex letters = new Regex(@"^[A-Za-z0-9]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());

                        Regex numbers = new Regex(@"^[0-9]*$");
                        Match capacityMatch = numbers.Match(capacityBox.Text.Trim());

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name contains only letters");
                        }
                        else if (!capacityMatch.Success)
                        {
                            MessageBox.Show("Capacity contains only numbers");
                        }
                        else
                        {
                            int classroomId = (db.Classrooms.Where(c => c.Name == classroomDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                            int teacherId = (db.Teachers.Where(t => t.Name + " " + t.Surname == teacherDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                            int mentorId = (db.Employees.Where(m => m.Positions.Name == "Mentor" && m.Name + " " + m.Surname == mentorDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                            int educationId = (db.Education_Programs.Where(p => p.Name == educationDrop.SelectedItem.ToString()).FirstOrDefault()).Id;


                            Models.Groups g1 = new Models.Groups
                            {
                                Name = nameBox.Text.Trim(),
                                Capacity = Convert.ToInt32(capacityBox.Text.Trim()),
                                ClassroomId = classroomId,
                                TeacherId = teacherId,
                                MentorId = mentorId,
                                EducationId = educationId,
                                Status = true
                            };

                            db.Groups.Add(g1);
                            db.SaveChanges();
                            FillGroups();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int groupId = Convert.ToInt32(groupsTable.SelectedRows[0].Cells[0].Value);
                    int classroomId = (db.Classrooms.Where(c => c.Name == classroomDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                    int teacherId = (db.Teachers.Where(t => t.Name + " " + t.Surname == teacherDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                    int mentorId = (db.Employees.Where(m => m.Positions.Name == "Mentor" && m.Name + " " + m.Surname == mentorDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                    int educationId = (db.Education_Programs.Where(p => p.Name == educationDrop.SelectedItem.ToString()).FirstOrDefault()).Id;

                    Models.Groups newGroup = db.Groups.Where(g => g.Id == groupId).FirstOrDefault();

                    Regex letters = new Regex(@"^[A-Za-z0-9]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());

                    Regex numbers = new Regex(@"^[0-9]*$");
                    Match capacityMatch = numbers.Match(capacityBox.Text.Trim());

                    if (!nameMatch.Success)
                    {
                        MessageBox.Show("Name contains only letters");
                    }
                    else if (!capacityMatch.Success)
                    {
                        MessageBox.Show("Capacity contains only numbers");
                    }
                    else
                    {
                        newGroup.Name = nameBox.Text;
                        newGroup.Capacity = Convert.ToInt32(capacityBox.Text);
                        newGroup.ClassroomId = classroomId;
                        newGroup.TeacherId = teacherId;
                        newGroup.MentorId = mentorId;
                        newGroup.EducationId = educationId;
                        db.SaveChanges();
                        FillGroups();
                        Reset();
                    }
                }
            }
        }

        private void GroupsTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int groupId = Convert.ToInt32(groupsTable.Rows[e.RowIndex].Cells[0].Value);

            using (AcademyEntities db = new AcademyEntities())
            {
                groupFound = db.Groups.Where(g => g.Id == groupId).FirstOrDefault();

                if (groupFound != null)
                {
                    nameBox.Text = groupFound.Name;
                    capacityBox.Text = groupFound.Capacity.ToString();
                    classroomDrop.SelectedItem = groupFound.Classrooms.Name;
                    teacherDrop.SelectedItem = groupFound.Teachers.Name + " " + groupFound.Teachers.Surname;
                    mentorDrop.SelectedItem = groupFound.Employees.Name + " " + groupFound.Employees.Surname;
                    educationDrop.SelectedItem = groupFound.Education_Programs.Name;
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeleteGroup(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int groupId = Convert.ToInt32(groupsTable.SelectedRows[0].Cells[0].Value);

                Models.Groups g1 = db.Groups.Where(g => g.Id == groupId).FirstOrDefault();
                g1.Status = false;
                db.SaveChanges();
            }
            FillGroups();
            Reset();
        }

    }
}
