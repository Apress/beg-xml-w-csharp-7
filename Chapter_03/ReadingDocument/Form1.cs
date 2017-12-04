using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader($"{Application.StartupPath}\\employees.xml");

            reader.WhitespaceHandling = WhitespaceHandling.None;
            TreeNode employeenode=null;
            TreeNode rootnode = null;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "employees")
                    {
                        rootnode = treeView1.Nodes.Add("Employees");
                    }
                    if (reader.Name == "employee")
                    {
                        string employeeid = reader.GetAttribute("employeeid");
                        employeenode = new TreeNode("Employee ID :" + employeeid);
                        rootnode.Nodes.Add(employeenode);
                    }
                    if (reader.Name == "firstname")
                    {
                        string firstname = reader.ReadElementString();
                        TreeNode node = new TreeNode(firstname);
                        employeenode.Nodes.Add(node);
                    }
                    if (reader.Name == "lastname")
                    {
                        reader.Read();
                        string lastname = reader.Value;
                        TreeNode node = new TreeNode(lastname);
                        employeenode.Nodes.Add(node);
                    }
                    if (reader.Name == "homephone")
                    {
                        string homephone = reader.ReadElementString();
                        TreeNode node = new TreeNode(homephone);
                        employeenode.Nodes.Add(node);
                    }
                    if (reader.Name == "notes")
                    {
                        string notes = reader.ReadElementString();
                        TreeNode node = new TreeNode(notes);
                        employeenode.Nodes.Add(node);
                    }
                }
            }
            reader.Close();

        }
    }
}