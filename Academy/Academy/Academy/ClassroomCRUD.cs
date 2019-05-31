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
    public partial class ClassroomCRUD : Form
    {
        Models.Classrooms classroomFound = new Models.Classrooms();
        public ClassroomCRUD()
        {
            InitializeComponent();
            FillClassrooms();
            deleteBtn.Enabled = false;
        }

        private void FillClassrooms()
        {
            classroomsTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Classrooms> classroomsList = db.Classrooms.ToList();

                foreach (var c in classroomsList)
                {
                    if (c.Status == true)
                    {
                        classroomsTable.Rows.Add(c.Id,
                                                 c.Name);
                    }
                }
            }
        }

        private void Reset()
        {
            saveBtn.Text = "Save";
            deleteBtn.Enabled = false;
            nameBox.Clear();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void AddClassroom(object sender, EventArgs e)
        {
            if(saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Classrooms> passiveList = db.Classrooms.Where(c => c.Status == false).ToList();
                    Models.Classrooms passiveClassroom = db.Classrooms.Where(c => c.Name == nameBox.Text.Trim()).FirstOrDefault();


                    if (passiveList.Contains(passiveClassroom))
                    {
                        passiveClassroom.Status = true;
                        db.SaveChanges();
                        FillClassrooms();
                        Reset();
                    }
                    else
                    {
                        Regex lettersAndNumbers = new Regex(@"^[A-Za-z0-9]+$");
                        Match nameMatch = lettersAndNumbers.Match(nameBox.Text.Trim());

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name contains only letters and numbers");
                        }
                        else
                        {
                            Models.Classrooms c1 = new Models.Classrooms
                            {
                                Name = nameBox.Text.Trim(),
                                Status = true
                            };
                            db.Classrooms.Add(c1);
                            db.SaveChanges();
                            FillClassrooms();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int classroomId = Convert.ToInt32(classroomsTable.SelectedRows[0].Cells[0].Value);

                    Regex lettersAndNumbers = new Regex(@"^[A-Za-z0-9]+$");
                    Match nameMatch = lettersAndNumbers.Match(nameBox.Text.Trim());

                    if (!nameMatch.Success)
                    {
                        MessageBox.Show("Name contains only letters and numbers");
                    }
                    else
                    {
                        Models.Classrooms newClassroom = db.Classrooms.Where(c => c.Id == classroomId).FirstOrDefault();

                        newClassroom.Name = nameBox.Text.Trim();

                        db.SaveChanges();
                        FillClassrooms();
                        Reset();
                    }
                }
            }
        }

        private void ClassroomsTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int classroomId = Convert.ToInt32(classroomsTable.Rows[e.RowIndex].Cells[0].Value);


            using (AcademyEntities db = new AcademyEntities())
            {
                classroomFound = db.Classrooms.Where(c => c.Id == classroomId).FirstOrDefault();

                if (classroomFound != null)
                {
                    nameBox.Text = classroomFound.Name;
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }


        private void DeleteClassroom(object sender , EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int classroomId = Convert.ToInt32(classroomsTable.SelectedRows[0].Cells[0].Value);

                Models.Classrooms c1 = db.Classrooms.Where(c => c.Id == classroomId).FirstOrDefault();
                c1.Status = false;
                db.SaveChanges();
            }
            FillClassrooms();
            Reset();
        }
    }
}
