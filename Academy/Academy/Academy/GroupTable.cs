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
    public partial class GroupTable : Form
    {
        public GroupTable()
        {
            InitializeComponent();
            FillGroups();
            FillClassroomDrop();
            FillTeacherDrop();
            FillMentorDrop();
            FillEducationDrop();
        }

        private void FillGroups()
        {
            groupsTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList = db.Groups.ToList();

                foreach (var g in groupsList)
                {
                    List<Models.Employees> mentorsList = db.Employees.Where(m => m.Id == g.MentorId).ToList();
                    string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;
                    if (g.Status == true)
                    {
                        groupsTable.Rows.Add(g.Id,
                                             g.Name,
                                             g.Classrooms.Name,
                                             g.Teachers.Name + " " + g.Teachers.Surname,
                                             mentorFullname,
                                             g.Education_Programs.Name,
                                             g.Capacity);
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

        private void SearchGroup(object sender, EventArgs e)
        {
            List<Models.Groups> groupsList;
            string searchText = searchBox.Text.ToLower().Trim();
            using (AcademyEntities db = new AcademyEntities())
            {

                if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                       g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText)).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                       (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                 (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                       (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() &&
                                                 (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() &&
                                                       (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else if (educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Education_Programs.Name == educationDrop.SelectedItem.ToString() &&
                                                      (g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText))).ToList();
                }
                else
                {
                    groupsList = db.Groups.Where(g => g.Name.ToLower().Contains(searchText) ||
                                                       (g.Teachers.Name + " " + g.Teachers.Surname).ToLower().Contains(searchText) ||
                                                       g.Classrooms.Name.ToLower().Contains(searchText) ||
                                                       (g.Employees.Name + " " + g.Employees.Surname).ToLower().Contains(searchText) ||
                                                       g.Education_Programs.Name.ToLower().Contains(searchText) ||
                                                       g.Capacity.ToString().Contains(searchText)).ToList();
                }


                groupsTable.Rows.Clear();
                foreach (var g in groupsList)
                {
                    if (g.Status == true)
                    {
                        string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;

                        groupsTable.Rows.Add(g.Id,
                                                                   g.Name,
                                                                   g.Classrooms.Name,
                                                                   g.Teachers.Name + " " + g.Teachers.Surname,
                                                                   mentorFullname,
                                                                   g.Education_Programs.Name,
                                                                   g.Capacity);
                    }
                }
            }

        }

        private void ClassroomSelected(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList;

                if (classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();

                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString()).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString()).ToList();
                }

                else
                {
                    groupsList = db.Groups.ToList();
                }

                groupsTable.Rows.Clear();
                foreach (var g in groupsList)
                {
                    string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;

                    groupsTable.Rows.Add(g.Id,
                                         g.Name,
                                         g.Classrooms.Name,
                                         g.Teachers.Name + " " + g.Teachers.Surname,
                                         mentorFullname,
                                         g.Education_Programs.Name,
                                         g.Capacity);
                }
            }
        }

        private void TeacherSelected(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList;
                if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    groupsList = db.Groups.ToList();
                }


                groupsTable.Rows.Clear();
                foreach (var g in groupsList)
                {
                    string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;

                    groupsTable.Rows.Add(g.Id,
                                         g.Name,
                                         g.Classrooms.Name,
                                         g.Teachers.Name + " " + g.Teachers.Surname,
                                         mentorFullname,
                                         g.Education_Programs.Name,
                                         g.Capacity);
                }
            }
        }

        private void MentorSelected(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList;


                if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();

                }
                else if (classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();
                }
                else if (mentorDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    groupsList = db.Groups.ToList();
                }

                groupsTable.Rows.Clear();
                foreach (var g in groupsList)
                {
                    string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;

                    groupsTable.Rows.Add(g.Id,
                                         g.Name,
                                         g.Classrooms.Name,
                                         g.Teachers.Name + " " + g.Teachers.Surname,
                                         mentorFullname,
                                         g.Education_Programs.Name,
                                         g.Capacity);
                }
            }
        }

        private void EducationSelected(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Groups> groupsList;

                if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && classroomDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (mentorDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Employees.Name + " " + g.Employees.Surname == mentorDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (teacherDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Teachers.Name + " " + g.Teachers.Surname == teacherDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (classroomDrop.SelectedIndex >= 0 && educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Classrooms.Name == classroomDrop.SelectedItem.ToString() && g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else if (educationDrop.SelectedIndex >= 0)
                {
                    groupsList = db.Groups.Where(g => g.Education_Programs.Name == educationDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    groupsList = db.Groups.ToList();
                }

                groupsTable.Rows.Clear();
                foreach (var g in groupsList)
                {
                    string mentorFullname = (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Name + " " + (db.Employees.Where(m => m.Id == g.MentorId).FirstOrDefault()).Surname;

                    groupsTable.Rows.Add(g.Id,
                                         g.Name,
                                         g.Classrooms.Name,
                                         g.Teachers.Name + " " + g.Teachers.Surname,
                                         mentorFullname,
                                         g.Education_Programs.Name,
                                         g.Capacity);
                }

            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            classroomDrop.SelectedIndex = -1;
            teacherDrop.SelectedIndex = -1;
            mentorDrop.SelectedIndex = -1;
            educationDrop.SelectedIndex = -1;
            searchBox.Clear();
        }
    }
}
