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
            XmlDocument doc = new XmlDocument();
            doc.Load($"{Application.StartupPath}\\employees.xml");

            TreeNode root=new TreeNode(doc.DocumentElement.Name);
            treeView1.Nodes.Add(root);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                TreeNode employee = new TreeNode("Employee ID :" + node.Attributes["employeeid"].Value);
                root.Nodes.Add(employee);
                if (node.HasChildNodes)
                {
                    foreach (XmlNode childnode in node.ChildNodes)
                    {
                        TreeNode n2 = new TreeNode(childnode.Name + " : "+ childnode.InnerText);
                        employee.Nodes.Add(n2);
                    }
                }
            }
        }
    }
}