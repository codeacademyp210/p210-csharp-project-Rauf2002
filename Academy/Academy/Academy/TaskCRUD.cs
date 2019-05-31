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
    public partial class TaskCRUD : Form
    {
        Models.Tasks taskFound = new Models.Tasks();
        public TaskCRUD()
        {
            InitializeComponent();
            FillTasks();
            deleteBtn.Enabled = false;
            deadlineTimePicker.MinDate = DateTime.Now;
            FillGroupDrop();
        }

        private void FillTasks()
        {
            tasksTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Tasks> tasksList= db.Tasks.ToList();

                foreach (var t in tasksList)
                {
                    if (t.Status == true)
                    {
                        tasksTable.Rows.Add(t.Id,
                                            t.Name,
                                            t.Deadline,
                                            t.Groups.Name);
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
            deadlineTimePicker.Value = DateTime.Now;
            groupDrop.SelectedIndex = -1;
            deleteBtn.Enabled = false;
            saveBtn.Text = "Save";
        }

        private void AddTask(object sender , EventArgs e)
        {
            if(saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Tasks> passiveList = db.Tasks.Where(t => t.Status == false).ToList();
                    Models.Tasks passiveTask = db.Tasks.Where(t => t.Name == nameBox.Text.Trim()).FirstOrDefault();

                    if (passiveList.Contains(passiveTask))
                    {
                        passiveTask.Status = true;
                        db.SaveChanges();
                        FillTasks();
                        Reset();
                    }
                    else
                    {
                     

                        Regex letters = new Regex(@"^[A-Za-z0-9#+ ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());

                        int groupId = (db.Groups.Where(g => g.Name == groupDrop.SelectedItem.ToString()).FirstOrDefault()).Id;

                        if (!nameMatch.Success)
                        {
                            MessageBox.Show("Name  contain only letters and numbers");
                        }
                        else
                        {
                            Models.Tasks t1 = new Models.Tasks
                            {
                                Name = nameBox.Text.Trim(),
                                Deadline = deadlineTimePicker.Value,
                                GroupId = groupId,
                                Status = true
                            };
                            db.Tasks.Add(t1);
                            db.SaveChanges();
                            FillTasks();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int taskId = Convert.ToInt32(tasksTable.SelectedRows[0].Cells[0].Value);
                    int groupId = (db.Groups.Where(g => g.Name == groupDrop.SelectedItem.ToString()).FirstOrDefault()).Id;


                    Regex letters = new Regex(@"^[A-Za-z0-9#+ ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());

                    if (!nameMatch.Success)
                    {
                        MessageBox.Show("Name  contain only letters and numbers");
                    }
                    else
                    {
                        Models.Tasks newTask= db.Tasks.Where(t => t.Id == taskId).FirstOrDefault();

                        newTask.Name = nameBox.Text.Trim();
                        newTask.Deadline = deadlineTimePicker.Value;
                        newTask.GroupId = groupId;

                        db.SaveChanges();
                        FillTasks();
                        Reset();
                    }
                }
            }
        }

        private void DeleteTask(object sender , EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int taskId = Convert.ToInt32(tasksTable.SelectedRows[0].Cells[0].Value);

                Models.Tasks t1 = db.Tasks.Where(c => c.Id == taskId).FirstOrDefault();
                t1.Status = false;
                db.SaveChanges();
            }
            FillTasks();
            Reset();
        }

        private void TasksTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int taskId = Convert.ToInt32(tasksTable.Rows[e.RowIndex].Cells[0].Value);


            using (AcademyEntities db = new AcademyEntities())
            {
                taskFound = db.Tasks.Where(t => t.Id == taskId).FirstOrDefault();

                if (taskFound != null)
                {
                    nameBox.Text = taskFound.Name;
                    deadlineTimePicker.Value = taskFound.Deadline;
                    groupDrop.SelectedItem = taskFound.Groups.Name;
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
