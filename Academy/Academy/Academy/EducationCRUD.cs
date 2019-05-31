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
    public partial class EducationCRUD : Form
    {
        Models.Education_Programs educationFound = new Models.Education_Programs();
        public EducationCRUD()
        {
            InitializeComponent();
            FillEducation();
            deleteBtn.Enabled = false;
        }

        private void FillEducation()
        {
            educationTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Education_Programs> educationList = db.Education_Programs.ToList();

                foreach (var e in educationList)
                {
                    if (e.Status == true)
                    {
                        educationTable.Rows.Add(e.Id,
                                                e.Name,
                                                e.Price);
                    }
                }
            }
        }

        private void Reset()
        {
            saveBtn.Text = "Save";
            deleteBtn.Enabled = false;
            nameBox.Clear();
            priceBox.Clear();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }


        private void AddClassroom(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Education_Programs> passiveList = db.Education_Programs.Where(p => p.Status == false).ToList();
                    Models.Education_Programs passiveEducation = db.Education_Programs.Where(p => p.Name == nameBox.Text.Trim()).FirstOrDefault();


                    if (passiveList.Contains(passiveEducation))
                    {
                        passiveEducation.Status = true;
                        db.SaveChanges();
                        FillEducation();
                        Reset();
                    }
                    else
                    {
                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());


                        Regex numbers = new Regex(@"^[0-9]+$");
                        Match priceMatch = numbers.Match(priceBox.Text.Trim());

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name contains only letters and numbers");
                        }
                        else if (!priceMatch.Success)
                        {
                            MessageBox.Show("Price contains only numbers");
                        }
                        else
                        {
                            Models.Education_Programs e1 = new Models.Education_Programs
                            {
                                Name = nameBox.Text.Trim(),
                                Price = Convert.ToInt32(priceBox.Text.Trim()),
                                Status = true
                            };
                            db.Education_Programs.Add(e1);
                            db.SaveChanges();
                            FillEducation();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int educationId = Convert.ToInt32(educationTable.SelectedRows[0].Cells[0].Value);

                    Regex letters = new Regex(@"^[A-Za-z ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());


                    Regex numbers = new Regex(@"^[0-9]+$");
                    Match priceMatch = numbers.Match(priceBox.Text.Trim());

                    if (!nameMatch.Success)
                    {
                        MessageBox.Show("Name contains only letters and numbers");
                    }
                    else if (!priceMatch.Success)
                    {
                        MessageBox.Show("Price contains only numbers");
                    }
                    else
                    {
                        Models.Education_Programs newEducation = db.Education_Programs.Where(p => p.Id == educationId).FirstOrDefault();

                        newEducation.Name = nameBox.Text.Trim();
                        newEducation.Price = Convert.ToInt32(priceBox.Text.Trim());

                        db.SaveChanges();
                        FillEducation();
                        Reset();

                    }
                }
            }

        }

        private void EducationTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int educationId = Convert.ToInt32(educationTable.Rows[e.RowIndex].Cells[0].Value);


            using (AcademyEntities db = new AcademyEntities())
            {
                educationFound = db.Education_Programs.Where(p => p.Id == educationId).FirstOrDefault();

                if (educationFound != null)
                {
                    nameBox.Text = educationFound.Name;
                    priceBox.Text = educationFound.Price.ToString();
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeleteEducation(object sender, EventArgs e)
        {
            int educationId = Convert.ToInt32(educationTable.SelectedRows[0].Cells[0].Value);


            using (AcademyEntities db = new AcademyEntities())
            {
                Models.Education_Programs e1 = db.Education_Programs.Where(p=> p.Id == educationId).FirstOrDefault();
                e1.Status = false;
                db.SaveChanges();
            }
            FillEducation();
            Reset();
        }
    }
}