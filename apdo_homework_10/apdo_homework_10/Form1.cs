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
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;

namespace apdo_homework_10
{
    public partial class Form1 : Form
    {
        int r = 0;
        public string numOfOrder;
        public string sName;
        public string sPersonPhone;
        public int count;

        string OrderName;
        List<Order> orders = new List<Order>();
        public string KeyWord { get; set; }
        DataSet dataSet = new DataSet();
        public Form1()
        {
            InitializeComponent();
            //bindingSource1.DataSource = orders;
            using (MySqlConnection con = GetConnection()) {
                String sql = "SELECT * FROM tab1";

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, con))
                {
                    dataAdapter.Fill(dataSet);
                    dataAdapter.Update(dataSet);
                }
              }
            bindingSource1.DataSource = dataSet.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }
        public  void AddRowInDataSet(DataSet dataSet)
        {
            using (MySqlConnection con = GetConnection())
            {
                String sql = "SELECT * FROM tab1";
                using (MySqlDataAdapter dataAdapter=new MySqlDataAdapter(sql, con))
                {
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow newRow = ds.Tables[0].NewRow();
                        newRow[0] = numOfOrder;
                        newRow[1] = sName;
                        newRow[2] = sPersonPhone;
                        newRow[3] = count;
                        newRow[4] = OrderName;
                        ds.Tables[0].Rows.Add(newRow);
                        dataAdapter.Update(ds);
                        dataSet = ds;
                        bindingSource1.DataSource = dataSet.Tables[0];
                    }
                }
            }
        }
        //删除操作
        public void DeleteRowInDataSet(DataSet dataSet,string num)
        {
            using (MySqlConnection con = GetConnection())
            {
                string sql = @"SELECT * From tab1 Where " + num + "!=numOfOrder";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, con))
                {
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);
                    DataSet myset = new DataSet();
                    using (myset)
                    {
                        dataAdapter.Fill(myset);
                        dataAdapter.Update(myset);
                        bindingSource1.DataSource = myset.Tables[0];
                    }
                }
            }
            using (MySqlConnection con = GetConnection())
            {
                    using (MySqlCommand cmd = new MySqlCommand
                        ("delete from tab1 where " + num + "=numOfOrder", con))
                    {
                        cmd.ExecuteNonQuery();
                    }
            }
        }
        //查询
        public void QueryRowInDataSet(DataSet dataSet,string num)
        {
            using (MySqlConnection con = GetConnection())
            {
                string sql = @"SELECT * From tab1 Where "+num+"=numOfOrder";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, con))
                {
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);
                    DataSet myset = new DataSet();
                    using (myset)
                    {
                        dataAdapter.Fill(myset);
                        dataAdapter.Update(myset);
                        bindingSource1.DataSource = myset.Tables[0];
                    }
                }
            }
        }
        private static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                "datasource=localhost;username=root;" +
                "password=apdo@123456;database=order1;charset=utf8");
            connection.Open();
            return connection;
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
                QueryRowInDataSet(dataSet, numOfOrder);

            }
            else
            {
                bindingSource1.DataSource = dataSet.Tables[0];
            }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "")
            {
                DeleteRowInDataSet(dataSet, numOfOrder);
            }
        }
        //新建
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[r].Cells[0].Value == null || dataGridView1.Rows[r].Cells[1].Value == null || dataGridView1.Rows[r].Cells[2].Value == null)
            {
                DialogResult result1 = MessageBox.Show("订单内容不可为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            numOfOrder = dataGridView1.Rows[r].Cells[0].Value.ToString();
            sName = dataGridView1.Rows[r].Cells[1].Value.ToString();
            sPersonPhone = dataGridView1.Rows[r].Cells[2].Value.ToString();
            string t = dataGridView1.Rows[r].Cells[3].Value.ToString();
            OrderName = dataGridView1.Rows[r].Cells[4].Value.ToString();
            count = Int32.Parse(t);
            int n = 0;
            int lengt = dataSet.Tables[0].Rows.Count;
            for(int i = 0; i < lengt; i++)
            {
                if ((string)dataSet.Tables[0].Rows[i][0] == numOfOrder)
                {
                    n++;
                }
            }
            Regex regex = new Regex("[0-9]{11}");
            bool mat = regex.IsMatch(numOfOrder);
            Regex regex1 = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}");
            bool phmat = regex1.IsMatch(sPersonPhone);
            if (n > 1 || (!mat) || (!phmat))
            {
                if (!mat)
                {
                    DialogResult result1 = MessageBox.Show("订单编号不符合年月日规范", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!phmat)
                {
                    DialogResult result1 = MessageBox.Show("手机号不符合规范，格式为199-199-1111", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                AddRowInDataSet(dataSet);
            }
            r++;
            Export();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            numOfOrder = this.textBox2.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sName = this.textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sPersonPhone = this.textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string s = this.textBox5.Text;
            count = Int32.Parse(s);
        }
        public string Export()
        {
            Export(orders);
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

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            OrderName = this.textBox6.Text;
        }
    }
}
