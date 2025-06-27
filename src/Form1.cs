using lwssp.Entinies;
using System;
using System.DirectoryServices;
using System.Drawing;
using System.Resources.Extensions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Windows.Forms;

namespace lwssp
{
    public partial class Form1 : Form
    {
        [DllImport("lwsspfilesys.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void resetHead();
        [DllImport("lwsspfilesys.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void resetGlyphTable();
        [DllImport("lwsspfilesys.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void resetData();
        [DllImport("lwsspfilesys.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void readFile(string filename);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            label1.Text = $"{ptIndex}/{_editing.Path.Count}";
            updateListBox();
            drawGrid = true;
            fileMode = (int)FileModeNum.fileEmpty;
            Paint_redraw();
            Paint_TableRedraw();
            resetHead();
            resetGlyphTable();
            resetData();
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        public void refreshInfo()
        {
            int pos = subSelect + pageSelect * 64;
            string line1 = $"位置$" + pos.ToString("X8") + $"\n";
            label8.Text = line1;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form2 about = new Form2();
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog(this);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                MessageBox.Show($"chosen{filePath}");
                readFile(filePath);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            subSelect = e.X / 32 + e.Y / 32 * 8;
            refreshInfo();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double x = 1.0 * (e.X - 128) / 128;
            double y = 1.0 * (128 - e.Y) / 128;
            Pt pt = new Pt(x, y);
            label2.Text = $"{x}\n{y}";
            if (processMode == (int)ProcessModeNum.processModeInputLines)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _path.Add(pt);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_path.Count <= 1)
                    {
                        MessageBox.Show($"至少两点确定一条线！");
                    }
                    else
                    {
                        _path.Add(new Pt(2.0, 0));
                        if (_editing.Path.Count <= 1)
                        {
                            _editing.Path = new List<Pt>(_path.ToArray());
                        }
                        else
                        {
                            _editing.Path.InsertRange(ptIndex + 1, _path);
                        }
                        _path.Clear();
                        processMode = (int)ProcessModeNum.processModeNone;
                        lnIndex++;
                        updateListBox();
                    }
                }
            }
            Paint_redraw();
        }

        private void Paint_redraw()
        {
            System.Drawing.Point tmpPnt = new System.Drawing.Point(0, 0);
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            Bitmap buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.DarkGray, 1);
            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Blue, 2);
            g.DrawLine(pen, 0, 128, 256, 128);
            g.DrawLine(pen, 128, 0, 128, 256);
            if (drawGrid)
            {
                g.DrawLine(pen, 0, 0, 256, 256);
                g.DrawLine(pen, 256, 0, 0, 256);
                g.DrawLine(pen, 48, 48, 208, 48);
                g.DrawLine(pen, 208, 48, 208, 208);
                g.DrawLine(pen, 208, 208, 48, 208);
                g.DrawLine(pen, 48, 208, 48, 48);
            }

            if (_path != null && _path.Count == 1)
            {
                g.FillEllipse(Brushes.Blue,
                    126 + (int)(_path[0].X * 128),
                    126 - (int)(_path[0].Y * 128),
                    5, 5);
            }
            if (_path != null && _path.Count >= 2)
            {
                for (int i = 0; i < _path.Count; i++)
                {
                    g.FillEllipse(Brushes.Blue,
                        126 + (int)(_path[i].X * 128),
                        126 - (int)(_path[i].Y * 128),
                        5, 5);
                    tmpPnt.X = 128 + (int)(_path[i].X * 128);
                    tmpPnt.Y = 128 - (int)(_path[i].Y * 128);
                    points.Add(tmpPnt);
                }
                g.DrawLines(pen2, points.ToArray());
                points.Clear();
            }
            if (_editing.Path != null && _editing.Path.Count >= 1)
            {
                for (int i = 0; i < _editing.Path.Count; i++)
                {
                    if (_editing.Path[i].X == 2.0 && points.Count >= 2)
                    {
                        g.DrawLines(pen1, points.ToArray());
                        points.Clear();
                    }
                    else
                    {
                        tmpPnt.X = 128 + (int)(_editing.Path[i].X * 128);
                        tmpPnt.Y = 128 - (int)(_editing.Path[i].Y * 128);
                        points.Add(tmpPnt);

                    }
                }
            }
            g.DrawImage(buffer, 0, 0);
            g.Dispose();
        }

        private void Paint_TableRedraw()
        {
            Bitmap buffer = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = pictureBox2.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.DarkGray, 1);
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(pen, 0, i * 32 + 31, 256, i * 32 + 31);
                g.DrawLine(pen, i * 32 + 31, 0, i * 32 + 31, 256);
            }

            g.DrawImage(buffer, 0, 0);
            g.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (processMode)
            {
                case (int)ProcessModeNum.processModeNone:
                    {
                        label3.Text = $"就绪。";
                        break;
                    }
                case (int)ProcessModeNum.processModeInputLines:
                    {
                        label3.Text = $"添加一个线段，右键结束。";
                        break;
                    }
            }
            drawGrid = checkBox2.Checked;

            label1.Text = $"{ptIndex + 1}/{_editing.Path.Count}";
            label4.Text = $"{listBox1.SelectedIndex}\n{_path.Count}\n{_editing.Path.Count}";
        }

        public void updateListBox()
        {
            List<Pt> points = new List<Pt>();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 0; i < _editing.Path.Count; i++)
            {
                points.Add(_editing.Path[i]);
                listBox2.Items.Add($"({_editing.Path[i].X},{_editing.Path[i].Y})");
                if (_editing.Path[i].X == 2.0)
                {
                    if (points.Count == 3)
                    {
                        listBox1.Items.Add("线段");
                    }
                    if (points.Count >= 4)
                    {
                        listBox1.Items.Add("多段线");
                    }
                    points.Clear();
                }
            }
            listBox1.Items.Add("末尾");
            listBox1.SelectedIndex = lnIndex;
            listBox2.SelectedIndex = ptIndex;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void button6_newline_Click(object sender, EventArgs e)
        {
            Paint_redraw();
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show($"未选中位置！");
                ptIndex = 0;
                return;
            }
            ptIndex = _editing.LineIndex(listBox1.SelectedIndex);
            processMode = (int)ProcessModeNum.processModeInputLines;
            _path.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ptIndex = 0;
            updateListBox();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ptIndex--;
            if (ptIndex < 0) ptIndex = 0;
            updateListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ptIndex++;
            if (ptIndex > _editing.Path.Count) ptIndex = _editing.Path.Count;
            updateListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ptIndex = _editing.Path.Count;
            updateListBox();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ToolStripMenuItem0_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Paint_redraw();
            Paint_TableRedraw();
            refreshInfo();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Paint_redraw();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ptIndex = listBox2.SelectedIndex;
            Paint_redraw();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnIndex = listBox1.SelectedIndex;
            ptIndex = _editing.LineIndex(lnIndex);
            listBox2.SelectedIndex = ptIndex;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _editing.Path.Clear();
            _editing.AddPoint(2.0, 0);
            ptIndex = 0;
            lnIndex = 0;
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            updateListBox();
            Paint_redraw();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Paint_TableRedraw();
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

    }
}
