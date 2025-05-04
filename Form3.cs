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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = Properties.Settings.Default.primary.ToString() + "秒";
            label5.Text = Properties.Settings.Default.middle.ToString() + "秒";
            label6.Text = Properties.Settings.Default.senior.ToString() + "秒";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.primary = 999;
            Properties.Settings.Default.middle = 999;
            Properties.Settings.Default.senior = 999;
            Form3_Load(sender, e);
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
