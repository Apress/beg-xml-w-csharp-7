using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication5
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

        XmlNodeList list=null;

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($"{Application.StartupPath}\\employees.xml");
            if (radioButton1.Checked)
            {
                list = doc.SelectNodes($"//employee[./firstname/text()='{textBox1.Text}']");
                //list = doc.SelectNodes("//employee[./firstname/text()='" + textBox1.Text + "']");
            }
            else
            {
                list = doc.SelectNodes($"//employee[./lastname/text()='{textBox1.Text}']");
                //list = doc.SelectNodes("//employee[./lastname/text()='" + textBox1.Text + "']");
            }

            foreach (XmlNode node in list)
            {
                comboBox1.Items.Add(node.Attributes["employeeid"].Value);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Employee ID");
                return;
            }

            label8.Text = list[comboBox1.SelectedIndex].ChildNodes[0].InnerText;
            label9.Text = list[comboBox1.SelectedIndex].ChildNodes[1].InnerText;
            label10.Text = list[comboBox1.SelectedIndex].ChildNodes[2].InnerText;
            label11.Text = list[comboBox1.SelectedIndex].ChildNodes[3].InnerText;
        }
    }
}