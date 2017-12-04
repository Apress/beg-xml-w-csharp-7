using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectingXMLToCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            XElement root = XElement.Load($"{Application.StartupPath}\\employees.xml");
            var employees = from item in root.Descendants("employee")
                            select new  
                            {
                             EmployeeID = item.Attribute("employeeid").Value,
                             FirstName = item.Element("firstname").Value,
                             LastName = item.Element("lastname").Value,
                             HomePhone = item.Element("homephone").Value,
                             Notes = item.Element("notes").Value
                            };

            dataGridView1.DataSource = employees.ToArray();
        }
    }
}
