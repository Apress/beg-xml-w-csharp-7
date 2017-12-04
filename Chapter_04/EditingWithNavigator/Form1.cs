using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        XPathNavigator navigator = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.Load($"{Application.StartupPath}\\employees.xml");
            navigator = doc.CreateNavigator();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Employee ID");
                return;
            }
            
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
                        navigator.MoveToFirstChild();
                        do
                        {
                            switch (navigator.Name)
                            {
                                case "firstname":
                                    textBox2.Text = navigator.Value;
                                    break;
                                case "lastname":
                                    textBox3.Text = navigator.Value;
                                    break;
                                case "homephone":
                                    textBox4.Text = navigator.Value;
                                    break;
                                case "notes":
                                    textBox5.Text = navigator.Value;
                                    break;

                            }
                        }
                        while (navigator.MoveToNext());
                        navigator.MoveToParent();
                    }
                }
                while (navigator.MoveToNext());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            
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
                        navigator.MoveToFirstChild();
                        do
                        {
                            switch (navigator.Name)
                            {
                                case "firstname":
                                    navigator.SetValue(textBox2.Text);
                                    break;
                                case "lastname":
                                    navigator.SetValue(textBox3.Text);
                                    break;
                                case "homephone":
                                    navigator.SetValue(textBox4.Text);
                                    break;
                                case "notes":
                                    navigator.SetValue(textBox5.Text);
                                    break;
                            }
                        }
                        while (navigator.MoveToNext());
                        navigator.MoveToParent();
                    }
                }
                while (navigator.MoveToNext());
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            doc.Save($"{Application.StartupPath}\\employees.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Employee ID");
                return;
            }
            
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
                        navigator.DeleteSelf();
                    }
                }
                while (navigator.MoveToNext());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text=="")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            
            navigator.MoveToRoot();
            navigator.MoveToFirstChild();
            while (navigator.MoveToNext())
            {
                XmlWriter writer = navigator.AppendChild();
                writer.WriteStartElement("employee");
                writer.WriteAttributeString("employeeid", textBox1.Text);
                writer.WriteElementString("firstname", textBox2.Text);
                writer.WriteElementString("lastname", textBox3.Text);
                writer.WriteElementString("homephone", textBox4.Text);
                writer.WriteElementString("notes", textBox5.Text);
                writer.WriteEndElement();
                writer.Close();
            }
            
        }
    }
}