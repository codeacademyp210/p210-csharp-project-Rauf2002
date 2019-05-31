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
    public partial class EmployeeTable : Form
    {
        int minSalary = 0, maxSalary = 0;
        public EmployeeTable()
        {
            InitializeComponent();
            FillEmployees();
            FillPositionDrop();
        }

        private void FillEmployees()
        {
            employeesTable.Rows.Clear();
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Employees> employeeList = db.Employees.ToList();

                foreach (var e in employeeList)
                {
                    if (e.Status == true)
                    {
                        employeesTable.Rows.Add(e.Id,
                                           e.Name,
                                           e.Surname,
                                           e.Email,
                                           e.Phone,
                                           e.Positions.Name,
                                           e.StartTime,
                                           e.Salary);
                    }
                }
            }
        }

        private void SearchEmployee(object sender, EventArgs e)
        {
            //List<Models.Employees> employeesList;
            string searchText = searchBox.Text.ToLower().Trim();
            //int minimumSalary = Convert.ToInt32(minimumBox.Text);
            //int maximumSalary = Convert.ToInt32(maximumBox.Text);
            using (AcademyEntities db = new AcademyEntities())
            {
                //if (!string.IsNullOrEmpty(minimumBox.Text))
                //{
                //    employeesList = db.Employees.Where(i => i.Salary >= minimumSalary &&
                //                                            (i.Name.ToLower().Contains(searchText) ||
                //                                                        i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText))).ToList();
                //}
                //if (!string.IsNullOrEmpty(maximumBox.Text))
                //{
                //    employeesList = db.Employees.Where(i => i.Salary <= maximumSalary && 
                //                                            (i.Name.ToLower().Contains(searchText) ||
                //                                                        i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText))).ToList();
                //}
                //if (!string.IsNullOrEmpty(minimumBox.Text) && !string.IsNullOrEmpty(maximumBox.Text))
                //{
                //    employeesList = db.Employees.Where(i => i.Salary >= maximumSalary && i.Salary <= maximumSalary &&
                //                                            (i.Name.ToLower().Contains(searchText) ||
                //                                                        i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText))).ToList();
                //}
                //if (positionDrop.SelectedIndex > 0)
                //{
                //    employeesList = db.Employees.Where(i => i.Positions.Name == positionDrop.SelectedItem.ToString() &&
                //                                            (i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText))).ToList();
                //}
                //if (!string.IsNullOrEmpty(minimumBox.Text) && positionDrop.SelectedIndex > 0)
                //{
                //    employeesList = db.Employees.Where(i => i.Salary >= minimumSalary && i.Name == positionDrop.SelectedItem.ToString() &&
                //                                            (i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText))).ToList();
                //}
                //else
                //{
                //    employeesList = db.Employees.Where(i => i.Name.ToLower().Contains(searchText) ||
                //                                                        i.Surname.ToLower().Contains(searchText) ||
                //                                                        i.Email.ToLower().Contains(searchText) ||
                //                                                        i.Phone.ToLower().Contains(searchText) ||
                //                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                //                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                //                                                        i.Salary.ToString().ToLower().Contains(searchText)).ToList();
                //}


               List <Models.Employees> employeesList = db.Employees.Where(i => i.Name.ToLower().Contains(searchText) ||
                                                                        i.Surname.ToLower().Contains(searchText) ||
                                                                        i.Email.ToLower().Contains(searchText) ||
                                                                        i.Phone.ToLower().Contains(searchText) ||
                                                                        i.Positions.Name.ToLower().Contains(searchText) ||
                                                                        i.StartTime.ToString().ToLower().Contains(searchText) ||
                                                                        i.Salary.ToString().ToLower().Contains(searchText)).ToList();

                employeesTable.Rows.Clear();

                foreach (var i in employeesList)
                {
                    if (i.Status == true)
                    {
                        employeesTable.Rows.Add(i.Id,
                                        i.Name,
                                        i.Surname,
                                        i.Email,
                                        i.Phone,
                                        i.Positions.Name,
                                        i.StartTime,
                                        i.Salary);
                    }

                }
            }

        }

        private void MinimumSalary(object sender, EventArgs e)
        {

            Regex numbers = new Regex(@"^[0-9]*$");
            Match salaryMatch = numbers.Match(minimumBox.Text);

            if (!salaryMatch.Success)
            {
                MessageBox.Show("Salary contains only numbers");
                minimumBox.Clear();
            }
            else
            {
                if (!string.IsNullOrEmpty(minimumBox.Text))
                {
                    minSalary = Convert.ToInt32(minimumBox.Text);
                }

                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Employees> employeesList;
                    if (maxSalary != 0)
                    {
                        employeesList = db.Employees.Where(i => i.Salary >= minSalary && i.Salary <= maxSalary).ToList();
                    }
                    else
                    {
                        employeesList = db.Employees.Where(i => i.Salary >= minSalary).ToList();
                    }

                    employeesTable.Rows.Clear();
                    foreach (var i in employeesList)
                    {
                        if (i.Status == true)
                        {
                            employeesTable.Rows.Add(i.Id,
                                        i.Name,
                                        i.Surname,
                                        i.Email,
                                        i.Phone,
                                        i.Positions.Name,
                                        i.StartTime,
                                        i.Salary);
                        }
                    }
                }
            }
        }



        private void MaximumSalary(object sender, EventArgs e)
        {
            
            Regex numbers = new Regex(@"^[0-9]*$");
            Match salaryMatch = numbers.Match(maximumBox.Text);

            if (!salaryMatch.Success)
            {
                MessageBox.Show("Salary contains only numbers");
                maximumBox.Clear();
            }
            else
            {
                if (!string.IsNullOrEmpty(maximumBox.Text))
                {
                    maxSalary = Convert.ToInt32(maximumBox.Text);
                    using (AcademyEntities db = new AcademyEntities())
                    {


                        List<Models.Employees> employeesList = db.Employees.Where(i => i.Salary >= minSalary && i.Salary <= maxSalary).ToList();


                        employeesTable.Rows.Clear();
                        foreach (var i in employeesList)
                        {
                            if (i.Status == true)
                            {
                                employeesTable.Rows.Add(i.Id,
                                            i.Name,
                                            i.Surname,
                                            i.Email,
                                            i.Phone,
                                            i.Positions.Name,
                                            i.StartTime,
                                            i.Salary);
                            }
                        }
                    }
                } else
                {
                    maxSalary = 0;
                    MinimumSalary(minimumBox, new EventArgs());
                }

            }
        }

        private void FillPositionDrop()
        {
            positionDrop.Items.Clear();
            positionDrop.Items.Add("All");
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Positions> posList = db.Positions.ToList();

                foreach (var p in posList)
                {
                    if (p.Status == true)
                    {
                        positionDrop.Items.Add(p.Name);
                    }
                }
            }
        }

        private void PositionDrop_Click(object sender, EventArgs e)
        {
            if (positionDrop.SelectedItem.ToString() == "All")
            {
                FillEmployees();
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Employees> employeesList = db.Employees.Where(i => i.Positions.Name == positionDrop.SelectedItem.ToString()).ToList();

                    employeesTable.Rows.Clear();
                    foreach (var i in employeesList)
                    {
                        if (i.Status == true)
                        {
                            employeesTable.Rows.Add(i.Id,
                                           i.Name,
                                           i.Surname,
                                           i.Email,
                                           i.Phone,
                                           i.Positions.Name,
                                           i.StartTime,
                                           i.Salary);
                        }
                    }
                }
            }
        }

        private void BeforeRadio_CheckedChanged(object sender, EventArgs e)
        {

            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Employees> employeesList = db.Employees.Where(i => i.StartTime < deadlineTimePicker.Value).ToList();

                employeesTable.Rows.Clear();
                foreach (var i in employeesList)
                {
                    if (i.Status == true)
                    {
                        employeesTable.Rows.Add(i.Id,
                                          i.Name,
                                          i.Surname,
                                          i.Email,
                                          i.Phone,
                                          i.Positions.Name,
                                          i.StartTime,
                                          i.Salary);
                    }
                }
            }
        }

        private void AfterRadio_CheckedChanged(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Models.Employees> employeesList = db.Employees.Where(i => i.StartTime > deadlineTimePicker.Value).ToList();

                employeesTable.Rows.Clear();
                foreach (var i in employeesList)
                {
                    if (i.Status == true)
                    {
                        employeesTable.Rows.Add(i.Id,
                                          i.Name,
                                          i.Surname,
                                          i.Email,
                                          i.Phone,
                                          i.Positions.Name,
                                          i.StartTime,
                                          i.Salary);
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            afterRadio.Checked = false;
            beforeRadio.Checked = false;
            FillEmployees();
        }
    }
}
