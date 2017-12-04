using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RelationalToXml;
using System.Xml;

namespace WindowsApplication66
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableReader tr = new TableReader(textBox1.Text, textBox2.Text);
            XmlTextWriter writer = new XmlTextWriter($"{Application.StartupPath}\\temp.xml", null);
            writer.WriteStartDocument();
            writer.WriteStartElement("root");
            int count = tr.AttributeCount;
            while (tr.Read())
            {
                writer.WriteStartElement(tr.Name);
                for (int i = 0; i < count; i++)
                {
                    tr.MoveToAttribute(i);
                    tr.ReadAttributeValue();
                    writer.WriteAttributeString(tr.Name, tr.Value);
                }
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();
            tr.Close();
            writer.Close();
            webBrowser1.Navigate($"{Application.StartupPath}\\temp.xml");
        }
    }
}