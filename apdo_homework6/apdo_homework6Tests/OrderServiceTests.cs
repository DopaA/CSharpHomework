using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void getOrdersTest()
        {
            //成功数据
            OrderService orderService = new OrderService();
            object orders = orderService.getOrders();
            Assert.AreSame(orders, orderService.orders);
            //无输入数据
        }

        [TestMethod()]
        public void addOrderTest()
        {
            OrderService orderService = new OrderService();
            //成功
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            ////非法
            //Order order =null;
            //orderService.addOrder(order);
            Assert.IsNotNull(orderService.orders[0]);
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            //合法
            Order order = new Order(1, "name", "person", 2, 10001);
            Order order1 = new Order(2, "name1", "person1", 21, 11001);
            OrderService orderService = new OrderService();
            OrderService orderService1 = new OrderService();
            orderService.addOrder(order);
            orderService.addOrder(order1);
            orderService.deleteOrder("name1");
            ////不存在的名字，出错
            //orderService.deleteOrder("nam");
            orderService1.addOrder(order);
            Assert.AreEqual(orderService1.orders[0], orderService.orders[0]);

        }

        [TestMethod()]
        public void modifyOrderTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Order order1 = new Order(2, "wat", "dsafs", 5, 10423);
            orderService.modifyOrder(0, order1);
            //错误数据
            //orderService.modifyOrder(1, order1);
            Assert.AreSame(orderService.orders[0], order1);
        }

        [TestMethod()]
        public void findByOrderTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Assert.IsTrue(orderService.findByOrder(1));
            ////选定不存在的序号
            //Assert.IsTrue(orderService.findByOrder(2));
        }

        [TestMethod()]
        public void findByNameTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Assert.IsTrue(orderService.findByName("name"));
            ////选定不存在的名字
            //Assert.IsTrue(orderService.findByName("name1"));
        }

        [TestMethod()]
        public void findByPersonTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Assert.IsTrue(orderService.findByPerson("person"));
            ////不存在的人名
            //Assert.IsTrue(orderService.findByPerson("person1"));
        }

        [TestMethod()]
        public void findByPriceTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Assert.IsTrue(orderService.findByPrice(10000));
            ////不存在的价格
            //Assert.IsTrue(orderService.findByPrice(20001));
        }

        [TestMethod()]
        public void GetNumByNameTest()
        {
            //成功
            OrderService orderService = new OrderService();
            Order order = new Order(1, "name", "person", 2, 10001);
            orderService.addOrder(order);
            Assert.AreEqual(0, orderService.GetNumByName("name"));
            ////不存在的姓名
            //Assert.AreEqual(0, orderService.GetNumByName("name1"));
        }
    }
}