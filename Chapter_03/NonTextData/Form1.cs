using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsApplication16
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
                MessageBox.Show("Invalid image file name");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox2.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }

            XmlTextWriter writer = new XmlTextWriter(textBox2.Text, null);
            FileStream fs = File.OpenRead(textBox1.Text);

            byte[] data = new byte[fs.Length];
            fs.Position = 0;
            fs.Read(data, 0, data.Length);
            fs.Close();
            writer.WriteStartDocument();
            writer.WriteStartElement("imagefile");
            writer.WriteAttributeString("filename", textBox1.Text);
            writer.WriteAttributeString("size", data.Length.ToString());
            writer.WriteBase64(data,0,data.Length);
            writer.WriteEndElement();
            writer.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox2.Text))
            {
                MessageBox.Show("The target image file doesn't exist");
                return;
            }
            
            XmlTextReader reader = new XmlTextReader(textBox2.Text);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "imagefile")
                    {
                        int length = int.Parse(reader.GetAttribute("size"));
                        string filename = reader.GetAttribute("filename");
                        byte[] imagedata = new byte[length];
                        int i = reader.ReadElementContentAsBase64(imagedata, 0, length);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(imagedata, 0, imagedata.Length);
                        Image image=Image.FromStream(ms);
                        pictureBox1.Image = image;
                        ms.Close();
                    }
                }
            }
        }
    }
}