using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Week8Day1Task.Controllers;
using Week8Day1Task.Models;
using Week8Day1Task.Repository;

namespace Week8Day1TaskTest
{
    internal class OrderTest
    {

        private Mock<IOrderRepository> _orderServiceMock;
        private OrderController _orderController;

        [SetUp]
        public void Setup()
        {
            _orderServiceMock = new Mock<IOrderRepository>();
            _orderController = new OrderController(_orderServiceMock.Object);
        }

        // 1- GetAll
        [Test]
        public void GetOrders_OrderList()
        {
            var orderList = GetMockOrdersData();
            _orderServiceMock.Setup(x => x.GetAll())
                .Returns(orderList);

            var result = _orderController.OrderList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(orderList.Count));
            Assert.That(result, Is.EquivalentTo(orderList));
        }

        // 2- GetById
        [Test]
        public void GetOrderById_Order()
        {
            var orderList = GetMockOrdersData();
            _orderServiceMock.Setup(x => x.GetById(201))
                .Returns(orderList.First(o => o.OrderId == 201));

            var result = _orderController.GetOrderById(201);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OrderId, Is.EqualTo(201));
        }

        // 3- Add
        [Test]
        public void AddOrder_Order()
        {
            var order = GetMockOrdersData()[0];
            _orderServiceMock.Setup(x => x.Add(order))
                .Returns(order);

            var result = _orderController.AddOrder(order);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Product, Is.EqualTo(order.Product));
        }

        // 4- Update
        [Test]
        public void UpdateOrder_OrderUpdated()
        {
            var updatedOrder = new Order
            {
                OrderId = 201,
                UserId = 2,
                Product = "UpdatedProduct",
                Quantity = 5,
                Price = 9999
            };

            _orderServiceMock.Setup(x => x.Update(updatedOrder))
                .Returns(updatedOrder);

            var result = _orderController.UpdateOrder(updatedOrder);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Product, Is.EqualTo("UpdatedProduct"));
            Assert.That(result.Quantity, Is.EqualTo(5));
        }

        // 5- Delete
        [Test]
        public void DeleteOrder_OrderDeleted()
        {
            var orderId = 201;
            _orderServiceMock.Setup(x => x.Delete(orderId))
                .Returns(true);

            var result = _orderController.DeleteOrder(orderId);

            Assert.That(result, Is.True);
        }

        // 6- Delete Order Not Found (edge case)
        [Test]
        public void DeleteOrder_OrderNotFound()
        {
            // Arrange
            var nonExistentOrderId = 999; // Assuming this order doesn't exist
            _orderServiceMock.Setup(x => x.Delete(nonExistentOrderId)).Returns(false);

            // Act
            var result = _orderController.DeleteOrder(nonExistentOrderId);

            // Assert
            Assert.That(result, Is.False);
        }


        // Mock order data
        private List<Order> GetMockOrdersData()
        {
            return new List<Order>
            {
                new Order
                {
                    OrderId = 201,
                    UserId = 2,
                    Product = "Keyboard",
                    Quantity = 1,
                    Price = 3000
                },
                new Order
                {
                    OrderId = 202,
                    UserId = 1,
                    Product = "Monitor",
                    Quantity = 2,
                    Price = 10000
                }
            };
        }




    }
}
