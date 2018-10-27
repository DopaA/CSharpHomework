using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orders;
namespace apdo_homework_form7
{
    public partial class Form1 : Form
    {
        public int numOfOrder = 0;
        public string sName;
        public string sPerson;
        public int count;

        string OrderName;
        List<Order> orders = new List<Order>();
        public string KeyWord { get; set; }
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = orders;
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }
        private void button1_Click(object sender, EventArgs e)
        {
           bindingSource1.Add(new Order(numOfOrder, sName, sPerson, count, 1001));
            DialogResult result = MessageBox.Show("创建成功", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sName = this.textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sPerson = this.textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string s = this.textBox5.Text;
            count = Int32.Parse(s);
        }
        //删除按钮
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderName == OrderName)
                    bindingSource1.Remove(orders[i]);
            }
        }
        //查询按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                bindingSource1.DataSource =
                    orders.Where(o => o.OrderName == KeyWord);
            }
            else
            {
                bindingSource1.DataSource = orders;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OrderName = this.textBox2.Text;        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
