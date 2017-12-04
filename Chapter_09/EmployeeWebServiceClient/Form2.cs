using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using EmployeeWebServiceClient.localhost1;
using EmployeeWebServiceClient.EmployeeManagerWithSOAPHeaderReference;
using System.Web.Services.Protocols;


namespace EmployeeWebServiceClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            EmployeeManagerWithSOAPHeaderSoapClient proxy = new EmployeeManagerWithSOAPHeaderSoapClient();

            EmployeeManagerHeader header = new EmployeeManagerHeader();
            header.ClientKey = "KEY002";
            //header = null;

            try
            {
                Employee[] data = proxy.SelectAll(header);
                foreach (Employee emp in data)
                {
                    comboBox1.Items.Add(emp.EmployeeID);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeManagerWithSOAPHeaderSoapClient proxy = new EmployeeManagerWithSOAPHeaderSoapClient();

            EmployeeManagerHeader header = new EmployeeManagerHeader();
            header.ClientKey = "KEY001";

            Employee data = proxy.SelectByID(header,(int)comboBox1.SelectedItem);
            textBox1.Text = data.FirstName;
            textBox2.Text = data.LastName;
            textBox3.Text = data.HomePhone;
            textBox4.Text = data.Notes;
            label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeManagerWithSOAPHeaderSoapClient proxy = new EmployeeManagerWithSOAPHeaderSoapClient();

            EmployeeManagerHeader header = new EmployeeManagerHeader();
            header.ClientKey = "KEY001";

            Employee data = new Employee();
            data.EmployeeID = (int)comboBox1.SelectedItem;
            data.FirstName = textBox1.Text;
            data.LastName = textBox2.Text;
            data.HomePhone = textBox3.Text;
            data.Notes = textBox4.Text;
            label6.Text=proxy.Update(header,data);
        }
    }
}
