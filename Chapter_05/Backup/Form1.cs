using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace WindowsApplication28
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
            if (!System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("Invalid XML file name");
                return;
            }

            if (!System.IO.File.Exists(textBox2.Text))
            {
                MessageBox.Show("Invalid schema file name");
                return;
            }
            
            XmlReaderSettings settings = new XmlReaderSettings();
            if(radioButton1.Checked)
            {
                settings.ProhibitDtd = false;
                settings.ValidationType = ValidationType.DTD;
            }
            else
            {
                settings.ValidationType=ValidationType.Schema;
                settings.Schemas.Add("", textBox2.Text);
            }
            settings.ValidationEventHandler += new ValidationEventHandler(OnValidationError);

            XmlReader reader=XmlReader.Create(textBox1.Text, settings);
            while (reader.Read())
            {
                //you can put code here
                //that reads and processes
                //the document
            }
            reader.Close();
            MessageBox.Show("Validation over");
        }

        void OnValidationError(object sender, ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}