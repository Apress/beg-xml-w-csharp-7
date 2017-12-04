using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LINQBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Employee> employees = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a field to GROUP BY");
                return;
            }

            txtResults.Clear();
            if (comboBox1.SelectedItem.ToString() == "Country")
            {
                var result = from item in employees
                             group item by item.Country;
                foreach (var group in result)
                {
                    OutputResults("Group :" + group.Key);
                    foreach (Employee emp in group)
                    {
                        OutputResults(emp);
                    }
                }
            }

            if (comboBox1.SelectedItem.ToString() == "EmployeeID")
            {
                var result = from item in employees
                             group item by item.EmployeeID;
                foreach (var group in result)
                {
                    OutputResults("Group :" + group.Key);
                    foreach (Employee emp in group)
                    {
                        OutputResults(emp);
                    }
                }
            }

            if (comboBox1.SelectedItem.ToString() == "FirstName")
            {
                var result = from item in employees
                             group item by item.FirstName;
                foreach (var group in result)
                {
                    OutputResults("Group :" + group.Key);
                    foreach (Employee emp in group)
                    {
                        OutputResults(emp);
                    }
                }
            }

            if (comboBox1.SelectedItem.ToString() == "LastName")
            {
                var result = from item in employees
                             group item by item.LastName;
                foreach (var group in result)
                {
                    OutputResults("Group :" + group.Key);
                    foreach (Employee emp in group)
                    {
                        OutputResults(emp);
                    }
                }
            }

            if (comboBox1.SelectedItem.ToString() == "BirthDate")
            {
                var result = from item in employees
                             group item by item.BirthDate;
                foreach (var group in result)
                {
                    OutputResults("Group :" + group.Key);
                    foreach (Employee emp in group)
                    {
                        OutputResults(emp);
                    }
                }
            }
            
        }

        private void OutputResults(Employee emp)
        {
            txtResults.Text += "[" + emp.EmployeeID + "] ";
            txtResults.Text += emp.FirstName + " " + emp.LastName +
                "(" + emp.BirthDate.ToShortDateString() + ")," + 
                emp.Country + "\r\n";

        }

        private void OutputResults(string msg)
        {
            txtResults.Text += msg + "\r\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employees = Employee.GetEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a field to ORDER BY");
                return;
            }

            
            txtResults.Clear();
            if (comboBox2.SelectedItem.ToString() == "Country")
            {
                var result = from employee in employees
                             orderby employee.Country
                             select employee;
                foreach (var employee in result)
                {
                     OutputResults(employee);
                }
            }

            if (comboBox2.SelectedItem.ToString() == "EmployeeID")
            {
                var result = from item in employees
                             orderby item.EmployeeID
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox2.SelectedItem.ToString() == "FirstName")
            {
                var result = from item in employees
                             orderby item.FirstName
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox2.SelectedItem.ToString() == "LastName")
            {
                var result = from item in employees
                             orderby item.LastName
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox2.SelectedItem.ToString() == "BirthDate")
            {
                var result = from item in employees
                             orderby item.BirthDate
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a field to filter");
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter filter criteria");
                return;
            }
            
            txtResults.Clear();
            if (comboBox3.SelectedItem.ToString() == "Country")
            {
                var result = from item in employees
                             where item.Country==textBox1.Text
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox3.SelectedItem.ToString() == "EmployeeID")
            {
                var result = from item in employees
                             where item.EmployeeID== int.Parse(textBox1.Text)
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox3.SelectedItem.ToString() == "FirstName")
            {
                var result = from item in employees
                             where item.FirstName== textBox1.Text
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox3.SelectedItem.ToString() == "LastName")
            {
                var result = from item in employees
                             where item.LastName == textBox1.Text
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

            if (comboBox3.SelectedItem.ToString() == "BirthDate")
            {
                var result = from item in employees
                             where item.BirthDate == DateTime.Parse(textBox1.Text)
                             select item;
                foreach (var employee in result)
                {
                    OutputResults(employee);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please select output fields");
                return;
            }

            
            txtResults.Clear();
            if(comboBox4.SelectedIndex==0)
            {
                var result = from item in employees
                             select new { item.EmployeeID, item.FirstName, item.LastName };
                foreach (var emp in result)
                {
                    OutputResults("[" + emp.EmployeeID + "] " + emp.FirstName + " " + emp.LastName);
                }

            }
            if (comboBox4.SelectedIndex == 1)
            {
                var result = from item in employees
                             select new {item.EmployeeID,item.FirstName,item.BirthDate};
                foreach (var emp in result)
                {
                    OutputResults("[" + emp.EmployeeID + "] " + emp.FirstName + " " + emp.BirthDate);
                }

            }
            if (comboBox4.SelectedIndex == 2)
            {
                var result = from item in employees
                             select new { item.EmployeeID, item.Country };
                foreach (var emp in result)
                {
                    OutputResults("[" + emp.EmployeeID + "] " + emp.Country);
                }

            }

        }
    }
}
