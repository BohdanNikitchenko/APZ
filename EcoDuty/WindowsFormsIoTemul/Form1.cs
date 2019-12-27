using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsIoTemul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Controls[0].Visible = false;
            numericUpDown1.Minimum = -10000000000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = numericUpDown1.Value.ToString();
        }
    }
}
