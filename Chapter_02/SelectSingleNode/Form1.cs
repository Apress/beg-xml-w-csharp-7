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

        XmlNode node = null;

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($"{Application.StartupPath}\\employees.xml");
            if (radioButton1.Checked)
            {
                node = doc.SelectSingleNode($"//employee[./firstname/text()='{textBox1.Text}']");
            }
            else
            {
                node = doc.SelectSingleNode($"//employee[./lastname/text()='{textBox1.Text}']");
            }
            if (node != null)
            {
                comboBox1.Items.Add(node.Attributes["employeeid"].Value);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (node == null)
            {
                MessageBox.Show("Please select Employee ID");
                return;
            }
            
            label8.Text = node.ChildNodes[0].InnerText;
            label9.Text = node.ChildNodes[1].InnerText;
            label10.Text = node.ChildNodes[2].InnerText;
            label11.Text = node.ChildNodes[3].InnerText;
        }
    }
}