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
    public partial class EmployeeCRUD : Form
    {
        Models.Employees employeeFound = new Models.Employees();
        public EmployeeCRUD()
        {
            InitializeComponent();
            FillPositionDrop();
            FillEmployees();
            startTimePicker.MinDate = DateTime.Now;
            deleteBtn.Enabled = false;
        }

        private void FillEmployees()
        {
            employeeTable.Rows.Clear();
            using (AcademyEntities db = new AcademyEntities())
            {
                List<Employees> employeeList = db.Employees.ToList();

                foreach (var e in employeeList)
                {
                    if (e.Status == true)
                    {
                        employeeTable.Rows.Add(e.Id,
                                           e.Name,
                                           e.Surname,
                                           e.Email,
                                           e.Phone);
                    }
                }
            }
        }

        private void AddEmployee(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    List<Models.Employees> passiveList = db.Employees.Where(a => a.Status == false).ToList();
                    Models.Employees passiveEmployee = db.Employees.Where(b => b.Email == emailBox.Text.Trim()).FirstOrDefault();

                    if (passiveList.Contains(passiveEmployee))
                    {
                        Regex letters = new Regex(@"^[A-Za-z ]+$");
                        Match nameMatch = letters.Match(nameBox.Text.Trim());
                        Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match emailMatch = email.Match(emailBox.Text.Trim());

                        Regex phone = new Regex(@"^[+0-9]*$");
                        Match phoneMatch = phone.Match(phoneBox.Text.Trim());

                        Regex numbers = new Regex(@"^[+0-9]*$");
                        Match salarymatch = numbers.Match(salaryBox.Text.Trim());

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
                        else if (!salarymatch.Success)
                        {
                            MessageBox.Show("Salary contains only numbers");
                        }
                        else
                        {
                            passiveEmployee.Status = true;
                            db.SaveChanges();
                            FillEmployees();
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

                        Regex numbers = new Regex(@"^[+0-9]*$");
                        Match salarymatch = numbers.Match(salaryBox.Text.Trim());

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
                        else if (!salarymatch.Success)
                        {
                            MessageBox.Show("Salary contains only numbers");
                        }
                        else
                        {
                            int positionId = (db.Positions.Where(p => p.Name == positionDrop.SelectedItem.ToString()).FirstOrDefault()).Id;

                            Models.Employees e1 = new Models.Employees
                            {
                                Name = nameBox.Text.Trim(),
                                Surname = surnameBox.Text.Trim(),
                                Email = emailBox.Text.Trim(),
                                Phone = phoneBox.Text.Trim(),
                                PositionId = positionId,
                                StartTime = startTimePicker.Value,
                                Salary = Convert.ToInt32(salaryBox.Text.Trim()),
                                Status = true
                            };
                            db.Employees.Add(e1);
                            db.SaveChanges();
                            FillEmployees();
                            Reset();
                        }
                    }
                }
            }
            else
            {
                using (AcademyEntities db = new AcademyEntities())
                {
                    int positionId = (db.Positions.Where(p => p.Name == positionDrop.SelectedItem.ToString()).FirstOrDefault()).Id;
                    int empId = Convert.ToInt32(employeeTable.SelectedRows[0].Cells[0].Value);

                    Models.Employees newEmployee = db.Employees.Where(x => x.Id == employeeFound.Id).FirstOrDefault();

                    newEmployee.Id = empId;

                    Regex letters = new Regex(@"^[A-Za-z ]+$");
                    Match nameMatch = letters.Match(nameBox.Text.Trim());
                    Match surnameMatch = letters.Match(surnameBox.Text.Trim());

                    Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match emailMatch = email.Match(emailBox.Text.Trim());

                    Regex phone = new Regex(@"^[+0-9]*$");
                    Match phoneMatch = phone.Match(phoneBox.Text.Trim());

                    Regex numbers = new Regex(@"^[+0-9]*$");
                    Match salarymatch = numbers.Match(salaryBox.Text.Trim());

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
                    else if (!salarymatch.Success)
                    {
                        MessageBox.Show("Salary contains only numbers");
                    }
                    else
                    {
                        newEmployee.Name = nameBox.Text.Trim();
                        newEmployee.Surname = surnameBox.Text.Trim();
                        newEmployee.Email = emailBox.Text.Trim();
                        newEmployee.Phone = phoneBox.Text.Trim();
                        newEmployee.PositionId = positionId;
                        newEmployee.StartTime = startTimePicker.Value;
                        newEmployee.Salary = Convert.ToInt32(salaryBox.Text.Trim());
                        db.SaveChanges();
                        FillEmployees();
                        Reset();
                    }
                }
            }
        }

        private void FillPositionDrop()
        {
            positionDrop.Items.Clear();
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

        private void Reset()
        {
            nameBox.Clear();
            surnameBox.Clear();
            emailBox.Clear();
            phoneBox.Clear();
            positionDrop.SelectedIndex = -1;
            startTimePicker.Value = DateTime.Now;
            salaryBox.Clear();
            deleteBtn.Enabled = false;
            saveBtn.Text = "Save";
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void EmployeeTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int empId = Convert.ToInt32(employeeTable.Rows[e.RowIndex].Cells[0].Value);

            using (AcademyEntities db = new AcademyEntities())
            {
                employeeFound = db.Employees.Where(a => a.Id == empId).FirstOrDefault();

                if (employeeFound != null)
                {
                    nameBox.Text = employeeFound.Name;
                    surnameBox.Text = employeeFound.Surname;
                    emailBox.Text = employeeFound.Email;
                    phoneBox.Text = employeeFound.Phone;
                    positionDrop.SelectedItem = employeeFound.Positions.Name;
                    startTimePicker.Value = employeeFound.StartTime;
                    salaryBox.Text = Convert.ToString(employeeFound.Salary);
                }
                saveBtn.Text = "Update";
                deleteBtn.Enabled = true;
            }
        }

        private void DeleteEmployee(object sender, EventArgs e)
        {
            using (AcademyEntities db = new AcademyEntities())
            {
                int empId = Convert.ToInt32(employeeTable.SelectedRows[0].Cells[0].Value);

                Models.Employees e1 = db.Employees.Where(b => b.Id == empId).FirstOrDefault();
                e1.Status = false;
                db.SaveChanges();
            }
            FillEmployees();
            Reset();
        }
    }
}
