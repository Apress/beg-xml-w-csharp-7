using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using EmployeeWebServiceClient.localhost;
using EmployeeWebServiceClient.EmployeeManagerReference;


namespace EmployeeWebServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //EmployeeManager proxy = new EmployeeManager();
            EmployeeManagerSoapClient proxy = new EmployeeManagerSoapClient();
            Employee[] data = proxy.SelectAll();
            foreach(Employee emp in data)
            {
                comboBox1.Items.Add(emp.EmployeeID);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EmployeeManager proxy = new EmployeeManager();
            EmployeeManagerSoapClient proxy = new EmployeeManagerSoapClient();
            Employee data = proxy.SelectByID((int)comboBox1.SelectedItem);
            textBox1.Text = data.FirstName;
            textBox2.Text = data.LastName;
            textBox3.Text = data.HomePhone;
            textBox4.Text = data.Notes;
            label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EmployeeManager proxy = new EmployeeManager();
            EmployeeManagerSoapClient proxy = new EmployeeManagerSoapClient();
            Employee data = new Employee();
            data.EmployeeID = (int)comboBox1.SelectedItem;
            data.FirstName = textBox1.Text;
            data.LastName = textBox2.Text;
            data.HomePhone = textBox3.Text;
            data.Notes = textBox4.Text;
            label6.Text=proxy.Update(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //EmployeeManager proxy = new EmployeeManager();
            EmployeeManagerSoapClient proxy = new EmployeeManagerSoapClient();
            Employee data = new Employee();
            //data.EmployeeID = int.Parse(textBox5.Text);
            data.FirstName = textBox1.Text;
            data.LastName = textBox2.Text;
            data.HomePhone = textBox3.Text;
            data.Notes = textBox4.Text;
            label6.Text = proxy.Insert(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //EmployeeManager proxy = new EmployeeManager();
            EmployeeManagerSoapClient proxy = new EmployeeManagerSoapClient();
            int id = (int)comboBox1.SelectedItem;
            label6.Text = proxy.Delete(id);
        }
    }
}
