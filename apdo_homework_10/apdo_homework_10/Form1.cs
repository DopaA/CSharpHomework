using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;
using apdo_homeowork_10_2;

namespace apdo_homework_10
{
    public partial class Form1 : Form
    {
        public string numOfOrder;
        string OrderName;
        public string sPersonPhone;
        public int count;
        public int price;
        OrderService orderService = new OrderService();
        //public string KeyWord { get; set; }
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = orderService.GetAllOrders();
            dataGridView1.DataSource = bindingSource1;
            //textBox1.DataBindings.Add("Text", this, "KeyWord");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            numOfOrder = this.textBox1.Text;
        }

        //查找
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                bindingSource1.DataSource = orderService.GetOrder(numOfOrder);
            }
            else
            {
                bindingSource1.DataSource = orderService.GetAllOrders();
            }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null)
            {
                Order order = (Order)bindingSource1.Current;
                orderService.Delete(order.OrderNum);
                bindingSource1.DataSource = orderService.GetAllOrders();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }
        //新建
        private void button3_Click(object sender, EventArgs e)
        {
            int r = orderService.GetAllOrders().Count;
            if (dataGridView1.Rows[r].Cells[0].Value == null || dataGridView1.Rows[r].Cells[1].Value == null || dataGridView1.Rows[r].Cells[2].Value == null)
            {
                DialogResult result1 = MessageBox.Show("订单内容不可为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            numOfOrder = dataGridView1.Rows[r].Cells[0].Value.ToString();
            OrderName = dataGridView1.Rows[r].Cells[1].Value.ToString();
            sPersonPhone = dataGridView1.Rows[r].Cells[2].Value.ToString();
            string t = dataGridView1.Rows[r].Cells[3].Value.ToString();
            count = Int32.Parse(t);
            string p = dataGridView1.Rows[r].Cells[4].Value.ToString();
            price = Int32.Parse(p);
            int n = 0;
            List<Order> orders = orderService.GetAllOrders();
            for(int i=0; i < orders.Count; i++)
            {
                if (orders[i].OrderNum == numOfOrder)
                {
                    n++;
                }
            }
            Regex regex = new Regex("[0-9]{11}");
            bool mat = regex.IsMatch(numOfOrder);
            Regex regex1 = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}");
            bool phmat = regex1.IsMatch(sPersonPhone);
            if (n >0 || (!mat) || (!phmat))
            {
                if (!mat)
                {
                    DialogResult result1 = MessageBox.Show("订单编号不符合年月日规范", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!phmat)
                {
                    DialogResult result1 = MessageBox.Show("手机号不符合规范，格式为199-1999-1111", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult result1 = MessageBox.Show("订单重复", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("创建成功", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                orderService.Add(new Order(numOfOrder, OrderName, sPersonPhone, count, price));
               bindingSource1.DataSource = orderService.GetAllOrders();
            }
            r++;
            Export();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string Export()
        {
            Export(orderService.GetAllOrders());
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\OrderList.xml");
            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToRoot();
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(@"..\..\OrderList.xslt");
            XmlTextWriter writer = new XmlTextWriter(@"..\..\OrderList.html", null);
            xslt.Transform(nav, null, writer);
            writer.Flush();
            writer.Close();
            return writer.ToString();
        }
        //Export方法，将所有订单序列化为xml文件
        public static void Export(List<Order> orders)
        {
            XmlSerializer xmlOrderservice = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"..\..\OrderList.xml";
            XmlSerialize(xmlOrderservice, xmlFileName, orders);
        }
        public static void XmlSerialize(XmlSerializer ser, string filename, object obj)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        //Import方法，从xml中载入订单
        public List<Order> Import()
        {
            XmlSerializer xmlOrderservice = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"..\..\Order.xml";
            FileStream fs = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read);
            List<Order> orders = (List<Order>)xmlOrderservice.Deserialize(fs);
            return orders;
        }
        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    }
}
