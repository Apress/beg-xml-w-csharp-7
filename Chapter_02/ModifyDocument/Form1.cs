using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        int CurrentNodeIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.Load($"{Application.StartupPath}\\employees.xml");

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                comboBox1.Items.Add(node.Attributes["employeeid"].Value);
            }
            FillControls();
        }

        private void FillControls()
        {
            XmlNode node = doc.DocumentElement.ChildNodes[CurrentNodeIndex];
            comboBox1.Text = node.Attributes["employeeid"].Value;
            textBox1.Text = node.ChildNodes[0].InnerText;
            textBox2.Text = node.ChildNodes[1].InnerText;
            textBox3.Text = node.ChildNodes[2].InnerText;
            textBox4.Text = node.ChildNodes[3].InnerText;
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            label6.Text = $"Employee {(CurrentNodeIndex + 1)} of {doc.DocumentElement.ChildNodes.Count}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CurrentNodeIndex = 0;
            FillControls();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentNodeIndex--;
            if (CurrentNodeIndex < 0)
            {
                CurrentNodeIndex = 0;
            }
            FillControls();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CurrentNodeIndex++;
            if (CurrentNodeIndex >= doc.DocumentElement.ChildNodes.Count)
            {
                CurrentNodeIndex = doc.DocumentElement.ChildNodes.Count-1;
            }
            FillControls();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrentNodeIndex = doc.DocumentElement.ChildNodes.Count - 1;
            FillControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            XmlElement employee = doc.CreateElement("employee");
            XmlElement firstname = doc.CreateElement("firstname");
            XmlElement lastname = doc.CreateElement("lastname");
            XmlElement homephone = doc.CreateElement("homephone");
            XmlElement notes = doc.CreateElement("notes");

            XmlAttribute employeeid = doc.CreateAttribute("employeeid");
            employeeid.Value = comboBox1.Text;

            XmlText firstnametext = doc.CreateTextNode(textBox1.Text);
            XmlText lastnametext = doc.CreateTextNode(textBox2.Text);
            XmlText homephonetext = doc.CreateTextNode(textBox3.Text);
            XmlCDataSection notestext = doc.CreateCDataSection(textBox4.Text);

            employee.Attributes.Append(employeeid);
            employee.AppendChild(firstname);
            employee.AppendChild(lastname);
            employee.AppendChild(homephone);
            employee.AppendChild(notes);

            firstname.AppendChild(firstnametext);
            lastname.AppendChild(lastnametext);
            homephone.AppendChild(homephonetext);
            notes.AppendChild(notestext);

            doc.DocumentElement.AppendChild(employee);
            doc.Save($"{Application.StartupPath}\\employees.xml");

            UpdateLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            XmlNode node=doc.SelectSingleNode($"//employee[@employeeid='{comboBox1.Text}']");
            if (node != null)
            {
                node.ChildNodes[0].InnerText = textBox1.Text;
                node.ChildNodes[1].InnerText = textBox2.Text;
                node.ChildNodes[2].InnerText = textBox3.Text;
                XmlCDataSection notes = doc.CreateCDataSection(textBox4.Text);
                node.ChildNodes[3].ReplaceChild(notes, node.ChildNodes[3].ChildNodes[0]);
            }
            doc.Save($"{Application.StartupPath}\\employees.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlNode node = doc.SelectSingleNode($"//employee[@employeeid='{comboBox1.Text}']");
            if (node != null)
            {
                doc.DocumentElement.RemoveChild(node);
            }
            doc.Save($"{Application.StartupPath}\\employees.xml");
            UpdateLabel();
        }
    }
}