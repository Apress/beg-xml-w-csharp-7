using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlNodeList list = null;

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($"{Application.StartupPath}\\employees.xml");

            list=doc.GetElementsByTagName(textBox1.Text);
            listBox1.Items.Clear();
            foreach (XmlNode node in list)
            {
                listBox1.Items.Add(node.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = list[listBox1.SelectedIndex].InnerXml;
        }
    }
}