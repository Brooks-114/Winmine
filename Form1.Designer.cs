namespace Winmine
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开局NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.初级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作弊CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new Winmine.DoubleBufferedPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scoreLabel2 = new Winmine.ScoreLabel();
            this.scoreLabel1 = new Winmine.ScoreLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.扫雷英雄榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.作弊CToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(499, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开局NToolStripMenuItem,
            this.toolStripSeparator1,
            this.初级ToolStripMenuItem,
            this.中级ToolStripMenuItem,
            this.高级ToolStripMenuItem,
            this.自定义ToolStripMenuItem,
            this.toolStripSeparator2,
            this.扫雷英雄榜ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.游戏ToolStripMenuItem.Text = "游戏(&G)";
            // 
            // 开局NToolStripMenuItem
            // 
            this.开局NToolStripMenuItem.Name = "开局NToolStripMenuItem";
            this.开局NToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.开局NToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.开局NToolStripMenuItem.Text = "开局(&N)";
            this.开局NToolStripMenuItem.Click += new System.EventHandler(this.开局NToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 初级ToolStripMenuItem
            // 
            this.初级ToolStripMenuItem.Name = "初级ToolStripMenuItem";
            this.初级ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.初级ToolStripMenuItem.Text = "初级(&B)";
            this.初级ToolStripMenuItem.Click += new System.EventHandler(this.初级ToolStripMenuItem_Click);
            // 
            // 中级ToolStripMenuItem
            // 
            this.中级ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.中级ToolStripMenuItem.Name = "中级ToolStripMenuItem";
            this.中级ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.中级ToolStripMenuItem.Text = "中级(&I)";
            this.中级ToolStripMenuItem.Click += new System.EventHandler(this.中级ToolStripMenuItem_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.高级ToolStripMenuItem.Text = "高级(&E)";
            this.高级ToolStripMenuItem.Click += new System.EventHandler(this.高级ToolStripMenuItem_Click);
            // 
            // 自定义ToolStripMenuItem
            // 
            this.自定义ToolStripMenuItem.Name = "自定义ToolStripMenuItem";
            this.自定义ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.自定义ToolStripMenuItem.Text = "自定义(&C)";
            this.自定义ToolStripMenuItem.Click += new System.EventHandler(this.自定义ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 作弊CToolStripMenuItem
            // 
            this.作弊CToolStripMenuItem.Name = "作弊CToolStripMenuItem";
            this.作弊CToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.作弊CToolStripMenuItem.Text = "作弊(&C)";
            this.作弊CToolStripMenuItem.Click += new System.EventHandler(this.作弊CToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Winmine.Properties.Resources.背景;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 319);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Winmine.Properties.Resources.雷区背景;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(7, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 262);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Winmine.Properties.Resources.顶部背景;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.scoreLabel2);
            this.panel2.Controls.Add(this.scoreLabel1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(7, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 37);
            this.panel2.TabIndex = 0;
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scoreLabel2.BackgroundImage")));
            this.scoreLabel2.Location = new System.Drawing.Point(439, 6);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(41, 25);
            this.scoreLabel2.TabIndex = 2;
            this.scoreLabel2.Value = 0;
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scoreLabel1.BackgroundImage")));
            this.scoreLabel1.Location = new System.Drawing.Point(5, 6);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Size = new System.Drawing.Size(41, 25);
            this.scoreLabel1.TabIndex = 1;
            this.scoreLabel1.Value = 0;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Winmine.Properties.Resources.按钮_笑脸;
            this.panel4.Location = new System.Drawing.Point(230, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(26, 26);
            this.panel4.TabIndex = 0;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // 扫雷英雄榜ToolStripMenuItem
            // 
            this.扫雷英雄榜ToolStripMenuItem.Name = "扫雷英雄榜ToolStripMenuItem";
            this.扫雷英雄榜ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.扫雷英雄榜ToolStripMenuItem.Text = "扫雷英雄榜";
            this.扫雷英雄榜ToolStripMenuItem.Click += new System.EventHandler(this.扫雷英雄榜ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(499, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creeper\'s Winmine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ScoreLabel scoreLabel2;
        public System.Windows.Forms.Timer timer1;
        public ScoreLabel scoreLabel1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作弊CToolStripMenuItem;
        public DoubleBufferedPanel panel3;
        private System.Windows.Forms.ToolStripMenuItem 开局NToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 初级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 扫雷英雄榜ToolStripMenuItem;
        public System.Windows.Forms.Panel panel4;
    }
}

