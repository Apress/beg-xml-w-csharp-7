using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace LoadXML
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
                MessageBox.Show("Please enter Path or String");
                return;
            }
            
            try
            {
                XElement root = null;
                if (radioButton1.Checked)
                {
                    root = XElement.Load(textBox1.Text);
                }
                if (radioButton2.Checked)
                {
                    StreamReader reader = File.OpenText(textBox1.Text);
                    root = XElement.Load(reader);
                }
                if (radioButton3.Checked)
                {
                    XmlReader reader = XmlReader.Create(textBox1.Text);
                    root = XElement.Load(reader);
                }
                if (radioButton4.Checked)
                {
                    root = XElement.Parse(textBox1.Text);
                }
                MessageBox.Show("XML Data Loaded Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
