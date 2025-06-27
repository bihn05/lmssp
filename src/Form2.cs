using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lwssp
{
    public partial class Form2 : Form
    {
        [DllImport("test.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char _666();

        public Form2()
        {
            InitializeComponent();
        }
         
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string str = "AA" + _666();
            MessageBox.Show(str);
        }
    }
}
