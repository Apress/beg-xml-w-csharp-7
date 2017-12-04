using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            navigator.MoveToRoot();
            navigator.MoveToFirstChild();

            TreeNode root = treeView1.Nodes.Add("Employees");

            while (navigator.MoveToNext())
            {
                if (navigator.HasChildren)
                {
                    navigator.MoveToFirstChild();
                    do
                    {
                        string id = navigator.GetAttribute("employeeid", "");
                        TreeNode empnode = new TreeNode($"Employee ID :{id}");
                        root.Nodes.Add(empnode);
                        navigator.MoveToFirstChild();
                        do
                        {
                            string name = navigator.Name;
                            TreeNode node = new TreeNode($"{name} : {navigator.Value}");
                            empnode.Nodes.Add(node);
                        }
                        while (navigator.MoveToNext());
                        navigator.MoveToParent();
                    }
                    while (navigator.MoveToNext());
                }
            }

        }
    }
}