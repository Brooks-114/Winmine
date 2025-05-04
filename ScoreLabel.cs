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
    public partial class ScoreLabel : UserControl
    {
        public ScoreLabel()
        {
            InitializeComponent();
        }

        public int value = 0;

        Bitmap GetBitmap(char number)
        {
            switch (number)
            {
                case '-':
                    return Properties.Resources._;
                case '0':
                    return Properties.Resources._0;
                case '1':
                    return Properties.Resources._1;
                case '2':
                    return Properties.Resources._2;
                case '3':
                    return Properties.Resources._3;
                case '4':
                    return Properties.Resources._4;
                case '5':
                    return Properties.Resources._5;
                case '6':
                    return Properties.Resources._6;
                case '7':
                    return Properties.Resources._7;
                case '8':
                    return Properties.Resources._8;
                case '9':
                    return Properties.Resources._9;
                default:
                    return Properties.Resources._0;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                if (value >= 999)
                {
                    pictureBox1.BackgroundImage = GetBitmap('9');
                    pictureBox2.BackgroundImage = GetBitmap('9');
                    pictureBox3.BackgroundImage = GetBitmap('9');
                }
                else if (value <= -99)
                {
                    pictureBox1.BackgroundImage = GetBitmap('-');
                    pictureBox2.BackgroundImage = GetBitmap('9');
                    pictureBox3.BackgroundImage = GetBitmap('9');
                }
                else
                {
                    string num = "00" + value.ToString();

                    pictureBox1.BackgroundImage = GetBitmap(num[num.Length - 3]);
                    pictureBox2.BackgroundImage = GetBitmap(num[num.Length - 2]);
                    pictureBox3.BackgroundImage = GetBitmap(num[num.Length - 1]);
                }

                this.value = value;
            }
        }
    }
}
