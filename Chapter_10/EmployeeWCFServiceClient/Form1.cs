using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeWCFServiceClient.EmployeeWCFServiceReference;

namespace EmployeeWCFServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string endPoint = "BasicHttpBinding_IEmployeeManager";

        private void Form1_Load(object sender, EventArgs e)
        {
            EmployeeManagerClient proxy = new EmployeeManagerClient(endPoint);
            EmployeeDataContract[] data = proxy.SelectAll();
            foreach(EmployeeDataContract emp in data)
            {
                comboBox1.Items.Add(emp.EmployeeID);
            }
            proxy.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeManagerClient proxy = new EmployeeManagerClient(endPoint);
            EmployeeDataContract data = proxy.SelectByID((int)comboBox1.SelectedItem);
            textBox1.Text = data.FirstName;
            textBox2.Text = data.LastName;
            textBox3.Text = data.HomePhone;
            textBox4.Text = data.Notes;
            label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeManagerClient proxy = new EmployeeManagerClient(endPoint);
            EmployeeDataContract data = new EmployeeDataContract();
            data.EmployeeID = (int)comboBox1.SelectedItem;
            data.FirstName = textBox1.Text;
            data.LastName = textBox2.Text;
            data.HomePhone = textBox3.Text;
            data.Notes = textBox4.Text;
            label6.Text=proxy.Update(data);
        }
    }
}
