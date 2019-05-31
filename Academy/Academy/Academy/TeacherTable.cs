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
    public partial class TeacherTable : Form
    {
        public TeacherTable()
        {
            InitializeComponent();
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
                                           t.Email,
                                           t.Phone,
                                           t.Specialities.Name);
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

        private void SpecialityDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Teachers> teachersList;
                if (specialityDrop.SelectedIndex >= 0)
                {
                   teachersList = db.Teachers.Where(t => t.Specialities.Name == specialityDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    teachersList = db.Teachers.ToList();
                }


                teachersTable.Rows.Clear();
                foreach (var t in teachersList)
                {
                    if (t.Status == true)
                    {
                        teachersTable.Rows.Add(t.Id,
                  t.Name,
                  t.Surname,
                  t.Email,
                  t.Phone,
                  t.Specialities.Name);
                    }
                }

            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Teachers> teachersList;
                string searchText = searchBox.Text.ToLower().Trim();

                if (specialityDrop.SelectedIndex >= 0)
                {
                    teachersList = db.Teachers.Where(t => t.Specialities.Name == specialityDrop.SelectedItem.ToString() &&
                                                          (t.Name.ToLower().Contains(searchText) ||
                                                          t.Surname.ToLower().Contains(searchText) ||
                                                          t.Phone.ToLower().Contains(searchText) ||
                                                          t.Specialities.Name.ToLower().Contains(searchText) ||
                                                          t.Email.ToLower().Contains(searchText))).ToList();
                }
                else
                {
                    teachersList = db.Teachers.Where(t => t.Name.ToLower().Contains(searchText) ||
                                                          t.Surname.ToLower().Contains(searchText) ||
                                                          t.Phone.ToLower().Contains(searchText) ||
                                                          t.Specialities.Name.ToLower().Contains(searchText) ||
                                                          t.Email.ToLower().Contains(searchText)).ToList();
                }


                teachersTable.Rows.Clear();
                foreach (var t in teachersList)
                {
                    if (t.Status == true)
                    {
                        teachersTable.Rows.Add(t.Id,
                                           t.Name,
                                           t.Surname,
                                           t.Email,
                                           t.Phone,
                                           t.Specialities.Name);
                    }
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            specialityDrop.SelectedIndex = -1;
            searchBox.Clear();
        }
    }
}
