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
    public partial class PositionCRUD : Form
    {
        Models.Positions positionFound = new Models.Positions();
        public PositionCRUD()
        {
            InitializeComponent();
            FillPositions();
            deleteBtn.Enabled = false;
        }

        private void FillPositions()
        {
            positionTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Positions> positionsList = db.Positions.ToList();

                foreach (var p in positionsList)
                {
                    if (p.Status == true)
                    {
                        positionTable.Rows.Add(p.Id,
                                               p.Name);
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

        private void AddPosition(object sender , EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Positions> passiveList = db.Positions.Where(p => p.Status == false).ToList();
                    Models.Positions passivePosition = db.Positions.Where(c => c.Name == nameBox.Text.Trim()).FirstOrDefault();


                    if (passiveList.Contains(passivePosition))
                    {
                        passivePosition.Status = true;
                        db.SaveChanges();
                        FillPositions();
                        Reset();
                    }
                    else
                    {
                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name contains only letters");
                        }
                        else
                        {
                            Models.Positions p1 = new Models.Positions
                            {
                                Name = nameBox.Text.Trim(),
                                Status = true
                            };
                            db.Positions.Add(p1);
                            db.SaveChanges();
                            FillPositions();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int positionId = Convert.ToInt32(positionTable.SelectedRows[0].Cells[0].Value);

                    Regex letters = new Regex(@"^[A-Za-z ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());

                    if (!nameMatch.Success)
                    {
                        MessageBox.Show("Name contains only letters");
                    }
                    else
                    {
                        Models.Positions newPosition = db.Positions.Where(p => p.Id == positionId).FirstOrDefault();

                        newPosition.Name = nameBox.Text.Trim();

                        db.SaveChanges();
                        FillPositions();
                        Reset();
                    }
                }
            }
        }

        private void PositionTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int positionId = Convert.ToInt32(positionTable.Rows[e.RowIndex].Cells[0].Value);


            using (AcademyEntities db = new AcademyEntities())
            {
                positionFound = db.Positions.Where(p => p.Id == positionId).FirstOrDefault();

                if (positionFound != null)
                {
                    nameBox.Text = positionFound.Name;
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeletePosition(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int positionId = Convert.ToInt32(positionTable.SelectedRows[0].Cells[0].Value);

                Models.Positions p1 = db.Positions.Where(p => p.Id == positionId).FirstOrDefault();
                p1.Status = false;
                db.SaveChanges();
            }
            FillPositions();
            Reset();
        }
    }
}
