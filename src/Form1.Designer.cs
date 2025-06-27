using System.Windows.Forms.Design.Behavior;
using lwssp.Entinies;

namespace lwssp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<Pt> _path = new List<Pt>();
        public Glyphs _editing = new Glyphs("Name", 0);
        public IdxComp _idxComp = new IdxComp("Name", 0);
        public int ptIndex = 1;
        public int lnIndex = 0;
        public int processMode = (int)ProcessModeNum.processModeNone;
        public bool drawGrid = true;
        public int fileMode = (int)FileModeNum.fileEmpty;
        public string filePath = @"%temp%\LWS\SSP\temp.ssf";
        public FileStream fileStream = null;
        public int subSelect = 0;
        public int pageSelect = 0;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem0 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            ToolStripMenuItem11 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            ToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            groupBox1 = new GroupBox();
            button11 = new Button();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            label2 = new Label();
            button11_discon = new Button();
            button10_makecon = new Button();
            button9_delpoint = new Button();
            button8_delline = new Button();
            button7_newpoint = new Button();
            button6_newline = new Button();
            label1 = new Label();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            button5 = new Button();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            saveFileDialog1 = new SaveFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox2 = new GroupBox();
            label8 = new Label();
            button10 = new Button();
            button9 = new Button();
            label7 = new Label();
            comboBox1 = new ComboBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(755, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem0, toolStripMenuItem5, toolStripMenuItem6, toolStripSeparator1, toolStripMenuItem7 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(41, 20);
            toolStripMenuItem1.Text = "文件";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // ToolStripMenuItem0
            // 
            ToolStripMenuItem0.Name = "ToolStripMenuItem0";
            ToolStripMenuItem0.ShortcutKeyDisplayString = "Ctrl+N";
            ToolStripMenuItem0.Size = new Size(131, 22);
            ToolStripMenuItem0.Text = "新建";
            ToolStripMenuItem0.Click += ToolStripMenuItem0_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.ShortcutKeyDisplayString = "Ctrl+O";
            toolStripMenuItem5.Size = new Size(131, 22);
            toolStripMenuItem5.Text = "打开";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.ShortcutKeyDisplayString = "Ctrl+S";
            toolStripMenuItem6.Size = new Size(131, 22);
            toolStripMenuItem6.Text = "保存";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(128, 6);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.ShortcutKeyDisplayString = "Ctrl+Q";
            toolStripMenuItem7.Size = new Size(131, 22);
            toolStripMenuItem7.Text = "退出";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem11 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(41, 20);
            toolStripMenuItem2.Text = "编辑";
            // 
            // ToolStripMenuItem11
            // 
            ToolStripMenuItem11.Name = "ToolStripMenuItem11";
            ToolStripMenuItem11.Size = new Size(94, 22);
            ToolStripMenuItem11.Text = "属性";
            ToolStripMenuItem11.Click += ToolStripMenuItem11_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem9 });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(41, 20);
            toolStripMenuItem3.Text = "视图";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem10 });
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(94, 22);
            toolStripMenuItem9.Text = "显示";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(94, 22);
            toolStripMenuItem10.Text = "网格";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem8, ToolStripMenuItem });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(41, 20);
            toolStripMenuItem4.Text = "关于";
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(111, 22);
            toolStripMenuItem8.Text = "关于";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            ToolStripMenuItem.Size = new Size(111, 22);
            ToolStripMenuItem.Text = "帮助";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button11);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(listBox2);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button11_discon);
            groupBox1.Controls.Add(button10_makecon);
            groupBox1.Controls.Add(button9_delpoint);
            groupBox1.Controls.Add(button8_delline);
            groupBox1.Controls.Add(button7_newpoint);
            groupBox1.Controls.Add(button6_newline);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(2, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 376);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "编辑字形";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button11
            // 
            button11.Location = new Point(126, 328);
            button11.Name = "button11";
            button11.Size = new Size(37, 24);
            button11.TabIndex = 23;
            button11.Text = "清空";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 340);
            label4.Name = "label4";
            label4.Size = new Size(33, 12);
            label4.TabIndex = 0;
            label4.Text = "label4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(268, 304);
            label6.Name = "label6";
            label6.Size = new Size(17, 12);
            label6.TabIndex = 22;
            label6.Text = "线";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(268, 18);
            label5.Name = "label5";
            label5.Size = new Size(41, 12);
            label5.TabIndex = 21;
            label5.Text = "点坐标";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 12;
            listBox2.Location = new Point(268, 33);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(64, 148);
            listBox2.TabIndex = 20;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 12;
            listBox1.Location = new Point(268, 319);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(64, 52);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button8
            // 
            button8.Location = new Point(46, 328);
            button8.Name = "button8";
            button8.Size = new Size(37, 24);
            button8.TabIndex = 19;
            button8.Text = "清参";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(6, 328);
            button7.Name = "button7";
            button7.Size = new Size(37, 24);
            button7.TabIndex = 18;
            button7.Text = "设参";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(86, 328);
            button6.Name = "button6";
            button6.Size = new Size(37, 24);
            button6.TabIndex = 17;
            button6.Text = "刷新";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(165, 311);
            label2.Name = "label2";
            label2.Size = new Size(11, 24);
            label2.TabIndex = 2;
            label2.Text = "0\r\n0";
            // 
            // button11_discon
            // 
            button11_discon.Image = Properties.Resources.button_disconnect;
            button11_discon.Location = new Point(302, 271);
            button11_discon.Name = "button11_discon";
            button11_discon.Size = new Size(30, 30);
            button11_discon.TabIndex = 16;
            button11_discon.UseVisualStyleBackColor = true;
            // 
            // button10_makecon
            // 
            button10_makecon.Image = Properties.Resources.button_connect;
            button10_makecon.Location = new Point(268, 271);
            button10_makecon.Name = "button10_makecon";
            button10_makecon.Size = new Size(30, 30);
            button10_makecon.TabIndex = 15;
            button10_makecon.UseVisualStyleBackColor = true;
            // 
            // button9_delpoint
            // 
            button9_delpoint.Image = Properties.Resources.button_delpoint;
            button9_delpoint.Location = new Point(302, 235);
            button9_delpoint.Name = "button9_delpoint";
            button9_delpoint.Size = new Size(30, 30);
            button9_delpoint.TabIndex = 14;
            button9_delpoint.UseVisualStyleBackColor = true;
            // 
            // button8_delline
            // 
            button8_delline.Image = Properties.Resources.button_delline;
            button8_delline.Location = new Point(268, 235);
            button8_delline.Name = "button8_delline";
            button8_delline.Size = new Size(30, 30);
            button8_delline.TabIndex = 13;
            button8_delline.UseVisualStyleBackColor = true;
            // 
            // button7_newpoint
            // 
            button7_newpoint.Image = Properties.Resources.button_addpoint;
            button7_newpoint.Location = new Point(302, 199);
            button7_newpoint.Name = "button7_newpoint";
            button7_newpoint.Size = new Size(30, 30);
            button7_newpoint.TabIndex = 12;
            button7_newpoint.UseVisualStyleBackColor = true;
            // 
            // button6_newline
            // 
            button6_newline.Image = Properties.Resources.button_addline;
            button6_newline.Location = new Point(268, 199);
            button6_newline.Name = "button6_newline";
            button6_newline.Size = new Size(30, 30);
            button6_newline.TabIndex = 11;
            button6_newline.UseVisualStyleBackColor = true;
            button6_newline.Click += button6_newline_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 184);
            label1.Name = "label1";
            label1.Size = new Size(33, 12);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(101, 310);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(48, 16);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "网格";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(10, 310);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 16);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "显示参照";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(66, 283);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(93, 22);
            textBox1.TabIndex = 2;
            // 
            // button5
            // 
            button5.Location = new Point(208, 283);
            button5.Name = "button5";
            button5.Size = new Size(24, 24);
            button5.TabIndex = 6;
            button5.Text = ">";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(165, 283);
            button3.Name = "button3";
            button3.Size = new Size(37, 24);
            button3.TabIndex = 4;
            button3.Text = "应用";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(238, 283);
            button4.Name = "button4";
            button4.Size = new Size(24, 24);
            button4.TabIndex = 5;
            button4.Text = "->";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(36, 283);
            button2.Name = "button2";
            button2.Size = new Size(24, 24);
            button2.TabIndex = 3;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(6, 283);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 2;
            button1.Text = "<-";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(6, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 256);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(button10);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Location = new Point(347, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(396, 376);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "字码页";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(268, 21);
            label8.Name = "label8";
            label8.Size = new Size(33, 12);
            label8.TabIndex = 5;
            label8.Text = "label8";
            // 
            // button10
            // 
            button10.FlatStyle = FlatStyle.System;
            button10.Location = new Point(53, 306);
            button10.Name = "button10";
            button10.Size = new Size(41, 23);
            button10.TabIndex = 4;
            button10.Text = "新增";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.System;
            button9.Location = new Point(6, 306);
            button9.Name = "button9";
            button9.Size = new Size(41, 23);
            button9.TabIndex = 3;
            button9.Text = "编辑";
            button9.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 286);
            label7.Name = "label7";
            label7.Size = new Size(29, 12);
            label7.TabIndex = 2;
            label7.Text = "部首";
            label7.Click += label7_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 283);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(225, 20);
            comboBox1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(6, 21);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseClick += pictureBox2_MouseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 389);
            label3.Name = "label3";
            label3.Size = new Size(0, 12);
            label3.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 411);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "字体编辑器 v1.0";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem ToolStripMenuItem0;
        private ToolStripMenuItem ToolStripMenuItem;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private ToolStripMenuItem toolStripMenuItem9;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem toolStripMenuItem10;
        private TextBox textBox1;
        private Button button5;
        private Button button3;
        private Button button4;
        private Button button2;
        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private ListBox listBox1;
        private Label label1;
        private Button button11_discon;
        private Button button10_makecon;
        private Button button9_delpoint;
        private Button button8_delline;
        private Button button7_newpoint;
        private Button button6_newline;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private Button button8;
        private Button button7;
        private Button button6;
        private ListBox listBox2;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox2;
        private Label label7;
        private ComboBox comboBox1;
        private Button button10;
        private Button button9;
        private Button button11;
        private ToolStripMenuItem ToolStripMenuItem11;
        private Label label8;
    }
}
