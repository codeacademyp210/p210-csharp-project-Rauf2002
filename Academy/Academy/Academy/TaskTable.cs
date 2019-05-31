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
    public partial class TaskTable : Form
    {
        public TaskTable()
        {
            InitializeComponent();
            FillTasks();
            ColorRow();
            FillGroupDrop();
            FillTaskDrop();
        }

        private void FillTasks()
        {
            tasksTable.Rows.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Tasks> tasksList = db.Tasks.ToList();

                foreach (var t in tasksList)
                {
                    tasksTable.Rows.Add(t.Id,
                                        t.GroupId,
                                        t.Name,
                                        t.Groups.Name,
                                        t.Deadline);
                }
            }
        }

        private void TasksTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int taskId = Convert.ToInt32(tasksTable.SelectedRows[0].Cells[0].Value);
            int groupId = Convert.ToInt32(tasksTable.SelectedRows[0].Cells[1].Value);
            GradeTable TableForm = new GradeTable(taskId, groupId);
            TableForm.ShowDialog();
        }

        private void ColorRow()
        {
            using (AcademyEntities db = new AcademyEntities())
            {
               //&& (db.Grades.Where(g => (g.Tasks.Groups.Students.FirstOrDefault()).GroupId == groupId).FirstOrDefault()).Grade == null


                for (int r = 0; r < (tasksTable.Rows.Count - 1); r++)
                {
                    for (int c = 0; c < tasksTable.Rows[r].Cells.Count; c++)
                    {
                        bool notMarked = false;
                        int groupId = Convert.ToInt32(tasksTable.Rows[r].Cells[1].Value);

                        int taskID = Convert.ToInt32(tasksTable.Rows[r].Cells[0].Value);
                        Models.Tasks taskFound = db.Tasks.FirstOrDefault(t => t.Id == taskID);

                        var studentList =  db.Students.Where(s => s.GroupId == groupId).ToList();

                        foreach (var student in studentList)
                        {
                            Models.Grades gradeFound = taskFound.Grades.FirstOrDefault(g => g.StudentId == student.Id && g.TaskId == taskFound.Id);
                            if (gradeFound == null )
                            {
                                notMarked = true;
                                break;
                            }
                        }

                        if (Convert.ToDateTime(tasksTable.Rows[r].Cells[4].Value) < DateTime.Now && notMarked == true)
                        {
                            tasksTable.Rows[r].Cells[c].Style.BackColor = Color.Red;
                            tasksTable.Rows[r].Cells[c].Style.ForeColor = Color.White;
                        }
                        if (Convert.ToDateTime(tasksTable.Rows[r].Cells[4].Value) > DateTime.Now)
                        {
                            tasksTable.Rows[r].Cells[c].Style.BackColor = Color.Green;
                            tasksTable.Rows[r].Cells[c].Style.ForeColor = Color.White;
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
        private void FillTaskDrop()
        {
            taskDrop.Items.Clear();

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Tasks> tasksList = db.Tasks.ToList();

                foreach (var t in tasksList)
                {
                    if (t.Status == true)
                    {
                        taskDrop.Items.Add(t.Name);
                    }
                }
            }
        }

        private void GroupDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Tasks> tasksList;




                if(groupDrop.SelectedIndex >= 0 && taskDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Groups.Name == groupDrop.SelectedItem.ToString() && t.Name == taskDrop.SelectedItem.ToString()).ToList();

                }
                else if (groupDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Groups.Name == groupDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    tasksList = db.Tasks.ToList();
                }

                tasksTable.Rows.Clear();
                foreach (var t in tasksList)
                {
                    tasksTable.Rows.Add(t.Id,
                                        t.GroupId,
                                        t.Name,
                                        t.Groups.Name,
                                        t.Deadline);
                }
                ColorRow();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            groupDrop.SelectedIndex = -1;
            taskDrop.SelectedIndex = -1;
            searchBox.Clear();
        }

        private void TaskDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Tasks> tasksList;




                if (groupDrop.SelectedIndex >= 0 && taskDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Groups.Name == groupDrop.SelectedItem.ToString() && t.Name == taskDrop.SelectedItem.ToString()).ToList();

                }
                else if (taskDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Name == taskDrop.SelectedItem.ToString()).ToList();
                }
                else
                {
                    tasksList = db.Tasks.ToList();
                }

                tasksTable.Rows.Clear();
                foreach (var t in tasksList)
                {
                    tasksTable.Rows.Add(t.Id,
                                        t.GroupId,
                                        t.Name,
                                        t.Groups.Name,
                                        t.Deadline);
                }
                ColorRow();

            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            List<Models.Tasks> tasksList;
            string searchText = searchBox.Text.ToLower().Trim();

            using (AcademyEntities db = new AcademyEntities())
            {
                if (groupDrop.SelectedIndex >= 0 && taskDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Groups.Name == groupDrop.SelectedItem.ToString() && t.Name == taskDrop.SelectedItem.ToString() &&
                                                    (t.Name.ToLower().Contains(searchText) ||
                                                    t.Groups.Name.ToLower().Contains(searchText) ||
                                                    t.Deadline.ToString().ToLower().Contains(searchText))).ToList();

                }
                else if (taskDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Name == taskDrop.SelectedItem.ToString() &&
                                                (t.Name.ToLower().Contains(searchText) ||
                                                    t.Groups.Name.ToLower().Contains(searchText) ||
                                                    t.Deadline.ToString().ToLower().Contains(searchText))).ToList();
                }
                else if (groupDrop.SelectedIndex >= 0)
                {
                    tasksList = db.Tasks.Where(t => t.Groups.Name == groupDrop.SelectedItem.ToString() &&
                                                    (t.Name.ToLower().Contains(searchText) ||
                                                    t.Groups.Name.ToLower().Contains(searchText) ||
                                                    t.Deadline.ToString().ToLower().Contains(searchText))).ToList();
                }
                else
                {
                    tasksList = db.Tasks.Where(t => t.Name.ToLower().Contains(searchText) ||
                                                    t.Groups.Name.ToLower().Contains(searchText) ||
                                                    t.Deadline.ToString().ToLower().Contains(searchText)).ToList();
                }

                tasksTable.Rows.Clear();
                foreach (var t in tasksList)
                {
                    tasksTable.Rows.Add(t.Id,
                                        t.GroupId,
                                        t.Name,
                                        t.Groups.Name,
                                        t.Deadline);
                }
                ColorRow();

            }
        }
    }
}
