using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace NavigateXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement root = XElement.Load($"{Application.StartupPath}\\Employees.xml");
            TreeNode rootNode = new TreeNode(root.Name.LocalName);
            treeView1.Nodes.Add(rootNode);
            foreach(XElement employee in root.Elements())
            {
                TreeNode employeeNode = new TreeNode("Employee ID :" + employee.Attribute("employeeid").Value);
                rootNode.Nodes.Add(employeeNode);
                if (employee.HasElements)
                {
                    foreach(XElement employeechild in employee.Descendants())
                    {
                        TreeNode childNode = new TreeNode(employeechild.Value);
                        employeeNode.Nodes.Add(childNode);
                    }
                }
            }
        }
    }
}
