using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apdo_homework_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = " ";
            s = textBox1.Text;
            double divisor1 = double.Parse(s);
            s = textBox2.Text;
            double divisor2 = double.Parse(s);
            label1.Text = "divisor1*divisor2 = " + divisor1 * divisor2;
        }
    }
}
