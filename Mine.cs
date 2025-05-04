using System;
using System.Drawing;
using System.Windows.Forms;

namespace Winmine
{
    public enum OutState
    {
        up,
        down,
        flag,
        mark
    }

    public partial class Mine : UserControl
    {
        public Form1 form1;

        public int x;
        public int y;

        private int inState = 0;
        public OutState outState = OutState.up;
        public bool mine = false;

        public bool cheat = false;

        public Mine()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // 启用PictureBox双缓冲（通过反射）
            typeof(PictureBox).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                .SetValue(pictureBox1, true, null);
        }

        private void Mine_Load(object sender, EventArgs e)
        {

        }

        private Bitmap GetBitmap(int n)
        {
            switch (n)
            {
                case 0:
                    return null;
                case 1:
                    return Properties.Resources.l1;
                case 2:
                    return Properties.Resources.l2;
                case 3:
                    return Properties.Resources.l3;
                case 4:
                    return Properties.Resources.l4;
                case 5:
                    return Properties.Resources.l5;
                case 6:
                    return Properties.Resources.l6;
                case 7:
                    return Properties.Resources.l7;
                case 8:
                    return Properties.Resources.l8;
                case 9:
                    return Properties.Resources.雷;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 鼠标按下左键处理
        /// </summary>
        public void ClickLeft()
        {
            if (outState == OutState.up)
            {
                cheat = false;
                outState = OutState.down;
                BackgroundImage = Properties.Resources.按下;
                pictureBox1.BackgroundImage = GetBitmap(inState);

                if (inState == 0)
                {
                    if (Check(x - 1, y - 1)) form1.mines[x - 1, y - 1].ClickLeft();
                    if (Check(x, y - 1))     form1.mines[x, y - 1].ClickLeft();
                    if (Check(x + 1, y - 1)) form1.mines[x + 1, y - 1].ClickLeft();
                    if (Check(x - 1, y))     form1.mines[x - 1, y].ClickLeft();
                    if (Check(x + 1, y))     form1.mines[x + 1, y].ClickLeft();
                    if (Check(x - 1, y + 1)) form1.mines[x - 1, y + 1].ClickLeft();
                    if (Check(x, y + 1))     form1.mines[x, y + 1].ClickLeft();
                    if (Check(x + 1, y + 1)) form1.mines[x + 1, y + 1].ClickLeft();
                }

                if (mine)
                {
                    form1.timer1.Enabled = false;
                    form1.panel4.BackgroundImage = Properties.Resources.按钮_笑脸_失败;

                    foreach (var mine in form1.mines)
                    {
                        if (mine.mine && mine.outState != OutState.flag)
                        {
                            mine.outState = OutState.down;
                            mine.BackgroundImage = Properties.Resources.按下;
                            mine.pictureBox1.BackgroundImage = GetBitmap(inState);
                        }
                        else if (!mine.mine && mine.outState == OutState.flag)
                        {
                            mine.pictureBox1.BackgroundImage = Properties.Resources.不为雷;
                        }
                    }

                    pictureBox1.BackgroundImage = Properties.Resources.按下雷;
                }

                form1.Down++;
            }
        }

        /// <summary>
        /// 鼠标按下中键处理
        /// </summary>
        private void ClickMiddle()
        {
            if (outState == OutState.down && inState != 0)
            {
                int count = 0;

                if (Check(x - 1, y - 1) && form1.mines[x - 1, y - 1].outState == OutState.flag) count++;
                if (Check(x, y - 1) && form1.mines[x, y - 1].outState == OutState.flag)         count++;
                if (Check(x + 1, y - 1) && form1.mines[x + 1, y - 1].outState == OutState.flag) count++;
                if (Check(x - 1, y) && form1.mines[x - 1, y].outState == OutState.flag)         count++;
                if (Check(x + 1, y) && form1.mines[x + 1, y].outState == OutState.flag)         count++;
                if (Check(x - 1, y + 1) && form1.mines[x - 1, y + 1].outState == OutState.flag) count++;
                if (Check(x, y + 1) && form1.mines[x, y + 1].outState == OutState.flag)         count++;
                if (Check(x + 1, y + 1) && form1.mines[x + 1, y + 1].outState == OutState.flag) count++;

                if (count != inState) return;

                if (Check(x - 1, y - 1)) form1.mines[x - 1, y - 1].ClickLeft();
                if (Check(x, y - 1))     form1.mines[x, y - 1].ClickLeft();
                if (Check(x + 1, y - 1)) form1.mines[x + 1, y - 1].ClickLeft();
                if (Check(x - 1, y))     form1.mines[x - 1, y].ClickLeft();
                if (Check(x + 1, y))     form1.mines[x + 1, y].ClickLeft();
                if (Check(x - 1, y + 1)) form1.mines[x - 1, y + 1].ClickLeft();
                if (Check(x, y + 1))     form1.mines[x, y + 1].ClickLeft();
                if (Check(x + 1, y + 1)) form1.mines[x + 1, y + 1].ClickLeft();
            }
        }

        /// <summary>
        /// 鼠标按下右键处理
        /// </summary>
        private void ClickRight()
        {
            if (outState != OutState.down)
                switch (outState)
                {
                    case OutState.up:
                        outState = OutState.flag;
                        pictureBox1.BackgroundImage = Properties.Resources.棋子;
                        form1.scoreLabel1.Value--;
                        break;
                    case OutState.flag:
                        outState |= OutState.mark;
                        pictureBox1.BackgroundImage = Properties.Resources.问号;
                        form1.scoreLabel1.Value++;
                        break;
                    case OutState.mark:
                        outState = OutState.up;
                        pictureBox1.BackgroundImage = null;
                        break;
                }
        }

        /// <summary>
        /// 鼠标按下时处理
        /// </summary>
        private void Mine_MouseDown(object sender, MouseEventArgs e)
        {
            if (form1.gameState)
            {
                if (form1.timer1.Enabled == false)
                    form1.timer1.Enabled = true;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        ClickLeft();
                        break;
                    case MouseButtons.Middle:
                        ClickMiddle();
                        break;
                    case MouseButtons.Right:
                        ClickRight();
                        break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Mine_MouseDown(sender, e);
        }

        /// <summary>
        /// 重置控件状态
        /// </summary>
        public void ResetState()
        {
            outState = OutState.up;
            mine = false;
            BackgroundImage = Properties.Resources.默认;
            pictureBox1.BackgroundImage = null;
        }

        /// <summary>
        /// 设置地雷状态
        /// </summary>
        public void SetMineState(bool isMine)
        {
            mine = isMine;
            if (mine)
            {
                inState = 9;
            }
            else
            {
                inState = 0;
                if (Check(x - 1, y - 1) && form1.mines[x - 1, y - 1]?.mine == true) inState++;
                if (Check(x, y - 1) && form1.mines[x, y - 1]?.mine == true) inState++;
                if (Check(x + 1, y - 1) && form1.mines[x + 1, y - 1]?.mine == true) inState++;
                if (Check(x - 1, y) && form1.mines[x - 1, y]?.mine == true) inState++;
                if (Check(x + 1, y) && form1.mines[x + 1, y]?.mine == true) inState++;
                if (Check(x - 1, y + 1) && form1.mines[x - 1, y + 1]?.mine == true) inState++;
                if (Check(x, y + 1) && form1.mines[x, y + 1]?.mine == true) inState++;
                if (Check(x + 1, y + 1) && form1.mines[x + 1, y + 1]?.mine == true) inState++;
            }
        }

        /// <summary>
        /// 检查越界
        /// </summary>
        /// <returns></returns>
        private bool Check(int x, int y)
        {
            return 0 <= x && x < form1.now.x && 0 <= y && y < form1.now.y;
        }

        /// <summary>
        /// 设置控件位置（无冗余更新）
        /// </summary>
        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            Location = new Point(x * 16 + 3, y * 16 + 3);
        }
    }
}
