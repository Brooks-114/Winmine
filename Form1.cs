using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winmine
{
    public partial class Form1 : Form
    {
        // 雷区预设配置
        private MineField primary = new MineField { x = 9, y = 9, mines = 10, level = Level.primary };
        private MineField middle = new MineField { x = 16, y = 16, mines = 40, level = Level.middle };
        private MineField senior = new MineField { x = 30, y = 16, mines = 99, level = Level.senior };
        public MineField now;  // 当前难度
        public bool gameState = true;
        private int down;

        // 控件池和雷区数据
        public Mine[,] mines;
        private List<Mine> _controlPool = new List<Mine>();  // 控件池复用

        private bool cheatState = false;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string readJson = File.ReadAllText("now.json");
            now = JsonSerializer.Deserialize<MineField>(readJson);
            SetupForm1();
            Setup();
            changeFlag();
        }

        /// <summary>
        /// 初始化或刷新雷区（核心方法）
        /// </summary>
        public void Setup()
        {
            gameState = true;
            down = 0;

            // 清空旧控件（隐藏而非删除）
            foreach (Mine mine in _controlPool)
            {
                mine.Visible = false;
                mine.ResetState();
            }

            // 初始化雷区数组
            mines = new Mine[now.x, now.y];
            int totalCells = now.x * now.y;
            Random random = new Random();

            // 生成地雷坐标（高效随机）
            var mineIndices = Enumerable.Range(0, totalCells)
                                      .OrderBy(x => random.Next())
                                      .Take(now.mines)
                                      .ToHashSet();

            // 批量添加控件前暂停布局
            SuspendLayout();
            panel3.SuspendLayout();
            try
            {
                for (int i = 0; i < totalCells; i++)
                {
                    int x = i % now.x;
                    int y = i / now.x;
                    bool isMine = mineIndices.Contains(i);

                    Mine mine = GetOrCreateMine();
                    mine.SetPosition(x, y);
                    mine.SetMineState(isMine);
                    mines[x, y] = mine;
                    mine.Visible = true;
                }

                for (int i = 0; i < totalCells; i++)
                {
                    int x = i % now.x;
                    int y = i / now.x;
                    bool isMine = mineIndices.Contains(i);

                    mines[x, y].SetMineState(isMine);
                }

                // 批量添加未绑定的控件
                foreach (var mine in _controlPool.Where(m => m.Visible && !panel3.Controls.Contains(m)))
                {
                    panel3.Controls.Add(mine);
                }
            }
            finally
            {
                panel3.ResumeLayout(true); // 恢复布局并强制刷新.
                ResumeLayout(true);
            }

            // 更新计分板
            scoreLabel1.Value = now.mines;
            timer1.Enabled = false;
            scoreLabel2.Value = 0;
        }

        public int Down
        {
            get
            {
                return down;
            }

            set
            {
                if (value == now.x * now.y - now.mines)
                {
                    gameState = false;
                    timer1.Enabled = false;

                    panel4.BackgroundImage = Properties.Resources.按钮_笑脸_胜利;

                    foreach (Mine mine in mines)
                    {
                        if (mine.mine && mine.outState != OutState.flag)
                        {
                            mine.outState = OutState.flag;
                            mine.pictureBox1.BackgroundImage = Properties.Resources.棋子;
                            scoreLabel1.Value--;
                        }
                    }

                    switch (now.level)
                    {
                        case Level.primary:
                            if (scoreLabel2.value < Properties.Settings.Default.primary)
                            {
                                Properties.Settings.Default.primary = scoreLabel2.Value;
                                Properties.Settings.Default.Save();
                                Form3 form3 = new Form3();
                                form3.ShowDialog();
                            }
                            break;
                        case Level.middle:
                            if (scoreLabel2.value < Properties.Settings.Default.middle)
                            {
                                Properties.Settings.Default.middle = scoreLabel2.Value;
                                Properties.Settings.Default.Save();
                                Form3 form3 = new Form3();
                                form3.ShowDialog();
                            }
                            break;
                        case Level.senior:
                            if (scoreLabel2.value < Properties.Settings.Default.senior)
                            {
                                Properties.Settings.Default.senior = scoreLabel2.Value;
                                Properties.Settings.Default.Save();
                                Form3 form3 = new Form3();
                                form3.ShowDialog();
                            }
                            break;
                        case Level.custom:
                            break;
                    }
                }

                down = value;
            }
        }

        /// <summary>
        /// 从控件池获取可复用的Mine控件
        /// </summary>
        private Mine GetOrCreateMine()
        {
            var mine = _controlPool.FirstOrDefault(m => !m.Visible);
            if (mine == null)
            {
                mine = new Mine { form1 = this };
                _controlPool.Add(mine);
            }
            return mine;
        }

        /// <summary>
        /// 点击笑脸按钮重启游戏
        /// </summary>
        private async void panel4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Panel4 clicked"); // 确认事件触发
            panel4.BackgroundImage = Properties.Resources.按钮_笑脸_按下;
            await Task.Delay(50);
            开局NToolStripMenuItem_Click(sender, e);
            panel4.BackgroundImage = Properties.Resources.按钮_笑脸;
        }

        /// <summary>
        /// 计时器每秒更新
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            scoreLabel2.Value++;
        }

        /// <summary>
        /// 菜单栏-开局
        /// </summary>
        private async void 开局NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    Setup();
                });
            });
        }

        public void SetupForm1()
        {
            Size = new Size(16 * now.x + 35, 16 * now.y + 126);
            panel1.Size = new Size(16 * now.x + 20, 16 * now.y + 63);
            panel2.Size = new Size(16 * now.x + 6, 37);
            panel3.Size = new Size(16 * now.x + 6, 16 * now.y + 6);
            panel4.Location = new Point(panel2.Size.Width / 2 - 13, 5);
            scoreLabel2.Location = new Point(panel2.Size.Width - 47, 6);
        }

        private void changeFlag()
        {
            switch (now.level)
            {
                case Level.primary:
                    初级ToolStripMenuItem.Image = Properties.Resources.棋子;
                    中级ToolStripMenuItem.Image = null;
                    高级ToolStripMenuItem.Image = null;
                    自定义ToolStripMenuItem.Image = null;
                    break;
                case Level.middle:
                    初级ToolStripMenuItem.Image = null;
                    中级ToolStripMenuItem.Image = Properties.Resources.棋子;
                    高级ToolStripMenuItem.Image = null;
                    自定义ToolStripMenuItem.Image = null;
                    break;
                case Level.senior:
                    初级ToolStripMenuItem.Image = null;
                    中级ToolStripMenuItem.Image = null;
                    高级ToolStripMenuItem.Image = Properties.Resources.棋子;
                    自定义ToolStripMenuItem.Image = null;
                    break;
                case Level.custom:
                    初级ToolStripMenuItem.Image = null;
                    中级ToolStripMenuItem.Image = null;
                    高级ToolStripMenuItem.Image = null;
                    自定义ToolStripMenuItem.Image = Properties.Resources.棋子;
                    break;
            }
        }

        private void 初级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            now = primary;
            SetupForm1();
            Setup();
            changeFlag();
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            now = middle;
            SetupForm1();
            Setup();
            changeFlag();
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            now = senior;
            SetupForm1();
            Setup();
            changeFlag();
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.form1 = this;
            form2.textBox1.Text = now.x.ToString();
            form2.textBox2.Text = now.y.ToString();
            form2.textBox3.Text = now.mines.ToString();
            form2.ShowDialog();
            changeFlag();
        }

        private void 作弊CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameState) return;

            if (cheatState)
            {
                foreach (Mine mine in mines)
                {
                    if (mine.cheat == true)
                    {
                        mine.cheat = false;
                        mine.pictureBox1.BackgroundImage = null;
                    }
                }

                cheatState = false;
            }
            else
            {
                foreach (Mine mine in mines)
                {
                    if (mine.outState == OutState.flag)
                    {
                        if (!mine.mine)
                        {
                            mine.cheat = true;
                            mine.outState = OutState.up;
                            mine.pictureBox1.BackgroundImage = Properties.Resources.不为雷;
                        }
                    }
                    else if (mine.mine)
                    {
                        mine.cheat = true;
                        mine.pictureBox1.BackgroundImage = Properties.Resources.雷;
                    }
                }

                cheatState = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string json = JsonSerializer.Serialize(now);
            File.WriteAllText("now.json", json);
        }

        private void 扫雷英雄榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}