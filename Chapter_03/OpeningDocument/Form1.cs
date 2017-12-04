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
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please specify path or string");
                return;
            }

            XmlTextReader reader;

            try
            {
                if (radioButton1.Checked)
                {
                    reader = new XmlTextReader(textBox1.Text);
                }
                if (radioButton2.Checked)
                {

                    FileStream stream = File.OpenRead(textBox1.Text);
                    reader = new XmlTextReader(stream);
                    //some processing code
                    stream.Close();
                    reader.Close();
                }
                if (radioButton3.Checked)
                {
                    MemoryStream ms = new MemoryStream();
                    byte[] data = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
                    ms.Write(data, 0, data.Length);
                    reader = new XmlTextReader(ms);
                    //some procesing code
                    ms.Close();
                    reader.Close();
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