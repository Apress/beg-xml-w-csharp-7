using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ValidateSchema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                MessageBox.Show("Invalid Schema file name");
                return;
            }

            
            XDocument doc = XDocument.Load(textBox1.Text);

            XmlSchemaSet schema=new XmlSchemaSet();
            schema.Add(null,textBox2.Text);

            ValidationEventHandler handler = new ValidationEventHandler(MyHandler);
            doc.Validate(schema, handler);
        }

        public void MyHandler(object sender, ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

    }
}
