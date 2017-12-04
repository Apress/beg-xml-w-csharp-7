using System;
using System.Windows.Forms;
//using HelloWorldLib;

namespace HelloWindowsWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Class1 obj = new Class1();
            //MessageBox.Show(obj.HelloWorld());
            MessageBox.Show("Hello from Windows Forms");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}