using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winmine
{
    public partial class Form2 : Form
    {
        public Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = form1.now.x.ToString();
            }
            else if (int.Parse(textBox1.Text) > 24)
            {
                textBox1.Text = "30";
            }
            else if (int.Parse(textBox1.Text) < 0)
            {
                textBox1.Text = form1.now.x.ToString();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = form1.now.y.ToString();
            }
            else if (int.Parse(textBox2.Text) > 24)
            {
                textBox2.Text = "24";
            }
            else if (int.Parse(textBox2.Text) < 0)
            {
                textBox2.Text = form1.now.y.ToString();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = form1.now.mines.ToString();
            }
            else if (int.Parse(textBox3.Text) > form1.now.x * form1.now.y * 0.8)
            {
                textBox3.Text = (Math.Ceiling(int.Parse(textBox1.Text) * int.Parse(textBox2.Text) * 0.8)).ToString();
            }
            else if (int.Parse(textBox3.Text) < 0)
            {
                textBox3.Text = form1.now.mines.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.now.x = int.Parse(textBox1.Text);
            form1.now.y = int.Parse(textBox2.Text);
            form1.now.mines = int.Parse(textBox3.Text);
            form1.now.level = Level.custom;

            form1.SetupForm1();
            form1.Setup();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
