using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Employee ID");
                return;
            }


            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();

            navigator.MoveToRoot();
            navigator.MoveToFirstChild();
            while (navigator.MoveToNext())
            {
                navigator.MoveToFirstChild();
                do
                {
                    string id = navigator.GetAttribute("employeeid", "");
                    if (id == textBox1.Text)
                    {
                        XmlReader reader=navigator.ReadSubtree();
                        DisplayDetails(reader);
                    }
                }
                while (navigator.MoveToNext());
            }
        }

        private void DisplayDetails(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "firstname":
                            label6.Text = reader.ReadString();
                            break;
                        case "lastname":
                            label7.Text = reader.ReadString();
                            break;
                        case "homephone":
                            label8.Text = reader.ReadString();
                            break;
                        case "notes":
                            label9.Text = reader.ReadString();
                            break;
                    }
                }
            }
            reader.Close();
        }

    }
}