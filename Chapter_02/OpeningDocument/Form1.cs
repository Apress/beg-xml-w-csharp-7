using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                if (radioButton1.Checked)
                {
                    doc.Load(textBox1.Text);
                }
                if (radioButton2.Checked)
                {

                    FileStream stream = new FileStream(textBox1.Text, FileMode.Open);
                    doc.Load(stream);
                    stream.Close();
                }
                if (radioButton3.Checked)
                {
                    doc.LoadXml(textBox1.Text);
                }
                MessageBox.Show("XML Document Opened Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}